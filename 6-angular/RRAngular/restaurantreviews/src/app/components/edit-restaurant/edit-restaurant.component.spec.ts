import { ComponentFixture, TestBed } from '@angular/core/testing';
import { FormsModule } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { RouterTestingModule } from '@angular/router/testing';
import { restaurant } from 'src/app/models/restaurant';
import { RestRevApiService } from 'src/app/services/restrevapi.service';

import { EditRestaurantComponent } from './edit-restaurant.component';

describe('EditRestaurantComponent', () => {
  let component: EditRestaurantComponent;
  let fixture: ComponentFixture<EditRestaurantComponent>;
  class MockService {
    EditRestaurant(restaurant: restaurant): Promise<restaurant> { return new Promise((resolve, reject) => { { } }) };
  }
  let restService: RestRevApiService;
  let router: Router;
  let route: ActivatedRoute;
  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [RouterTestingModule, FormsModule],
      declarations: [EditRestaurantComponent],
      providers: [{ provide: RestRevApiService, useClass: MockService }]
    })
      .compileComponents();
    restService = TestBed.inject(RestRevApiService);
    router = TestBed.inject(Router);
    route = TestBed.inject(ActivatedRoute);
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EditRestaurantComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
