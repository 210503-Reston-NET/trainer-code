import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http'
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { GetRestaurantsComponent } from './components/get-restaurants/get-restaurants.component';
import { AddRestaurantComponent } from './components/add-restaurant/add-restaurant.component';
import { FormsModule } from '@angular/forms';
import { GetReviewsComponent } from './components/get-reviews/get-reviews.component';
import { AddReviewComponent } from './components/add-review/add-review.component';
import { EditRestaurantComponent } from './components/edit-restaurant/edit-restaurant.component';

@NgModule({
  declarations: [
    AppComponent,
    GetRestaurantsComponent,
    AddRestaurantComponent,
    GetReviewsComponent,
    AddReviewComponent,
    EditRestaurantComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
