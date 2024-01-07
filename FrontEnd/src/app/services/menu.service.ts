import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {Menu} from "../Models/Menu";
import {MenuItem} from "../Models/MenuItem";

@Injectable({
  providedIn: 'root'
})
export class MenuService {

  constructor(private httpClient: HttpClient) { }

  getMenuByRestaurantId(restaurantId: string): Observable<Menu> {
    return this.httpClient.get<Menu>(`https://localhost:7294/api/Menus/get-menu-by-id/${restaurantId}`);
  }
  getMenuItemsByRestaurantId(restaurantId: string): Observable<MenuItem[]>{
    return this.httpClient
      .get<MenuItem[]>(`https://localhost:7294/api/MenuItem/get-all-menu-items-by-restaurantId-id/${restaurantId}`);
  }
  // 006cbebc-0e1e-4721-7ecc-08dbe6039406
  // 6a993fcf-8aca-4afe-7095-08dbe5f87897
}
