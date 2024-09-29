import {Component, inject, OnInit} from '@angular/core';
import {HttpService, Employee} from "../../http.service";
import {DatePipe, NgForOf} from "@angular/common";
import {MatDialog} from "@angular/material/dialog";
import {AddEmployeeDialogComponent} from "../add-employee-dialog/add-employee-dialog.component";

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

  constructor(private http: HttpService) {
  }

  ngOnInit(): void {
    this.http.getAllEmployees().subscribe(employees => {
      this.employees = employees
    });

  }

  readonly dialog = inject(MatDialog);

  openDialog(): void {
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
}
