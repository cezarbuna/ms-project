import { Component, OnInit } from '@angular/core';
import {ActivatedRoute, Router} from "@angular/router";
import {TableService} from "../../services/table.service";
import {Table} from "../../Models/Table";
import {switchMap} from "rxjs";
import {RestaurantService} from "../../services/restaurant.service";
import {formatDate} from "@angular/common";
import {CustomerService} from "../../services/customer.service";
import {Customer} from "../../Models/Customer";

@Component({
  selector: 'app-view-tables',
  templateUrl: './view-tables.component.html',
  styleUrls: ['./view-tables.component.css']
})
export class ViewTablesComponent implements OnInit {
  selectedDate: Date = new Date();
  restaurantId: string | undefined | null;
  tables: Table[] | undefined;
  userId: string | undefined | null;
  customer: Customer | undefined;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private tableService: TableService,
    private restaurantService: RestaurantService,
    private customerService: CustomerService) { }

  ngOnInit(): void {
    this.userId = localStorage.getItem('userId');

    this.route.paramMap.subscribe(params => {
      this.restaurantId = params.get('restaurantId');
      this.fetchTables();
    })
    // this.route.params.pipe(
    //   switchMap(params => {
    //     const restaurantId = params['restaurantId'];
    //     this.restaurantId = restaurantId;
    //     // console.log(this.restaurantId);
    //     return this.restaurantService.getRestaurantById(restaurantId);
    //   })
    // ).subscribe({
    //   next: (restaurant ) => {
    //     this.tableService.getAllTablesForRestaurant(restaurant.id).subscribe(res => {
    //       this.tables = res;
    //       console.log(this.tables);
    //     })
    //   },
    //   error: (error) => console.error('There was an error!', error)
    // })
  }

  bookTable(tableId: string,maxSeats: Number): void {
    const formattedDate = formatDate(this.selectedDate, 'yyyy-MM-dd', 'en-US');
    if (this.userId && this.restaurantId) {
      this.customerService.getCustomerById(this.userId).subscribe(res => {
        this.customer = res;
        console.log(this.customer);
        this.router.navigate(['/reservation', this.restaurantId, this.userId, tableId, maxSeats, formattedDate]);
      })

    } else {
      // Redirect to login or handle accordingly
      this.router.navigate(['/login']);
    }
  }

  onDateSelect(event: any): void {
    this.fetchTables();
  }

  fetchTables(): void {
    if(this.restaurantId) {
      const formattedDate = formatDate(this.selectedDate,'yyyy-MM-dd', 'en-US');
      this.tableService.getAllAvailableTablesForADay(formattedDate, this.restaurantId).subscribe(res => {
        this.tables = res;
      })
    }
  }

}
