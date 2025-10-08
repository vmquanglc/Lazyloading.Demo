import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import {
  ChecklistItem,
  TodoTaskStatus,
  TodoTaskDto,
  UploadFile,
  TodoTaskDetailDto,
  DownloadFileDto,
} from '../models/todo-task.model';
import { HttpClient } from '@angular/common/http';
import { PagedAndSortedResultRequestDto, PagedResultDto } from '@abp/ng.core';
import { RestService } from '@abp/ng.core';

function generateGUID(): string {
  // Tạo GUID dạng xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
  return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, c => {
    const r = (Math.random() * 16) | 0;
    const v = c === 'x' ? r : (r & 0x3) | 0x8;
    return v.toString(16);
  });
}

@Injectable({ providedIn: 'root' })
export class TodoTaskService {
  apiName = 'Default';
  constructor(private restService: RestService) { }

  getList(input: PagedAndSortedResultRequestDto = null) {
    return this.restService.request<TodoTaskDto[], PagedAndSortedResultRequestDto>(
      {
        method: 'GET',
        url: '/api/app/todo-task',
        params: input,
      },
      { apiName: this.apiName }
    );
  }
  getById(id: string) {
    return this.restService.request<TodoTaskDetailDto, TodoTaskDetailDto>(
      {
        method: 'GET',
        url: `/api/app/todo-task/${id}`,
        params: {} // optional
      },
      { apiName: this.apiName }
    );
  }
  uploadFile(todoTaskId: string, fileInput: HTMLInputElement) {
    if (!fileInput.files || fileInput.files.length === 0) {
      return;
    }

    const file = fileInput.files[0];

    const formData = new FormData();
    formData.append('File', file);
    // formData.append('TodoTaskId', todoTaskId);

    return this.restService.request<any, any>(
      {
        method: 'POST',
        url: `/api/app/todo-task/upload-file/${todoTaskId}`,
        params: {},
        body: formData,
      },
      { apiName: this.apiName }
    );
  }
  downloadFile(todoTaskId: string, todoTaskUploadFileId: string) {
  const body = { todoTaskId, todoTaskUploadFileId } as any;

  return this.restService.request<Blob, DownloadFileDto>(
    {
      method: 'POST',
      url: `/api/app/todo-task/download-file`,
      body,
      responseType: 'blob',
    },
    { apiName: this.apiName }
  );
}

downloadAndSaveFile(todoTaskId: string, todoTaskUploadFileId: string, fileName: string) {
  this.downloadFile(todoTaskId, todoTaskUploadFileId).subscribe(blob => {
    const a = document.createElement('a');
    const objectUrl = URL.createObjectURL(blob as any);
    a.href = objectUrl;
    a.download = fileName;
    a.click();
    URL.revokeObjectURL(objectUrl);
  });
}

}
