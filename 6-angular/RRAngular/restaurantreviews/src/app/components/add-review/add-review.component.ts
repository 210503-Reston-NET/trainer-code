import { Component, OnInit } from '@angular/core';
import { review } from 'src/app/models/review';
import { RestRevApiService } from 'src/app/services/restrevapi.service';

@Component({
  selector: 'app-add-review',
  templateUrl: './add-review.component.html',
  styleUrls: ['./add-review.component.css']
})
export class AddReviewComponent implements OnInit {
  newReview: review = {
    id: 0,
    restaurantId: 0,
    rating: 0,
    description: ''
  }
  constructor(private restaurantService: RestRevApiService) { }

  ngOnInit(): void {
  }

  onSubmit(): void {
    this.restaurantService.AddRestaurantReview(this.newReview);
  }
}
