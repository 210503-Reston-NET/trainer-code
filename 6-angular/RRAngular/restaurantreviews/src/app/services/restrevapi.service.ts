import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { rating } from '../models/rating';
import { restaurant } from '../models/restaurant';
import { review } from '../models/review';

@Injectable({
  providedIn: 'root'
})
export class RestRevApiService {
  baseURL: string = environment.RESTREVAPI;

  constructor(private http: HttpClient) { }

  //Promise vs observable
  // Technically speaking, this.http.get() returns an observable, but we're converting it to a promise
  // Both of them represent async operations that result in some form of return 
  // Promises are closed after the result has been returned. Once it is fulfilled its done
  // Observables are still open just in case, additional results can be returned. 

  GetAllRestaurants(): Promise<restaurant[]> {
    return this.http.get<restaurant[]>(this.baseURL).toPromise();
  }
  AddARestaurant(newRestaurant: restaurant): Promise<restaurant> {
    return this.http.post<restaurant>(this.baseURL, newRestaurant).toPromise();
  }

  GetRestaurantReviews(restaurantId: number): Promise<rating> {
    return this.http.get<rating>(`${this.baseURL}/${restaurantId}/reviews`).toPromise();
  }

  GetRestaurant(restaurantId: number): Promise<restaurant> {
    return this.http.get<restaurant>(`${this.baseURL}/${restaurantId}`).toPromise();
  }

  AddRestaurantReview(newReview: review): Promise<review> {
    return this.http.post<review>(`${this.baseURL}/${newReview.restaurantId}/reviews`, newReview).toPromise();
  }

  EditRestaurant(restaurant: restaurant): Promise<void> {
    return this.http.put<void>(`${this.baseURL}/${restaurant.id}`, restaurant).toPromise();
  }

  DeleteRestaurant(restaurantId: number): Promise<void> {
    return this.http.delete<void>(`${this.baseURL}/${restaurantId}`).toPromise();
  }
}
