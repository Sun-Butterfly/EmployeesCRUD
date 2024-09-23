import { Routes } from '@angular/router';
import {LayoutComponent} from "./layout/layout.component";
import {AboutCompanyComponent} from "./about-company/about-company.component";
import {EmployeesComponent} from "./employees/employees.component";

export const routes: Routes = [
  {
    path: '',
    component: LayoutComponent,
    children: [
      {
        path: 'about',
        component: AboutCompanyComponent
      },
      {
        path: 'employees',
        component: EmployeesComponent
      },
      {
        path: '**',
        redirectTo: 'about'
      }
    ]
  }
];
