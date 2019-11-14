import {
  Component,
  OnInit,
  NgModule
} from '@angular/core';
import {
  FormControl,
  FormGroup,
  Validators
} from '@angular/forms';
import {
  Router
} from '@angular/router';


import {
  UserService
} from '../../user.service';

import {
  Employee
} from 'src/app/Employee';
import {
  DatePipe
} from '@angular/common';



@Component({
  selector: 'app-new-user',
  templateUrl: './new-user.component.html',
  styleUrls: ['./new-user.component.css']
})

export class NewUserComponent implements OnInit {
  user;
  employees;
  selected;
  createddate;
  public isCollapsed = true;
  Roles: any = ["Admin", "Trainer", "Trainee"];
  myForm: FormGroup;
  constructor(

    private userservice: UserService,
    private router: Router,
    public dateservice: DatePipe,
  ) {}

  ngOnInit() {
    this.myForm = new FormGroup({
      empId: new FormControl('', Validators.required),
      name: new FormControl('', Validators.required),
      uname: new FormControl('', Validators.required),
      pwd: new FormControl('', Validators.required),
      role: new FormControl('', Validators.required),

    });




  }
  onSubmit() {
    let myDate = new Date();
 this.dateservice.transform(myDate, 'yyyy-mm-dd');
    let emp = new Employee();
    {

      emp.empId=this.myForm.value.empId;
      emp.name=this.myForm.value.name;
      emp.uname=this.myForm.value.uname;
      emp.pwd=this.myForm.value.pwd;
     emp.CreatedDate = myDate;
     
     
     

       emp.isActive = true;
      emp.Role = this.myForm.value.role;
    
    }
  
    console.warn(this.myForm.value);
  
    this.userservice.AddUser(emp);
    this.employees = this.userservice.getEmployee();
    console.log(this.employees);
    this.myForm.reset();

    // this.router.navigate(['/user-data']);
  }

  // applyFilter(searchtext: any) {
  //   searchtext = searchtext.trim();
  //   searchtext = searchtext.toLowerCase();
  //   this.employees.name = searchtext;
  // }



}
