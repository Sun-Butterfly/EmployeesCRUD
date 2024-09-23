import {Component, OnInit} from '@angular/core';
import {Router, RouterOutlet} from "@angular/router";

@Component({
  selector: 'app-layout',
  standalone: true,
  imports: [
    RouterOutlet
  ],
  templateUrl: './layout.component.html',
  styleUrl: './layout.component.scss'
})
export class LayoutComponent implements OnInit {
  title = 'CRUD сотрудников';

  url: string = '';

  constructor(private router: Router) {
  }

  goToAbout() {
    this.router.navigate(['about'])
  }

  goToEmployees() {
    this.router.navigate(['employees'])
  }

  ngOnInit(): void {
    this.url = this.router.url;
    this.router.events.subscribe(x => {
      this.url = this.router.url
    });
  }

}
