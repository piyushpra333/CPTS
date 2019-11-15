import {
  Component,
  OnInit,
  NgModule
} from '@angular/core';
import { Employee } from '../../Employee';
import {
  FormControl,
  FormGroup,
  Validators
} from '@angular/forms';
import{Router} from '@angular/router';
import { AuthService } from '../../auth.service';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})

export class LoginComponent implements OnInit {
myForm:FormGroup;


  constructor( private router:Router,private authService:AuthService) {}
  emp:any = new Employee();
  ngOnInit() {
   this.myForm = new FormGroup({
      uname: new FormControl('', Validators.required),
      pwd: new FormControl('', Validators.required),
    });

  }
  onSubmit() {
    console.warn(this.myForm.value);
    this.emp.uname= this.myForm.value.uname;
    this.emp.pwd= this.myForm.value.pwd;
    this.authService.login(this.emp).subscribe((res)=>{
      console.log(res);
    })
    // this.router.navigate(['new-user']);
  }
}
