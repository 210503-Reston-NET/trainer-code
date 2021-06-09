import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { restaurant } from 'src/app/models/restaurant';
import { RestRevApiService } from 'src/app/services/restrevapi.service';

@Component({
  selector: 'app-get-restaurants',
  templateUrl: './get-restaurants.component.html',
  styleUrls: ['./get-restaurants.component.css']
})
export class GetRestaurantsComponent implements OnInit {

  restaurants: restaurant[] = [];

  constructor(private restaurantService: RestRevApiService, private router: Router) { }

  //LC hook. There are others. (go research!)
  ngOnInit(): void {
    this.restaurantService.GetAllRestaurants().then(result => this.restaurants = result);
  }

  GoToAddRestaurant() {
    this.router.navigate(['addRestaurant']);
  }
}
