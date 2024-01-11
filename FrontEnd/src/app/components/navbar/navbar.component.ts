import {Component, HostBinding, HostListener, OnInit} from '@angular/core';
import {Router} from "@angular/router";

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {
  customerId: string | undefined | null;
  // isLoggedIn: boolean = false;

  constructor(
    private router: Router
  ) { }

  ngOnInit(): void {
    const customerId = localStorage.getItem('userId');
    this.customerId = customerId;
  }

  isLoggedIn(): boolean {
    if(this.customerId)
      return true;
    return false;
  }

  myFunction(): void {
    let x = document.getElementById("myLinks");
    if(x){
      if (x.style.display === "block") {
        x.style.display = "none";
      } else {
        x.style.display = "block";
      }
    }
  }

  goToOwnedReservations(): void {
    if(this.customerId)
      this.router.navigate(['ownedReservations', this.customerId]);
    else
      console.log('Fuck');
  }



  logOut(): void {
    localStorage.clear();
    this.router.navigate(['home']).then(() => {
      window.location.reload();
    });
  }

}
