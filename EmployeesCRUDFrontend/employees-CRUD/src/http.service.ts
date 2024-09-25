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

@Injectable({providedIn: "root"})
export class HttpService{

  constructor(private http: HttpClient) {
  }

  baseurl: string = "http://localhost:5208"

  getAllEmployees():Observable<Employee[]>{
    const url: string = `${this.baseurl}/Employee/GetAllEmployees`
    return this.http.get<Employee[]>(url)
  }

  getSalary(id: number): Observable<number> {
    const url: string = `${this.baseurl}/Employee/GetSalary`
    return this.http.get<number>(url,{
      params: {
        id: id
      }})
  }
}

