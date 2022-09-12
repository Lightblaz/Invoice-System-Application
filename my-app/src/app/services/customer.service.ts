import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Resolve, RouterStateSnapshot } from '@angular/router';
import { Observable, Subject } from 'rxjs';
import {HttpClient} from '@angular/common/http';
@Injectable({
  providedIn: 'root'
})
export class CustomerService implements Resolve<any>{


  _baseURL : String = "https://localhost:7133/api/Customer";
  onCusChange = new Subject();

  constructor(private httpclient : HttpClient) { }

  resolve():Observable<any> | Promise<any> | any {
    this.getCustomer();
    //this.getSCustomer();
  }
  getCustomer(){
    this.httpclient.get('https://localhost:7133/api/Customer/GetAllCustomer').subscribe((cus) =>{
      this.onCusChange.next(cus);
    })
  }


  getSCustomer(){
    return this.httpclient.get<any[]>(this._baseURL + "/GetAllCustomer");
  }

  get1Customer(){
    return this.httpclient.get<any>(this._baseURL + "/GetCustomer?id=1");
  }

  deleteCustomer(data: any) {
    this.httpclient.delete('https://localhost:7133/api/Customer/DeleteCustomer?id=' + data.id)
      .subscribe((product) => {
        if (product) {
          this.onCusChange.next(product);
        }
      });
  }
}
