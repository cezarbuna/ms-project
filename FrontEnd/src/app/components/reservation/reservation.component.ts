import { Component, OnInit } from '@angular/core';
import {Table} from "../../Models/Table";
import {ActivatedRoute, Router} from "@angular/router";

@Component({
  selector: 'app-reservation',
  templateUrl: './reservation.component.html',
  styleUrls: ['./reservation.component.css']
})
export class ReservationComponent implements OnInit {
  restaurantId: string | undefined;
  tables: Table[] | undefined;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
  ) { }

  ngOnInit(): void {
  }

}
