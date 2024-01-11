import { Injectable } from '@angular/core';
import {Router} from "@angular/router";

@Injectable({
  providedIn: 'root'
})
export class AuthGuardService {

  constructor(private router: Router) { }

  canActivate(): boolean {
    if (localStorage.getItem('token')) {
      // Token exists, so the user is logged in
      return true;
    } else {
      // No token, redirect to login page
      this.router.navigate(['/login']);
      return false;
    }
  }
}
