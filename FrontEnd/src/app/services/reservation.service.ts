import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {Reservation} from "../Models/Reservation";
import {ReservationInfo} from "../Models/reservationInfo";

@Injectable({
  providedIn: 'root'
})
export class ReservationService {

  constructor(private httpClient: HttpClient) { }

  getReservationsByCustomerId(customerId: string): Observable<Reservation[]>{
    return this.httpClient.get<Reservation[]>(`https://localhost:7294/api/Reservations/get-reservations-by-customer-id/${customerId}`);
  }
  getReservationsByCustomerIdWithInfo(customerId: string): Observable<ReservationInfo[]>{
    return this.httpClient.get<ReservationInfo[]>(`https://localhost:7294/api/Reservations/get-reservations-by-customer-id-with-info/${customerId}`);
  }
  deleteReservation(reservationId: string): Observable<any> {
    return this.httpClient.delete(`https://localhost:7294/api/Reservations/delete-reservation/${reservationId}`);
  }

}

