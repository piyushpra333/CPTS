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

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})

export class LoginComponent implements OnInit {
myForm:FormGroup;


  constructor( private router:Router) {}

  ngOnInit() {
   this.myForm = new FormGroup({
      uname: new FormControl('', Validators.required),
      pwd: new FormControl('', Validators.required),
    });

  }
  onSubmit() {
    console.warn(this.myForm.value);
    this.router.navigate(['new-user']);
  }
}
