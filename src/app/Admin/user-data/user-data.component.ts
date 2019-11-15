import { Component, OnInit , Input, ViewChild } from '@angular/core';
import {UserService} from '../../user.service';
import{Pipe} from '@angular/core';
@Pipe({
  name:'slice'
})




@Component({
  selector: 'app-user-data',
  templateUrl: './user-data.component.html',
  styleUrls: ['./user-data.component.css'],
  
})

export class UserDataComponent implements OnInit {
  // EmployeeDetails =['EmpId','UserName','EmailId','Password','Role'];

  // displayedColumns = ['EmployeeID', 'Name', 'UserName', 'Roles'];
status:any;
  employees;
  searchText;
  Roles:any=["Admin","Trainer","Trainee"];
  Role;
  

  @Input()
  checked:boolean
  disabled:boolean
 
 getStatus(id, isActive, Role){

  console.log(id);
  console.log(isActive);
  console.log(Role);
 }
 applyFilter(searchtext: any) {
  searchtext = searchtext.trim();
  searchtext = searchtext.toLowerCase();
  this.employees.UserName = searchtext;
}
getPaginatorData(){

}
 


  constructor(private userservice:UserService) { 
   
  }
 
  ngOnInit() {
    this.employees=this.userservice.getEmployee();
    console.log(this.employees);
   
    
    
    
  }

}
