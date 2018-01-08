import { Component, OnInit } from '@angular/core';
import {Router} from '@angular/router';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  constructor(private router: Router) { }

  ngOnInit() {
  }

  goHome() {
    this.router.navigate(['posts']);
  }

  createPost() {
    this.router.navigate(['posts', 'create-post']);
  }

  checkIfMain() {
    return this.router.url === '/posts';
  }

  goBack() {
    window.history.back();
  }
}
