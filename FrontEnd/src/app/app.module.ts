import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {RouterModule} from "@angular/router";
import { AppRoutingModule } from './app-routing.module';
import { LoginComponent } from './components/login/login.component';
import {MatButtonModule} from "@angular/material/button";
import {MatCardModule} from "@angular/material/card";
import {MatFormFieldModule} from "@angular/material/form-field";
import { NavbarComponent } from './components/navbar/navbar.component';
import { HomeComponent } from './components/home/home.component';
import {HttpClientModule} from "@angular/common/http";
import {FormsModule} from "@angular/forms";
import {CardModule} from "primeng/card";
import {ButtonModule} from "primeng/button";
import { RestaurantComponent } from './components/restaurant/restaurant.component';
import {ToolbarModule} from "primeng/toolbar";
import {SplitButtonModule} from "primeng/splitbutton";
import {AvatarModule} from "primeng/avatar";
import { ReservationComponent } from './components/reservation/reservation.component';
import { ViewTablesComponent } from './components/view-tables/view-tables.component';
import {CalendarModule} from "primeng/calendar";

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    NavbarComponent,
    HomeComponent,
    RestaurantComponent,
    ReservationComponent,
    ViewTablesComponent
  ],
    imports: [
        HttpClientModule,
        BrowserModule,
        BrowserAnimationsModule,
        AppRoutingModule,
        MatButtonModule,
        MatCardModule,
        MatFormFieldModule,
        FormsModule,
        CardModule,
        ButtonModule,
        ToolbarModule,
        SplitButtonModule,
        AvatarModule,
        CalendarModule
    ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
