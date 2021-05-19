import { Component, OnInit } from '@angular/core';
import { ToDoMock } from '../shared/Mocks/Todo-mock';
import { ToDo } from '../shared/ToDo';

@Component({
  selector: 'app-todo-list',
  templateUrl: './todo-list.component.html',
  styleUrls: ['./todo-list.component.css']
})
export class TodoListComponent implements OnInit {

    title:string="To Do Lista";
    toDoListItems !: ToDo[];
    selectedToDoItem!: ToDo;

  constructor() {
  //  this.selectedToDoItem = {description:"a",isCompleted:false,amount:0};
    // this.toDoListItems =[];
  }

  ngOnInit(): void {
    this.toDoListItems=ToDoMock;
  }

  onSelect(todo : ToDo)
  {
    this.selectedToDoItem = todo;
  }
}
