import { Component, OnInit } from '@angular/core';
import {RestaurantService} from "../../services/restaurant.service";
import {Restaurant} from "../../Models/Restaurant";
import {Router} from "@angular/router";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  restaurants: Restaurant[] = [];

  constructor(
    private restaurantService: RestaurantService,
    private router: Router) { }

  ngOnInit(): void {
    this.restaurantService.getAllRestaurants().subscribe({
      next: (data) => {
        this.restaurants = data;
      },
      error: (error) => {
        console.error('There was an error!', error);
      }
    });
  }
  viewDetails(restaurantId: string): void {
    this.router.navigate(['/restaurant', restaurantId]);
  }

}
