import { Injectable } from '@angular/core';


@Injectable({
  providedIn: 'root'
})
export class UserService {
employee=[];
  dateservice: any;

AddUser(Employee){
    this.employee.push(Employee);
   
  

}
getEmployee(){
  return this.employee;
  
  
}
//  getDate(){
//    let myDate = new Date();
//    console.log(this.dateservice.transform(myDate, 'yyyy-mm-dd'));
//    return this.dateservice;
//  }

  constructor(

  ) { }
}
