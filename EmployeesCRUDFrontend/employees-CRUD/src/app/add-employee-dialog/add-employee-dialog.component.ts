import {Component, inject, OnInit} from '@angular/core';
import {AbstractControl, FormControl, FormGroup, ReactiveFormsModule, Validators} from "@angular/forms";
import {Department, HttpService, JobTitles} from "../../http.service";
import {NgForOf, NgIf} from "@angular/common";
import {MatDialogRef} from "@angular/material/dialog";

@Component({
  selector: 'app-add-employee-dialog',
  standalone: true,
  imports: [NgForOf, ReactiveFormsModule, NgIf],
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
  title: string = "Создание сотрудника";

  constructor(private http: HttpService) {
    this.employeeFormGroup = new FormGroup({
      name: new FormControl(null, [Validators.required, Validators.minLength(3)]),
      secondName: new FormControl(null, [Validators.required, Validators.minLength(3)]),
      lastName: new FormControl(null, [Validators.required, Validators.minLength(3)]),
      dateOfBirth: new FormControl(null, [Validators.required, this.validateDateOfBirth]),
      dateOfEmployment: new FormControl(null, [Validators.required, this.validateDateOfEmployment]),
      jobTitle: new FormControl(null, [Validators.required]),
      departmentName: new FormControl(null, [Validators.required,Validators.minLength(3)])
    })

  }

  ngOnInit(): void {
    this.http.getAllDepartments().subscribe(departments =>
      this.departments = departments);
  }

  addEmployee() {
    if(this.employeeFormGroup.invalid){
      alert('Ты еблан')
      return;
    }
    let value = this.employeeFormGroup.value;
    this.http.addEmployee(value).subscribe(() => {
      alert('Успешно добавлено')
      this.dialogRef.close();
    })
  }

  onCancelClick() {
    this.dialogRef.close();
  }

  validateDateOfBirth(control: AbstractControl) {
    const value = control.value;
    let minDate: Date = new Date();
    minDate.setFullYear(minDate.getFullYear()-18);
    if (value == null || value == '' || value > (minDate.toISOString().split('T')[0])) {
      return { validateDateOfBirth: true };
    } else {
      return null;
    }
  }

  validateDateOfEmployment(control: AbstractControl) {
    const value = control.value;
    let minDate: Date = new Date();
    if (value == null || value == '' || value > (minDate.toISOString().split('T')[0])) {
      return { validateDateOfEmployment: true };
    } else {
      return null;
    }
  }
}
