import {Component, inject, OnInit} from '@angular/core';
import {FormControl, FormGroup, ReactiveFormsModule, Validators} from "@angular/forms";
import {Department, HttpService, JobTitles} from "../../http.service";
import {NgForOf} from "@angular/common";
import {MatDialogRef} from "@angular/material/dialog";

@Component({
  selector: 'app-add-employee-dialog',
  standalone: true,
  imports: [NgForOf, ReactiveFormsModule],
  templateUrl: './add-employee-dialog.component.html',
  styleUrl: './add-employee-dialog.component.scss'
})
export class AddEmployeeDialogComponent implements OnInit {

  jobTitles: string[] = [
    JobTitles.Junior,
    JobTitles.Middle,
    JobTitles.Senior,
    JobTitles.TechLead,
    JobTitles.TeamLead,
  ];
  departments: Department[] = [];
  employeeFormGroup: FormGroup;
  readonly dialogRef = inject(MatDialogRef<AddEmployeeDialogComponent>);

  constructor(private http: HttpService) {
    this.employeeFormGroup = new FormGroup({
      name: new FormControl(null, [Validators.required]),
      secondName: new FormControl(null, [Validators.required]),
      lastName: new FormControl(null, [Validators.required]),
      dateOfBirth: new FormControl(null, [Validators.required]),
      dateOfEmployment: new FormControl(null, [Validators.required]),
      jobTitle: new FormControl(null, [Validators.required]),
      departmentName: new FormControl(null, [Validators.required])
    })
  }

  ngOnInit(): void {
    this.http.getAllDepartments().subscribe(departments =>
      this.departments = departments);
  }

  addEmployee() {
    let value = this.employeeFormGroup.value;
    this.http.addEmployee(value).subscribe(() => {
      alert('Успешно добавлено')
      this.dialogRef.close();
    })
  }

  onCancelClick() {
    this.dialogRef.close();
  }
}
