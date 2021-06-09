import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GetRestaurantsComponent } from './get-restaurants.component';

describe('GetRestaurantsComponent', () => {
  let component: GetRestaurantsComponent;
  let fixture: ComponentFixture<GetRestaurantsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GetRestaurantsComponent ]
    })
    .compileComponents();
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
