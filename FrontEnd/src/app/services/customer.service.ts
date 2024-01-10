import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {Customer} from "../Models/Customer";

@Injectable({
  providedIn: 'root'
})
export class CustomerService {

  constructor(private httpClient: HttpClient) { }

  getCustomerById(customerId: string): Observable<Customer>{
    return this.httpClient.get<Customer>(`https://localhost:7294/api/Customers/get-customer-by-id/${customerId}`);
  }
}
