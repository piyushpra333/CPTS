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
import{Router} from '@angular/router';

import {UserService} from '../../user.service';

import {Employee} from 'src/app/Employee';



@Component({
  selector: 'app-new-user',
  templateUrl: './new-user.component.html',
  styleUrls: ['./new-user.component.css']
})

export class NewUserComponent implements OnInit{
  user;
  employees;
  selected;
  public isCollapsed = true;
  Roles:any=["Admin","Trainer","Trainee"];
  myForm: FormGroup;
  constructor(
    
   private userservice:UserService,
   private router:Router
  ) { }


  ngOnInit() {
    this.myForm = new FormGroup({
      empId: new FormControl('', Validators.required),
      name: new FormControl('',Validators.required),
      uname: new FormControl('', Validators.required),
      pwd: new FormControl('', Validators.required),
      role: new FormControl('', Validators.required),
    
    });

    
  }
onSubmit(){
  
  console.warn(this.myForm.value);
  this.userservice.AddUser(this.myForm.value);
  this.employees=this.userservice.getEmployee();
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
