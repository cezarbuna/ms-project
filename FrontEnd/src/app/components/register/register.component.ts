import { Component, OnInit } from '@angular/core';
import {CustomerService} from "../../services/customer.service";
import {NavigationEnd, Router} from "@angular/router";
import {filter} from "rxjs";

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  email: string | undefined;
  password: string | undefined;
  fullName: string | undefined;
  username: string | undefined;
  age: number | undefined;
  errorMessage: string = '';

  constructor(
    private customerService: CustomerService,
    private router: Router
  ) { }

  ngOnInit(): void {
  }

  onSubmit(): void {
    const customerInfo = {
      email: this.email,
      password: this.password,
      fullName: this.fullName,
      username: this.username,
      age: this.age
    };

    this.customerService.register(customerInfo).subscribe({
      next: (res: any) => {
        console.log(res);
        this.router.navigate(['login']);
      },
      error: (error) => {
        console.log(error);
        this.errorMessage = 'Registration failed. Please try again.';
      }
    })

    // this.authService.login(loginPayload).subscribe({
    //   next: (response: any) => {
    //     console.log(response);
    //     if(response.token){
    //       localStorage.setItem('token', response.token);
    //       localStorage.setItem('role', response.role);
    //       localStorage.setItem('userId', response.userId);
    //       this.router.navigate(['/home']).then(() => {
    //         this.router.events
    //           .pipe(filter(event => event instanceof NavigationEnd))
    //           .subscribe(() => {
    //             console.log('RELOADED')
    //             // window.location.reload();
    //           })
    //       });
    //
    //     } else {
    //       this.errorMessage = 'Login failed. Please try again.';
    //     }
    //   },
    //   error: (error) => {
    //     console.error(error);
    //     this.errorMessage = 'Login failed. Please check your credentials.';
    //   }
    // })

  }

}
