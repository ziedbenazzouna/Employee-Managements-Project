import { Injectable } from '@angular/core';
import { Employee } from './employee.model';
import { HttpClient, HttpHeaders } from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  formData : Employee;
  list : Employee[];
  readonly rootURL  = 'https://localhost:44374/api';
  constructor(private http : HttpClient) { }
  

  postEmployee(formData : Employee){
    if (formData.Id == null)
    {
      formData.Id = 0;
    }
    return this.http.post(this.rootURL +"/employee" ,formData);
   }

   refreshList(){
    this.http.get(this.rootURL+'/employee')
    .toPromise().then(res => this.list = res as Employee[]);
  }

  deleteEmployee(id : number){
    return this.http.delete(this.rootURL+'/employee?id='+id);
   }

}
