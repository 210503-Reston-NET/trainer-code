import { Component, Input, OnInit, SimpleChanges } from '@angular/core';

@Component({
  selector: 'app-star-ratings',
  templateUrl: './star-ratings.component.html',
  styleUrls: ['./star-ratings.component.css']
})
export class StarRatingsComponent {

  @Input() rating: number;
  starWidth: number;
  constructor() {
    this.rating = 0;
  }

  ngOnChanges(changes: SimpleChanges): void {
    this.starWidth = this.rating * 75 / 100;
  }
}
