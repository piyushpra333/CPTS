import { BrowserModule } from '@angular/platform-browser';
import {UserService} from './user.service';


/* Routing */
import { AppRoutingModule } from './app-routing.module';

import { AppComponent } from './app.component';

/* Angular Material */
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AngularMaterialModule } from './angular-material.module';
import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';

/* */
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';



/* FormsModule */
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

/* Angular Flex Layout */
import { FlexLayoutModule } from "@angular/flex-layout";

/* Components */
import { LoginComponent } from './pages/login/login.component';
import { NewUserComponent } from './Admin/new-user/new-user.component';
import { UserDataComponent } from './Admin/user-data/user-data.component';



@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    NewUserComponent,
    UserDataComponent
  
    
    
    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    AngularMaterialModule,
    ReactiveFormsModule,
    FormsModule,
    FlexLayoutModule,
    NgbModule,
  
  ],
 
 
  providers: [UserService],
  bootstrap: [AppComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})

export class AppModule { }