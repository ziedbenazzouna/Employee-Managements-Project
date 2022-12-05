import { Component, OnInit } from '@angular/core';
import { EmployeeService } from 'src/app/shared/employee.service';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styles: []
})
export class EmployeeComponent implements OnInit {

  constructor(private service : EmployeeService) { }


  ngOnInit() {
    this.resetForm();
  }

  resetForm(form?: NgForm) {
    if (form != null)
      form.resetForm();
    this.service.formData = {
      Id: null,
      FullName: '',
      Position: '',
      EMPCode: '',
      Mobile: ''
    }
  }

  onSubmit(form: NgForm) {    
      this.insertRecord(form);    
  }

  insertRecord(form: NgForm) {
    console.log(form)
    this.service.postEmployee(form.value).subscribe(res => {
      this.resetForm(form);
    });
  }
}
