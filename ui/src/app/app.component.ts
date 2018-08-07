import { Component } from '@angular/core';
import { TodoApiService } from './todo-api.service';
import { Todo } from './todo';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  todos = [];

  constructor(public todoService: TodoApiService) {
    this.getData();
  }

  getData() {
    this.todoService
      .get()
      .subscribe(
        data => {
          this.todos = <Todo[]><any>data;
          console.log(this.todos);
        },
        e => console.error(e),
        () => console.log('Todos loaded .....')
      );
  }
}
