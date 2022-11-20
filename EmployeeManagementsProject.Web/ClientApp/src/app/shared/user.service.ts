import { Injectable } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { HttpClient, HttpHeaders  } from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private fb: FormBuilder, private http: HttpClient) { }

  formModel = this.fb.group({
    UserName: [''],
    Email: [''],
    FullName: [''],
    Passwords: this.fb.group({
      Password: [''],
      ConfirmPassword: ['']   
    })
  });
}
