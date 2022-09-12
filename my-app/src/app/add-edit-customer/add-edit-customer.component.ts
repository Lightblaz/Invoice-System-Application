import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-add-edit-customer',
  templateUrl: './add-edit-customer.component.html',
  styleUrls: ['./add-edit-customer.component.scss']
})
export class AddEditCustomerComponent implements OnInit {
  customer: any;
  customerForm = FormGroup;
  constructor(private fb:FormBuilder) {
    // this.customerForm = this.createForm();
   }

  ngOnInit(): void {
  }

}
