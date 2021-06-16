import { ComponentFixture, TestBed } from '@angular/core/testing';
import { Router } from '@angular/router';
import { RouterTestingModule } from '@angular/router/testing';
import { restaurant } from 'src/app/models/restaurant';
import { RestRevApiService } from 'src/app/services/restrevapi.service';

import { GetRestaurantsComponent } from './get-restaurants.component';

describe('GetRestaurantsComponent', () => {
  let component: GetRestaurantsComponent;
  let fixture: ComponentFixture<GetRestaurantsComponent>;
  let restaurantService: RestRevApiService;
  let router: Router
  class MockService {
    GetAllRestaurants(): Promise<restaurant[]> { return new Promise((resolve, reject) => { [] }) };
  }

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [RouterTestingModule],
      declarations: [GetRestaurantsComponent],
      providers: [{ provide: RestRevApiService, useClass: MockService }]
    })
      .compileComponents();

    router = TestBed.inject(Router)
    restaurantService = TestBed.inject(RestRevApiService)
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GetRestaurantsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();

  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

