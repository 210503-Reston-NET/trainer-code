import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from '@auth0/auth0-angular';
import { AddRestaurantComponent } from './components/add-restaurant/add-restaurant.component';
import { AddReviewComponent } from './components/add-review/add-review.component';
import { EditRestaurantComponent } from './components/edit-restaurant/edit-restaurant.component';
import { GetRestaurantsComponent } from './components/get-restaurants/get-restaurants.component';
import { GetReviewsComponent } from './components/get-reviews/get-reviews.component';

const routes: Routes = [
  {
    path: 'restaurants',
    component: GetRestaurantsComponent
  },
  {
    path: 'addRestaurant',
    component: AddRestaurantComponent
  },
  {
    path: 'restaurantReviews',
    component: GetReviewsComponent
  },
  {
    path: 'addReview',
    component: AddReviewComponent
  },
  {
    path: 'editRestaurant',
    component: EditRestaurantComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
