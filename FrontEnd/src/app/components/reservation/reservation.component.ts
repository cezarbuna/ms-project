import { Component, OnInit } from '@angular/core';
import {Table} from "../../Models/Table";
import {ActivatedRoute, Router} from "@angular/router";
import {RestaurantService} from "../../services/restaurant.service";
import {CustomerService} from "../../services/customer.service";
import {Customer} from "../../Models/Customer";
import {Restaurant} from "../../Models/Restaurant";
import {HttpClient} from "@angular/common/http";
import {TableService} from "../../services/table.service";

@Component({
  selector: 'app-reservation',
  templateUrl: './reservation.component.html',
  styleUrls: ['./reservation.component.css']
})
export class ReservationComponent implements OnInit {
  tableId: string | undefined;
  table: Table = {} as Table;
  restaurantId: string | undefined;
  restaurant: Restaurant = {} as Restaurant;
  restaurantName: string | undefined;
  maxSeats: number | undefined;
  customerId: number | undefined;
  customer: Customer = {} as Customer;
  customerName: string | undefined;
  reservationDate: string | undefined;


  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private restaurantService: RestaurantService,
    private customerService: CustomerService,
    private tableService: TableService,
    private httpClient: HttpClient
  ) { }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      const restaurantId = params['restaurantId'];
      this.restaurantId = restaurantId;
      const customerId = params['customerId'];
      this.customerId = customerId;
      const tableId = params['tableId'];
      this.tableId = tableId;
      this.maxSeats = +params['maxSeats'];
      this.reservationDate = params['reservationDate'];

      this.restaurantService.getRestaurantById(restaurantId).subscribe(res => {
        this.restaurant = res;
        this.restaurantName = res.name;
        console.log(this.restaurant);
      });
      this.customerService.getCustomerById(customerId).subscribe(res => {
        this.customer = res;
        this.customerName = res.fullName;
        console.log(this.customer);
      });
      this.tableService.getTableById(tableId).subscribe(res => {
        this.table = res;
        console.log(this.table);
      })
    })

  }

  createReservation(): void {
    const reservationBody = {
      customerId: this.customerId,
      tableId: this.tableId,
      reservationDate: this.reservationDate
    }

    this.httpClient.post('https://localhost:7294/api/Reservations', reservationBody).subscribe(res => {
      console.log('Reservation creation response:');
      console.log(res);
      // alert('Reservation created successfully');
      this.router.navigate(['home']);
    });
  }

}
