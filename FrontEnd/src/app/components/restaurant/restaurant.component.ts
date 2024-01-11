import { Component, OnInit } from '@angular/core';
import {RestaurantService} from "../../services/restaurant.service";
import {ActivatedRoute, Router} from "@angular/router";
import {Restaurant} from "../../Models/Restaurant";
import {MenuService} from "../../services/menu.service";
import {switchMap} from "rxjs";
import {Menu} from "../../Models/Menu";
import {MenuItem} from "../../Models/MenuItem";

@Component({
  selector: 'app-restaurant',
  templateUrl: './restaurant.component.html',
  styleUrls: ['./restaurant.component.css']
})
export class RestaurantComponent implements OnInit {
  serverUrl: string = 'https://localhost:7294';
  restaurant: Restaurant | undefined;
  menu: Menu | undefined;
  menuItems: MenuItem[] | undefined;
  menuVisible: boolean = false;
  userId: string | null | undefined ;

  constructor(
    private restaurantService: RestaurantService,
    private route: ActivatedRoute,
    private menuService: MenuService,
    private router: Router) { }

  ngOnInit(): void {
    this.userId = localStorage.getItem('userId');
    this.route.params.pipe(
      switchMap(params => {
        const id = params['id'];
        return this.restaurantService.getRestaurantById(id);
      })
    ).subscribe({
      next: (restaurant) => {
        this.restaurant = restaurant;
        this.menuService.getMenuItemsByRestaurantId(restaurant.id).subscribe(res => {
          this.menuItems = res;
          console.log(this.menuItems);
        })
        console.log(this.restaurant);
      },
      error: (error) => console.error('There was an error!', error)
    });

  }

  switchMenuVisibility(): void {
    console.log('TOGGLED');
    this.menuVisible = !this.menuVisible;
  }

  goToTableView(restaurantId: string){
    console.log(this.restaurant);
    this.router.navigate(['/viewTables',restaurantId]);
  }

}
