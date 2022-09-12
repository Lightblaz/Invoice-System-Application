import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ChildComponent } from './child/child.component';
import { DepartmentComponent } from './department/department.component';
import { StudentComponent } from './student/student.component';
import { GradeComponent } from './grade/grade.component';
import { CustomerComponent } from './customer/customer.component';
import { HttpClientModule } from '@angular/common/http';
import { AddEditCustomerComponent } from './add-edit-customer/add-edit-customer.component';
import { AddCustomerComponent } from './add-customer/add-customer.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { DeleteCustomerComponent } from './delete-customer/delete-customer.component';

@NgModule({
  declarations: [
    AppComponent,
    ChildComponent,
    DepartmentComponent,
    StudentComponent,
    GradeComponent,
    CustomerComponent,
    AddEditCustomerComponent,
    AddCustomerComponent,
    DeleteCustomerComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
