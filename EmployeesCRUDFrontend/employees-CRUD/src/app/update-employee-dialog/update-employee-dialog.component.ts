import {Component, inject, OnInit} from '@angular/core';
import {formatDate, NgForOf, NgIf} from "@angular/common";
import {AbstractControl, FormControl, FormGroup, ReactiveFormsModule, Validators} from "@angular/forms";
import {HttpService} from "../../http.service";
import {MAT_DIALOG_DATA, MatDialogRef} from "@angular/material/dialog";
import {DialogData} from "../employees/employees.component";

@Component({
  selector: 'app-update-employee-dialog',
  standalone: true,
  imports: [
    NgForOf,
    ReactiveFormsModule,
    NgIf
  ],
  templateUrl: './update-employee-dialog.component.html',
  styleUrl: './update-employee-dialog.component.scss'
})
export class UpdateEmployeeDialogComponent implements OnInit {
  title: string = "Редактирование личных данных";
  updateEmployeeFormGroup: FormGroup;
  readonly dialogRef = inject(MatDialogRef<UpdateEmployeeDialogComponent>);
  readonly data = inject<DialogData>(MAT_DIALOG_DATA);

  constructor(private http: HttpService) {
    this.updateEmployeeFormGroup = new FormGroup({
      id: new FormControl(null),
      name: new FormControl(null, [Validators.required, Validators.minLength(3)]),
      secondName: new FormControl(null, [Validators.required, Validators.minLength(3)]),
      lastName: new FormControl(null, [Validators.required,Validators.minLength(3)]),
      dateOfBirth: new FormControl(null, [Validators.required, this.validateDateOfBirth])
    });
  }

  ngOnInit(): void {
    this.updateEmployeeFormGroup.patchValue({
      ...this.data.activeEmployeeUpdate,
      dateOfBirth: formatDate(new Date(this.data.activeEmployeeUpdate.dateOfBirth), 'yyyy-MM-dd', 'en')})
  }

  updateEmployee() {
    const newData = {
      ...this.data,
      ...this.updateEmployeeFormGroup.value
    };

    this.dialogRef.close({result: true, data: newData});
  }

  onCancelClick() {
    this.dialogRef.close({result: false});
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
}
