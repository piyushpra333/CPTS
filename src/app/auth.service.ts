import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Employee } from './Employee'
import { Observable,throwError } from 'rxjs';
import { catchError,retry } from 'rxjs/operators';
@Injectable({
  providedIn: 'root'
})
export class AuthService {
  apiURL: string = 'http://localhost:61230/api/CommonTasks/';
  httpOptions = {
    headers: new HttpHeaders({'Content-Type':'application/json'})
  }
  handleError(error: HttpErrorResponse) {
    if (error.error instanceof ErrorEvent) {
      console.error('An error occurred:', error.error.message);
    } else {
      console.error(
        'Backend returned code ${error.status}, ' +
        'body was: ${error.error}');
    }
    return throwError(
      'Something bad happened; please try again later.');
  };
  constructor(private httpClient:HttpClient) { }
  login (hero: Employee): Observable<any> {
    return this.httpClient.post<Employee>(this.apiURL, hero, this.httpOptions)
      .pipe(
        catchError(this.handleError)
      );
  }
}
