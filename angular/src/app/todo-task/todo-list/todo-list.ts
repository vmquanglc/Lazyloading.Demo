import { Component, OnInit } from '@angular/core';
import { TodoTaskDto, TodoTaskStatus, TodoTaskStatusMap } from '../models/todo-task.model';
import { TodoTaskService } from '../services/todo-task.service';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { MatDialog } from '@angular/material/dialog';
import { TodoDetailComponent } from '../todo-detail/todo-detail';
@Component({
  selector: 'app-todo-list',
  imports: [CommonModule, FormsModule],
  templateUrl: './todo-list.html',
  styleUrl: './todo-list.scss',
})
export class TodoListComponent implements OnInit {
  tasks: TodoTaskDto[] = [];
  displayedColumns: string[] = ['title', 'status', 'startDate', 'endDate','checklistCount','uploadFileCount', 'action'];
  TodoTaskStatusMap = TodoTaskStatusMap;

  constructor(private taskService: TodoTaskService, private dialog: MatDialog) {}

  ngOnInit() {
    this.taskService.getList().subscribe(res => (this.tasks = res as any));
  }

  viewDetail(taskId: string) {
    this.dialog.open(TodoDetailComponent, {
      width: '1100px',       // popup rộng
      maxWidth: '95vw',      // responsive
      maxHeight: '90vh',
      data: { id: taskId }, // truyền ID task
    });
  }
  statusClass(status: number) {
  switch (status) {
    case 0: // NoAction
      return 'status-new';
    case 1: // InProgress
      return 'status-inprogress';
    case 2: // Completed
      return 'status-completed';
    case 3: // Cancelled
      return 'status-cancelled';
    default:
      return '';
  }
}
}
