import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddRestaurantComponent } from './components/add-restaurant/add-restaurant.component';
import { GetRestaurantsComponent } from './components/get-restaurants/get-restaurants.component';

const routes: Routes = [
  {
    path: 'restaurants',
    component: GetRestaurantsComponent
  },
  {
    path: 'addRestaurant',
    component: AddRestaurantComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
