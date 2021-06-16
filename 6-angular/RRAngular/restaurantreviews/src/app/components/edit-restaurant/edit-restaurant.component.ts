import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { restaurant } from 'src/app/models/restaurant';
import { RestRevApiService } from 'src/app/services/restrevapi.service';

@Component({
  selector: 'app-edit-restaurant',
  templateUrl: './edit-restaurant.component.html',
  styleUrls: ['./edit-restaurant.component.css']
})
export class EditRestaurantComponent implements OnInit {
  resto2Edit: restaurant = {
    id: 0,
    name: '',
    city: '',
    state: '',
    reviews: null
  }

  constructor(private restaurantService: RestRevApiService, private route: ActivatedRoute, private router: Router) { }

  ngOnInit(): void {
    this.route.queryParams.subscribe(
      params => {
        this.restaurantService.GetRestaurant(params.id).then(
          foundResto => {
            this.resto2Edit = foundResto;
          }
        );
      }
    );
  }

  onSubmit(): void {
    this.restaurantService.EditRestaurant(this.resto2Edit).then
      (
        () => {
          alert('Changes saved!');
          this.router.navigate(['restaurants']);
        }
      )
  }
}
