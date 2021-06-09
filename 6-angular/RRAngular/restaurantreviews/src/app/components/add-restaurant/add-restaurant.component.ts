import { Component, OnInit } from '@angular/core';
import { restaurant } from 'src/app/models/restaurant';
import { RestRevApiService } from 'src/app/services/restrevapi.service';

@Component({
  selector: 'app-add-restaurant',
  templateUrl: './add-restaurant.component.html',
  styleUrls: ['./add-restaurant.component.css']
})
export class AddRestaurantComponent implements OnInit {
  newRestaurant: restaurant = {
    id: 0,
    name: '',
    city: '',
    state: '',
    reviews: null
  }

  constructor(private restaurantService: RestRevApiService) { }

  ngOnInit(): void {
  }

  onSubmit(): void {
    this.restaurantService.AddARestaurant(this.newRestaurant).then
      (
        result => {
          alert(`${result.name} has been added`);
        }
      );
  }
}
