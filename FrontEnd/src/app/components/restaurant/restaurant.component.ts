import { Component, OnInit } from '@angular/core';
import {RestaurantService} from "../../services/restaurant.service";
import {ActivatedRoute} from "@angular/router";
import {Restaurant} from "../../Models/Restaurant";

@Component({
  selector: 'app-restaurant',
  templateUrl: './restaurant.component.html',
  styleUrls: ['./restaurant.component.css']
})
export class RestaurantComponent implements OnInit {
  restaurant: Restaurant | undefined;

  constructor(
    private restaurantService: RestaurantService,
    private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      const id = params['id'];
      this.restaurantService.getRestaurantById(id).subscribe({
        next: (data) => {this.restaurant = data; console.log(data); },
        error: (error) => console.error('There was an error!', error)
      });
    });

  }

}
