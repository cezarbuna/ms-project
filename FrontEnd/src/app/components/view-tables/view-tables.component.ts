import { Component, OnInit } from '@angular/core';
import {ActivatedRoute, Router} from "@angular/router";
import {TableService} from "../../services/table.service";
import {Table} from "../../Models/Table";
import {switchMap} from "rxjs";
import {RestaurantService} from "../../services/restaurant.service";

@Component({
  selector: 'app-view-tables',
  templateUrl: './view-tables.component.html',
  styleUrls: ['./view-tables.component.css']
})
export class ViewTablesComponent implements OnInit {
  restaurantId: string | undefined;
  tables: Table[] | undefined;
  userId: string | undefined | null;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private tableService: TableService,
    private restaurantService: RestaurantService) { }

  ngOnInit(): void {
    this.userId = localStorage.getItem('userId');
    this.route.params.pipe(
      switchMap(params => {
        const restaurantId = params['restaurantId'];
        return this.restaurantService.getRestaurantById(restaurantId);
      })
    ).subscribe({
      next: (restaurant ) => {
        this.tableService.getAllTablesForRestaurant(restaurant.id).subscribe(res => {
          this.tables = res;
          console.log(this.tables);
        })
      },
      error: (error) => console.error('There was an error!', error)
    })
  }

  bookTable(tableId: string): void {
    if (this.userId) {
      this.router.navigate(['/reservation', this.userId, tableId]);
    } else {
      // Redirect to login or handle accordingly
      this.router.navigate(['/login']);
    }
  }


}
