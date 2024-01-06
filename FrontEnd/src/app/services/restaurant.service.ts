import { Injectable } from '@angular/core';
import {Observable} from "rxjs";
import {HttpClient} from "@angular/common/http";
import {Restaurant} from "../Models/Restaurant";

@Injectable({
  providedIn: 'root'
})
export class RestaurantService {

  private url = 'https://localhost:7294/api/Restaurants/get-all-restaurants';

  constructor(private httpClient: HttpClient) { }

  getAllRestaurants(): Observable<Restaurant[]> {
    return this.httpClient.get<Restaurant[]>(this.url);
  }
  getRestaurantById(id: string): Observable<Restaurant> {
    return this.httpClient.get<Restaurant>(`https://localhost:7294/api/Restaurants/get-restaurant-by-id/${id}`);
  }
}
