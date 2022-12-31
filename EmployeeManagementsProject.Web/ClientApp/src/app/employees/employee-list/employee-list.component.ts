import { Component, OnInit } from '@angular/core';
import { EmployeeService } from 'src/app/shared/employee.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styles: []
})
export class EmployeeListComponent implements OnInit {

  constructor(private service: EmployeeService, private toastr: ToastrService
    ) { }

  ngOnInit() {
    this.service.refreshList();
  }

  populateForm(emp) {
    let SerializedEmp = {
      Id: emp.id,
      FullName: emp.fullName,
      Position: emp.position,
      EMPCode: emp.empCode,
      Mobile: emp.mobile,
      ImgPath : emp.imgPath
    }
    this.service.formData = Object.assign({}, SerializedEmp);
  }

  onDelete(id: number) {
    if (confirm('Are you sure to delete this record?')) {
      this.service.deleteEmployee(id).subscribe(res => {
        this.service.refreshList();
        this.toastr.warning('Deleted successfully', 'EMP. Register');
      });
    }
  }

  onExport()
  {
    this.service.ExportEmployees();
  }

  public createImgPath = (serverPath: string) => { 
    return `https://localhost:44374/${serverPath}`; 
  }

}
