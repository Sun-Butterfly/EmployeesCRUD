import {Component, OnInit} from '@angular/core';
import {HttpService, Employee} from "../../http.service";
import {DatePipe, NgForOf} from "@angular/common";

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
    this.http.getAllEmployees().subscribe(employees =>
    {this.employees = employees});

  }


  getSalary(id: number) {
    this.http.getSalary(id).subscribe(salary => {this.salary = salary})
  }
}
