import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {LoginComponent} from "./components/login/login.component";
import {HomeComponent} from "./components/home/home.component";
import {RestaurantComponent} from "./components/restaurant/restaurant.component";
import {ReservationComponent} from "./components/reservation/reservation.component";
// import { HeroesComponent } from './heroes/heroes.component';

const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'home', component: HomeComponent },
  { path: 'restaurant/:id', component: RestaurantComponent},
  { path: 'reservation/:customerId', component: ReservationComponent},
  { path: '', component: HomeComponent }, //default route
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
