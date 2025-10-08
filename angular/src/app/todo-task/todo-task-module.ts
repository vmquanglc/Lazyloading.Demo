import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatTableModule } from '@angular/material/table';
import { MatSelectModule } from '@angular/material/select';
import { MatButtonModule } from '@angular/material/button';
import { MatDialogModule } from '@angular/material/dialog';
import { FormsModule } from '@angular/forms';

import { TodoTaskRoutingModule } from './todo-task-routing-module';
import { TodoListComponent } from './todo-list/todo-list';


@NgModule({
  declarations: [
  ],
  imports: [
    CommonModule,
    TodoTaskRoutingModule,
    FormsModule
  ]
})
export class TodoTaskModule { }
