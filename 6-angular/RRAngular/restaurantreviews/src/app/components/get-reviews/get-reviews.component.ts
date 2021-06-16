import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { rating } from 'src/app/models/rating';
import { restaurant } from 'src/app/models/restaurant';
import { RestRevApiService } from 'src/app/services/restrevapi.service';

@Component({
  selector: 'app-get-reviews',
  templateUrl: './get-reviews.component.html',
  styleUrls: ['./get-reviews.component.css']
})
export class GetReviewsComponent implements OnInit {
  restrevs: rating = {
    reviews: [],
    average: 0
  }

  restaurant: restaurant = {
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
        this.restaurantService.GetRestaurantReviews(params.restaurantId).then(
          result => {
            this.restrevs = result;
          }
        );
        this.restaurantService.GetRestaurant(params.restaurantId).then(
          //the function you declare here is the callback fcn that executes when a promise is successful,
          // similarly when you subscribe to an observable, you also define a callback to execute for when the observable 
          // is successful
          result => {
            this.restaurant = result;
          }
        )
      }
    )
  }
  AddReview(restaurantId: number) {
    this.router.navigate(['addReview'], { queryParams: { id: restaurantId } });
  }
}
