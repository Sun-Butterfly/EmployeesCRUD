import {Component, inject, OnInit} from '@angular/core';
import {HttpService, Employee} from "../../http.service";
import {DatePipe, NgForOf} from "@angular/common";
import {MatDialog} from "@angular/material/dialog";
import {AddEmployeeDialogComponent} from "../add-employee-dialog/add-employee-dialog.component";
import {DeleteEmployeeDialogComponent} from "../delete-employee-dialog/delete-employee-dialog.component";


export interface DialogData {
  activeEmployeeId: number;
  employees: Employee[];
}

@Component({
  selector: 'app-employees',
  standalone: true,
  imports: [
    NgForOf,
    DatePipe
  ],
  templateUrl: './employees.component.html',
  styleUrl: './employees.component.scss'
})
export class EmployeesComponent implements OnInit {
  title: string = 'Сотрудники';
  employees: Employee[] = [];
  salary: number = 0;
  activeEmployee: number = -1;

  constructor(private http: HttpService) {
  }

  ngOnInit(): void {
    this.http.getAllEmployees().subscribe(employees => {
      this.employees = employees
    });

  }

  readonly dialog = inject(MatDialog);

  openAddDialog(): void {
    const dialog = this.dialog.open(AddEmployeeDialogComponent, {});

    dialog.afterClosed().subscribe(() => {
      this.http.getAllEmployees().subscribe(employees => {
        this.employees = employees
      });
    });
  }

  getSalary(id: number) {
    this.http.getSalary(id).subscribe(salary => {
      this.salary = salary
    })
  }

  openDeleteDialog(i: number) {
    const id = this.employees[i].id;
    const dialog = this.dialog.open(DeleteEmployeeDialogComponent, {
      data: {
        activeEmployeeId: id,
      }
    });

    dialog.afterClosed().subscribe((result) => {
      if (result) {
        this.http.deleteEmployee(id).subscribe(() => {
          this.employees = this.employees.filter(x => x.id !== id);
        })
      }
    })
  }

  setActiveEmployee(i: number) {
    if (this.activeEmployee === i) {
      this.activeEmployee = -1;
    } else {
      this.activeEmployee = i;
    }
  }
}
