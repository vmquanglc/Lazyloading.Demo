import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { TodoTaskService } from '../services/todo-task.service';
import {
  TodoTaskDetailDto,
  TodoTaskStatus,
  ChecklistItem,
  UploadFile,
} from '../models/todo-task.model';
import { HttpClient } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-todo-detail',
  templateUrl: './todo-detail.html',
  styleUrls: ['./todo-detail.scss'],
  imports: [CommonModule, FormsModule, MatDialogModule],
})
export class TodoDetailComponent implements OnInit {
  task: TodoTaskDetailDto = {} as TodoTaskDetailDto;

  constructor(
    private taskService: TodoTaskService,
    private http: HttpClient,
    @Inject(MAT_DIALOG_DATA) public data: { id: string },
    private dialogRef: MatDialogRef<TodoDetailComponent>
  ) {}

  ngOnInit(): void {
    this.taskService.getById(this.data.id).subscribe(res => (this.task = res));
  }

  close() {
    this.dialogRef.close();
  }

  formatFileSize(bytes: number): string {
    if (bytes < 1024) return `${bytes} Bytes`;
    else if (bytes < 1024 * 1024) return `${(bytes / 1024).toFixed(2)} KB`;
    else return `${(bytes / (1024 * 1024)).toFixed(2)} MB`;
  }
  addAttachment(fileInput: HTMLInputElement) {
    this.taskService.uploadFile(this.data.id, fileInput)?.subscribe(result => {
      console.log('Upload complete', result);
      this.task.uploadFiles.push({
        fileName: result['fileName'],
        fileSize: result['fileSize'],
        fileType: result['fileType']
      } as UploadFile);
    });
    fileInput.value = '';
  }

  removeAttachment(file: UploadFile) {
    if (!file.id) return;

    // Gọi API xóa bằng GUID
    this.http.delete(`/api/files/${file.id}`).subscribe({
      next: () => {
        this.task.uploadFiles = this.task.uploadFiles.filter(f => f.id !== file.id);
      },
      error: err => console.error('Delete failed', err),
    });
  }

  viewAttachment(file: UploadFile) {
    this.taskService.downloadAndSaveFile(this.data.id, file.id, file.fileName);
  }
  // Nếu task.startDate là Date hoặc string ISO
  get formattedStartDate() {
    if (!this.task.startDate) return '';
    const d = new Date(this.task.startDate);
    const month = (d.getMonth() + 1).toString().padStart(2, '0');
    const day = d.getDate().toString().padStart(2, '0');
    return `${d.getFullYear()}-${month}-${day}`;
  }

  set formattedStartDate(value: string) {
    this.task.startDate = new Date(value) as any;
  }
  // Nếu task.startDate là Date hoặc string ISO
  get formattedEndDate() {
    if (!this.task.endDate) return '';
    const d = new Date(this.task.endDate);
    const month = (d.getMonth() + 1).toString().padStart(2, '0');
    const day = d.getDate().toString().padStart(2, '0');
    return `${d.getFullYear()}-${month}-${day}`;
  }

  set formattedEndDate(value: string) {
    this.task.endDate = new Date(value) as any;
  }
}
