import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Resolve, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DepartmentService implements Resolve<any> {

  // constructor(private h : ) { }
  constructor() { }

  resolve():Observable<any> | Promise<any> | any {
    
  }

  getDepartment(){
    console.log("load service");
  }
}
