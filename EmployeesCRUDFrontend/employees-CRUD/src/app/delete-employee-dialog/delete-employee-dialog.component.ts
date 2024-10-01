import {Component, inject} from '@angular/core';
import {MAT_DIALOG_DATA, MatDialogRef} from "@angular/material/dialog";
import {HttpService} from "../../http.service";
import {DialogData} from "../employees/employees.component";

@Component({
  selector: 'app-delete-employee-dialog',
  standalone: true,
  imports: [],
  templateUrl: './delete-employee-dialog.component.html',
  styleUrl: './delete-employee-dialog.component.scss'
})
export class DeleteEmployeeDialogComponent {
  title: string = "Вы действительно хотите удалить сотрудника?";
  readonly dialogRef = inject(MatDialogRef<DeleteEmployeeDialogComponent>);
  readonly data = inject<DialogData>(MAT_DIALOG_DATA);

  constructor(private http: HttpService) {
  }

  onDeleteClick() {
    this.dialogRef.close(true);
  }

  onCancelClick() {
    this.dialogRef.close(false);
  }
}
