import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";

export interface Employee {
  id: number,
  name: string,
  secondName: string,
  lastName: string,
  dateOfBirth: Date,
  dateOfEmployment: Date,
  departmentName: string,
  jobTitle: string,
  salary: number
}

export interface Department {
  id: number,
  name: string
}

export enum JobTitles {
  Junior = 'Junior',
  Middle = 'Middle',
  Senior = 'Senior',
  TechLead = 'TechLead',
  TeamLead = 'TeamLead',
}

@Injectable({providedIn: "root"})
export class HttpService {

  constructor(private http: HttpClient) {
  }

  baseurl: string = "http://localhost:5208"

  getAllEmployees(): Observable<Employee[]> {
    const url: string = `${this.baseurl}/Employee/GetAllEmployees`
    return this.http.get<Employee[]>(url)
  }

  getSalary(id: number): Observable<number> {
    const url: string = `${this.baseurl}/Employee/GetSalary`
    return this.http.get<number>(url, {
      params: {
        id: id
      }
    })
  }

  getAllDepartments(): Observable<Department[]> {
    const url: string = `${this.baseurl}/Department/GetAllDepartments`
    return this.http.get<Department[]>(url)
  }

  addEmployee(employee: Employee): Observable<void> {
    const url: string = `${this.baseurl}/Employee/AddEmployee`;
    return this.http.post<void>(url, employee);
  }

  deleteEmployee(id: number): Observable<void> {
    const url: string = `${this.baseurl}/Employee/DeleteEmployee`
    return this.http.delete<void>(url, {
      params: {
        employeeId: id
      }
    });

  }

  updateEmployee(employee: Employee): Observable<void> {
    const url: string = `${this.baseurl}/Employee/UpdateEmployee`;
    return this.http.post<void>(url, employee)

  }
}

