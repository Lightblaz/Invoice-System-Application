import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Resolve, RouterStateSnapshot } from '@angular/router';
import { Observable, Subject } from 'rxjs';
import {HttpClient} from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  _baseURL : String = "https://localhost:7133/api/Product";
  onCusChange = new Subject();

  constructor(private httpclient : HttpClient) { }

  addproduct(prod : any){
    return this.httpclient.post(this._baseURL + "/AddProduct" , prod);
  }

}
