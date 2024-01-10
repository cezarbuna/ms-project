import { Component, OnInit } from '@angular/core';
import {ReservationService} from "../../services/reservation.service";
import {Reservation} from "../../Models/Reservation";
import {ActivatedRoute} from "@angular/router";
import {ReservationInfo} from "../../Models/reservationInfo";

@Component({
  selector: 'app-owned-reservations',
  templateUrl: './owned-reservations.component.html',
  styleUrls: ['./owned-reservations.component.css']
})
export class OwnedReservationsComponent implements OnInit {

  customerId: string | undefined;
  reservations: ReservationInfo[] | undefined;

  constructor(
    private reservationService: ReservationService,
    private route: ActivatedRoute
  ) { }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      const customerId = params['customerId'];
      this.customerId = customerId;
      console.log(this.customerId);
      this.reservationService.getReservationsByCustomerIdWithInfo(customerId).subscribe(res => {

        console.log(res);
        this.reservations = res;
      })
    })
  }

  deleteReservation(reservationId: string): void {
    this.reservationService.deleteReservation(reservationId).subscribe({
      next: (res) => {
        console.log('Reservation deleted');
        this.reservations = this.reservations?.filter(r => r.id !== reservationId);
      },
      error: (error) => {
        console.error('Error deleting reservation:', error);
      }
      }
    )
  }

}
