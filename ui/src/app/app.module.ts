import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { MatDividerModule, MatFormFieldModule } from '@angular/material';

import { AppComponent } from './app.component';
import { TodoApiService } from './todo-api.service';
import { HttpClientModule } from '../../node_modules/@angular/common/http';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserAnimationsModule,
    BrowserModule,
    HttpClientModule
  ],
  providers: [
    TodoApiService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
