import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CustomerService } from '../services/customer.service';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.scss']
})
export class CustomerComponent implements OnInit {

  customers:any = []
  custo:any;

  constructor(private customerService: CustomerService  , private router : Router) { }

  ngOnInit(): void 
  {
    this.customerService.onCusChange
    .subscribe((customer) => {
      if(customer)
      {
        this.customers = customer
      }
    })
  }

  //ngOnInit(): void {
      // this.customerService.getSCustomer().subscribe(data => {
      //   this.customers = data;
      // })
  //}

  // CallAllCustomers():void{
  //   this.customerService.getCustomer().subscribe(data => {
  //     this.customers = data;
  //   })
  // }

  callcustomer():void
  {
    this.customerService.get1Customer().subscribe(dat => {
      this.custo = dat;
    });
    //this.customers = this.customers.add(this.custo);
  }

  public customerAddClick(cust:any){
    console.log("cust" +  JSON.stringify(cust));
    if (cust != null){
      sessionStorage.setItem("customer" , JSON.stringify(cust));
    }else{
      sessionStorage.removeItem("customer");
    }
    this.router.navigate(['/addcustomer']);
    console.log(cust);
  }

  customerDeleteClick(delcus:any){
    //this.router.navigate(['/deletecustomer']);
    this.customerService.deleteCustomer(delcus);
  }

  homeClick(){
    this.router.navigate(['/dashboard']) ;
  }
}
