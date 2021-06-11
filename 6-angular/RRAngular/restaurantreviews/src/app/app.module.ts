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
import { NavBarComponent } from './components/nav-bar/nav-bar.component';
import { StarRatingsComponent } from './components/star-ratings/star-ratings.component';
import { AuthModule } from '@auth0/auth0-angular';
import { AuthComponent } from './components/auth/auth.component';
import { environment } from 'src/environments/environment';

@NgModule({
  declarations: [
    AppComponent,
    GetRestaurantsComponent,
    AddRestaurantComponent,
    GetReviewsComponent,
    AddReviewComponent,
    EditRestaurantComponent,
    NavBarComponent,
    StarRatingsComponent,
    AuthComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    AuthModule.forRoot({
      domain: environment.AUTH_DOMAIN,
      clientId: environment.AUTH_CLIENT_ID
    })
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
