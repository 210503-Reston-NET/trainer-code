import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
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
  constructor(private restaurantService: RestRevApiService, private route: ActivatedRoute, private router: Router) { }

  ngOnInit(): void {
    this.route.queryParams.subscribe(
      params => {
        this.newReview.restaurantId = params.id
      }
    )
  }

  onSubmit(): void {
    this.restaurantService.AddRestaurantReview(this.newReview);
    alert('review added');
    this.router.navigate(['restaurantReviews'], { queryParams: { restaurantId: this.newReview.restaurantId } });
  }
}
