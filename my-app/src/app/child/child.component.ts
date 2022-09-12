import { Component, OnInit } from '@angular/core';
import { Output, EventEmitter } from '@angular/core';
import { Route, Router } from '@angular/router';


@Component({
  selector: 'app-child',
  templateUrl: './child.component.html',
  styleUrls: ['./child.component.scss']
})
export class ChildComponent implements OnInit {
  @Output() newItemEvent = new EventEmitter<string>();

  constructor(private router : Router) { }
  addNewItem(value: string) {
    this.newItemEvent.emit(value);
  }

  studentClick(){
    this.router.navigate(['/student']);
  }

  gradeClick(){
    this.router.navigate(['/grade']);
  }
 
  customerClick(){
    this.router.navigate(['/customer']);
  }



  ngOnInit(): void {
  }

}
