import { Component, OnInit } from '@angular/core';
import {UserService} from '../../user.service';
import {
  FormControl,
  FormGroup,
  Validators
} from '@angular/forms';


@Component({
  selector: 'app-user-data',
  templateUrl: './user-data.component.html',
  styleUrls: ['./user-data.component.css']
})
export class UserDataComponent implements OnInit {
  // EmployeeDetails =['EmpId','UserName','EmailId','Password','Role'];
   employees;
  constructor(private userservice:UserService) { 
   
  }
  autoRenew = new FormControl();
  onChange() {
    console.log(this.autoRenew.value);
  } 
  ngOnInit() {
    this.employees=this.userservice.getEmployee();
    console.log(this.employees);
  }

}
