import { Injectable } from '@angular/core';
import { Employee } from './employee.model';
import { HttpClient, HttpHeaders } from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  formData : Employee;
  constructor(private http : HttpClient) { }
  readonly rootURL  = 'https://localhost:44374/api';

  postEmployee(formData : Employee){
    console.log(formData)
    formData.Id = 0;
    // const reqHeader=  new HttpHeaders().set('Content-Type', 'application/json').set('Accept', 'application/json')
    return this.http.post(this.rootURL +"/employee" ,formData);
   }
}
