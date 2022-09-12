import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-delete-customer',
  templateUrl: './delete-customer.component.html',
  styleUrls: ['./delete-customer.component.scss']
})
export class DeleteCustomerComponent implements OnInit {

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
  }

  onSubmit(id:any){
    this.http.delete("https://localhost:7133/api/Customer/DeleteCustomer?id=" + id)
    .subscribe((result) => {
      console.warn("result" , result)
    })
  }

}
