import { Component, OnInit } from '@angular/core';
import { EmployeeService } from 'src/app/shared/employee.service';
import { Employee } from 'src/app/shared/employee.model';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styles: []
})
export class EmployeeListComponent implements OnInit {

  constructor(private service: EmployeeService
    ) { }

  ngOnInit() {
    this.service.refreshList();
  }

  populateForm(emp: Employee) {
    this.service.formData = Object.assign({}, emp);
  }

}
