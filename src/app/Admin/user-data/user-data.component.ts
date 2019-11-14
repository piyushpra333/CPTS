import { Component, OnInit , Input } from '@angular/core';
import {UserService} from '../../user.service';



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
 
 getStatus(id){
  console.log(this.status);
  console.log(this.Role);
  console.log(id);
 }
 applyFilter(searchtext: any) {
  searchtext = searchtext.trim();
  searchtext = searchtext.toLowerCase();
  this.employees.UserName = searchtext;
}
 
  // @ViewChild (MatPaginator) paginator: MatPaginator;

  // ngAfterViewInit() {
  //   this.dataSource.paginator = this.paginator;
  // }
  constructor(private userservice:UserService) { 
   
  }
  
  ngOnInit() {
    this.employees=this.userservice.getEmployee();
    console.log(this.employees);
    
    
    
  }

}
