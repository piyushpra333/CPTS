import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './pages/login/login.component';
import { NewUserComponent } from './Admin/new-user/new-user.component';
import { UserDataComponent } from './Admin/user-data/user-data.component';



const routes: Routes = [
  {
    path:'',pathMatch:'full',redirectTo:'login'
  },
  {
    path:'login', component:LoginComponent
  },
  {
    path:'new-user', component:NewUserComponent
  },
  {
    path:'user-data', component:UserDataComponent
  }
 
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
