import { Component, OnInit } from '@angular/core';
import { EmployeeService } from 'src/app/shared/employee.service';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styles: []
})
export class EmployeeComponent implements OnInit {
  public response: {dbPath: ''}
  constructor(private service : EmployeeService, private toastr : ToastrService) { }


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
      Mobile: '',
      ImgPath :'Resources\\Images\\default-image.jpg'
    }
  }

  onSubmit(form: NgForm) {    
    if (form.value.Id == null)
    {
      this.insertRecord(form)
    }
  else
    this.updateRecord(form); 
  }

  insertRecord(form: NgForm) {
    
    form.value.ImgPath = this.response != undefined ? this.response.dbPath : 'Resources\\Images\\default-image.jpg';
    this.service.postEmployee(form.value).subscribe(res => {
      this.toastr.success('Inserted successfully', 'Employee. Register');
      this.resetForm(form);
      this.service.refreshList();
    });
  }

  updateRecord(form: NgForm) {
    console.log(this.response);
    form.value.ImgPath = this.response != undefined ? this.response.dbPath : 'Resources\\Images\\default-image.jpg';
    this.service.postEmployee(form.value).subscribe(res => {
      this.toastr.info('Updated successfully', 'Employee. Register');
      this.resetForm(form);
      this.service.refreshList();
    });

  }

  uploadFinished = (event) => { 
    this.response = event; 
  }
}
