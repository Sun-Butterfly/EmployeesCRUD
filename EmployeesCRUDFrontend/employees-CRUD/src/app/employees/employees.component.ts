import {Component, inject, OnInit} from '@angular/core';
import {HttpService, Employee} from "../../http.service";
import {DatePipe, NgForOf} from "@angular/common";
import {MatDialog} from "@angular/material/dialog";
import {AddEmployeeDialogComponent} from "../add-employee-dialog/add-employee-dialog.component";
import {DeleteEmployeeDialogComponent} from "../delete-employee-dialog/delete-employee-dialog.component";
import {UpdateEmployeeDialogComponent} from "../update-employee-dialog/update-employee-dialog.component";


export interface DialogData {
  activeEmployeeId: number;
  employees: Employee[];
  activeEmployeeUpdate: Employee;
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
  paginatedEmployees: Employee[] = [];
  salary: number = 0;
  activeEmployee: number = -1;

  totalItems: number = 0;
  pageSize: number = 2;
  currentPage: number = 1;
  totalPages: number = 0;


  constructor(private http: HttpService) {
  }

  ngOnInit(): void {
    this.getPaginatedEmployees();
  }

  goToNextPage() {
    if (this.currentPage < this.totalPages) {
      this.currentPage++;
      this.getPaginatedEmployees();
    }
  }

  goToPreviousPage() {
    if (this.currentPage > 1) {
      this.currentPage--;
      this.getPaginatedEmployees();
    }
  }

  readonly dialog = inject(MatDialog);

  openAddDialog(): void {
    const dialog = this.dialog.open(AddEmployeeDialogComponent, {});

    dialog.afterClosed().subscribe(() => {
      this.getPaginatedEmployees();
    });
  }

  getSalary(id: number) {
    this.http.getSalary(id).subscribe(salary => {
      this.salary = salary
    })
  }

  openDeleteDialog(i: number) {
    const id = this.paginatedEmployees[i].id;
    const dialog = this.dialog.open(DeleteEmployeeDialogComponent, {
      data: {
        activeEmployeeId: id,
      }
    });

    dialog.afterClosed().subscribe((result) => {
      if (result) {
        this.http.deleteEmployee(id).subscribe(() => {
          this.getPaginatedEmployees();
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

  openUpdateDialog(i: number) {
    let employee = this.paginatedEmployees[i]
    const dialog = this.dialog.open(UpdateEmployeeDialogComponent, {
      data: {
        activeEmployeeUpdate: employee
      }
    });

    dialog.afterClosed().subscribe((result: { result: boolean, data: any }) => {
      if (result.result) {
        this.http.updateEmployee(result.data).subscribe(() => {
          this.getPaginatedEmployees();
        })
      }
    })
  }

  getPaginatedEmployees(){
    this.http.getPaginatedEmployees(this.currentPage, this.pageSize)
      .subscribe(response => {
        this.paginatedEmployees = response.paginatedEmployees;
        this.totalItems = response.totalCount;
        this.totalPages = Math.ceil(this.totalItems / this.pageSize)
      })
  }

}
