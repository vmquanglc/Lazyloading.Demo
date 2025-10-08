export enum TodoTaskStatus {
  new = 0,
  InProgress = 1,
  Completed = 2,
  Cancelled = 3
}

export const TodoTaskStatusMap: Record<TodoTaskStatus, string> = {
  [TodoTaskStatus.new]: 'new',
  [TodoTaskStatus.InProgress]: 'In Progress',
  [TodoTaskStatus.Completed]: 'Completed',
  [TodoTaskStatus.Cancelled]: 'Cancelled'
};

export interface UploadFile {
  id: string;
  fileName: string;
  fileType: string;
  fileSize: number;
}


export interface ChecklistItem {
  id: string;
  content: string;
  IsCompleted: boolean;
}

export interface TodoTaskDto {
  id: string;
  title: string;
  status: string;
  startDate: string;
  endDate?: string;
  checklistCount?: number;
  uploadFileCount?: number;
}

export interface TodoTaskDetailDto extends TodoTaskDto {
  description?: string;
  checklistItems?: ChecklistItem[];
  uploadFiles?: UploadFile[];
}

export interface DownloadFileDto {
  todoTaskId: string;
  todoTaskUploadFileId: string;
}