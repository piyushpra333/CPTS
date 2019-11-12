import { Injectable } from '@angular/core';


@Injectable({
  providedIn: 'root'
})
export class UserService {
employee=[];

AddUser(Employee){
    this.employee.push(Employee);

}
getEmployee(){
  return this.employee;
}


  constructor(

  ) { }
}
