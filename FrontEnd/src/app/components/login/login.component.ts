import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from "@angular/common/http";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  email: string = '';
  password: string = '';

  constructor(private httpClient: HttpClient) { }

  ngOnInit(): void {
  }

  // Corrected method name from 'obSubmit' to 'onSubmit'
  onSubmit(): void {
    const loginPayload = {
      email: this.email,
      password: this.password
    };


    this.httpClient.post('https://localhost:7294/Auth/login', loginPayload)
      .subscribe({
        next: (response: any) => {
          console.log(response);
          // TODO: Check if the response actually contains a token before trying to access it
          localStorage.setItem('token', response.token);
          // Redirect the user to another route if necessary
        },
        error: (error) => {
          console.error(error);
        }
      });
  }
}
