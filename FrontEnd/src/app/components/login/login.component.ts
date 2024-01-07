import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from "@angular/common/http";
import {Router} from "@angular/router";

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

  constructor(
    private httpClient: HttpClient,
    private router: Router) { }

  ngOnInit(): void {
  }

  onSubmit(): void {
    const loginPayload = {
      email: this.email,
      password: this.password,
      userId: this.userId
    };


    this.httpClient.post('https://localhost:7294/Auth/login', loginPayload)
      .subscribe({
        next: (response: any) => {
          console.log(response);
          if(response.token){
            localStorage.setItem('token', response.token);
            localStorage.setItem('role', response.role);
            localStorage.setItem('userId', response.userId);
            this.router.navigate(['/home']);
          } else {
            this.errorMessage = 'Login failed. Please try again.';
          }
        },
        error: (error) => {
          console.error(error);
          this.errorMessage = 'Login failed. Please check your credentials.';
        }
      });
  }
}
