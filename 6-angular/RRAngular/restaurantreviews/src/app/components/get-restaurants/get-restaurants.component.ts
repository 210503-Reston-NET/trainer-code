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
  //this property represents the restaurants the user sees
  restaurants: restaurant[] = [];
  //this property represents the list of all restaurants
  allRestaurants: restaurant[] = [];
  private _filterByLetters: string;
  public get filterByLetters(): string {
    return this._filterByLetters;
  }
  public set filterByLetters(v: string) {
    this._filterByLetters = v;
    //every time the value of filterByLetters changes we filter out the restaurants as well
    this.restaurants = v ? this.allRestaurants.filter((restaurant) => restaurant.name.indexOf(v) !== -1) : this.allRestaurants;
  }

  constructor(private restaurantService: RestRevApiService, private router: Router) { }

  //LC hook. There are others. (go research!)
  ngOnInit(): void {
    this.restaurantService.GetAllRestaurants().then(result => { this.restaurants = result; this.allRestaurants = result });
  }

  GoToAddRestaurant() {
    this.router.navigate(['addRestaurant']);
  }

  GoToReviews(restaurantId: number) {
    this.router.navigate(['restaurantReviews'], { queryParams: { restaurantId: restaurantId } });
  }

  GoToEditRestaurant(restaurantId: number) {
    this.router.navigate(['editRestaurant'], { queryParams: { id: restaurantId } });
  }
  DeleteRestaurant(restaurantId: number, restaurantName: string) {
    //there's this thing called event propagation
    // capturing and bubbling
    // capturing - going from the parent to the child element that triggers an event
    // bubbling - when you trigger similar events from child to parent 
    event.stopPropagation();
    if (confirm(`Are you sure you want to delete ${restaurantName}?`).valueOf()) {
      this.restaurantService.DeleteRestaurant(restaurantId).then(
        () => {
          alert(`${restaurantName} has been deleted`);
          this.restaurantService.GetAllRestaurants().then(
            result => {
              this.restaurants = result;
            }
          )
        }
      )
    }
  }
}
