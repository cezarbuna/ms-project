import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {Table} from "../Models/Table";

@Injectable({
  providedIn: 'root'
})
export class TableService {

  constructor(private httpClient: HttpClient) { }

  getAllTablesForRestaurant(restaurantId: string): Observable<Table[]>{
    return this.httpClient.get<Table[]>(`https://localhost:7294/api/Tables/get-all-tables-by-restaurant-id/${restaurantId}`);
  }
}
