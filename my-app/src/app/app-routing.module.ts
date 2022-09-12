import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddCustomerComponent } from './add-customer/add-customer.component';
import { ChildComponent } from './child/child.component';
import { CustomerComponent } from './customer/customer.component';
import { DeleteCustomerComponent } from './delete-customer/delete-customer.component';
import { GradeComponent } from './grade/grade.component';
import { CustomerService } from './services/customer.service';
import { StudentComponent } from './student/student.component';

const routes: Routes = [
  {
    path:'',
    redirectTo: 'dashboard',
    pathMatch: 'full'
  },
  {
    path:'dashboard',
    component: ChildComponent
  },
  {
    path:'student',
    component: StudentComponent
  },
  {
    path:'grade',
    component: GradeComponent
  },
  {
    path:'addcustomer',
    component: AddCustomerComponent
  },
  {
    path:'deletecustomer',
    component: DeleteCustomerComponent
  },
  {
    path:'customer',
    component: CustomerComponent,
    resolve:{
      data: CustomerService
    }
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
