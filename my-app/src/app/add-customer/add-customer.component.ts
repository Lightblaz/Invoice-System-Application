import { Component, OnInit } from '@angular/core';
import { Form, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { Route, Router } from '@angular/router';
import { ProductService } from '../services/product.service';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-add-customer',
  templateUrl: './add-customer.component.html',
  styleUrls: ['./add-customer.component.scss']
})
export class AddCustomerComponent implements OnInit {

  customer:any={};
  addProdForm: FormGroup ;

  constructor(private pservice : ProductService , private fb: FormBuilder , private http:HttpClient) { 
   
    this.customer = sessionStorage.getItem("customer");
    console.log("one",this.customer);
    if(this.customer){
      console.log("two",JSON.parse(this.customer));
      this.customer = JSON.parse(this.customer);
    }else{
      this.customer = {};
    }
    
    //this.customer = JSON.parse(this.customer);
    this.addProdForm = this.createForm();
  }

  ngOnInit(): void {
    
    //this.addProdForm = this.createForm();
    // this.addProdForm = this.fb.group({
    //   id:[0],
    //   name:[null , Validators.required],
    //   description:[null , Validators.required],
    //   purchaseprice:[Math.floor(Math.random()*100)],
    //   sellingprice:[Math.floor(Math.random()*100)],
    //   quantity:[10],
    // })
  }


  createForm(){
    return this.fb.group({
      id: [this.customer.id],
      name:[this.customer.name , Validators.required],
      description:[this.customer.description , Validators.required],
      purchaseprice:[Math.floor(Math.random()*100)],
      sellingprice:[Math.floor(Math.random()*100)],
      quantity:[10]
    })
  }

  // onSubmit(){
  //   this.pservice.addproduct(this.addProdForm.value).subscribe(data => {
  //     this.router.navigate(["/customer"]);
  //   })
  // }
  onSubmit(data:any){
    this.http.post("https://localhost:7133/api/Customer/AddCustomer" , data)
    .subscribe((result) => {
      console.warn("result" , result)
    })
    console.warn(data);
  }
}
