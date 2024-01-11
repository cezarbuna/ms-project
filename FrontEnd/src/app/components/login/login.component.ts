import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from "@angular/common/http";
import {NavigationEnd, Router} from "@angular/router";
import {filter, Observable} from "rxjs";
import {AuthService} from "../../services/auth.service";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  email: string = '';
  password: string = '';
  userId: string = '';
  errorMessage: string = '';
  obs: Observable<any> | undefined;

  constructor(
    private httpClient: HttpClient,
    private router: Router,
    private authService: AuthService) { }

  ngOnInit(): void {
  }

  onSubmit(): void {
    const loginPayload = {
      email: this.email,
      password: this.password,
      userId: this.userId
    };

    this.authService.login(loginPayload).subscribe({
      next: (response: any) => {
              console.log(response);
              if(response.token){
                localStorage.setItem('token', response.token);
                localStorage.setItem('role', response.role);
                localStorage.setItem('userId', response.userId);
                this.router.navigate(['/home']).then(() => {
                  this.router.events
                    .pipe(filter(event => event instanceof NavigationEnd))
                    .subscribe(() => {
                      console.log('RELOADED')
                      // window.location.reload();
                    })
                });

              } else {
                this.errorMessage = 'Login failed. Please try again.';
              }
            },
            error: (error) => {
              console.error(error);
              this.errorMessage = 'Login failed. Please check your credentials.';
            }
    })
  }
}
