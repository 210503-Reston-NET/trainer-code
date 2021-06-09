import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { GetRestaurantsComponent } from './components/get-restaurants/get-restaurants.component';

const routes: Routes = [
  {
    path: 'restaurants',
    component: GetRestaurantsComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
