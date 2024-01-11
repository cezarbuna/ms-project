import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {LoginComponent} from "./components/login/login.component";
import {HomeComponent} from "./components/home/home.component";
import {RestaurantComponent} from "./components/restaurant/restaurant.component";
import {ReservationComponent} from "./components/reservation/reservation.component";
import {ViewTablesComponent} from "./components/view-tables/view-tables.component";
import {OwnedReservationsComponent} from "./components/owned-reservations/owned-reservations.component";
import {RegisterComponent} from "./components/register/register.component";
import {AuthGuardService} from "./services/auth-guard.service";
// import { HeroesComponent } from './heroes/heroes.component';

const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'home', component: HomeComponent },
  { path: 'restaurant/:id', component: RestaurantComponent},
  { path: 'viewTables/:restaurantId', component: ViewTablesComponent, canActivate: [AuthGuardService]},
  { path: 'reservation/:restaurantId/:customerId/:tableId/:maxSeats/:reservationDate', component: ReservationComponent, canActivate: [AuthGuardService]},
  { path: 'ownedReservations/:customerId', component: OwnedReservationsComponent, canActivate: [AuthGuardService]},
  { path: '', component: HomeComponent }, //default route
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
