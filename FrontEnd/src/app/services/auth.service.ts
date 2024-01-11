import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private httpClient: HttpClient) { }

  login(loginPayload: any): Observable<any>{
    return this.httpClient.post('https://localhost:7294/Auth/login', loginPayload);
  }
}
