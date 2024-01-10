import { Component, OnInit } from '@angular/core';
import {Router} from "@angular/router";

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  constructor(private router: Router) { }

  ngOnInit(): void {
  }

  goToOwnedReservations(): void {
    const customerId = localStorage.getItem('userId');
    if(customerId)
      this.router.navigate(['ownedReservations', customerId]);
  }

  logOut(): void {
    localStorage.clear();
  }

}
