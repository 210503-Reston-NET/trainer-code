import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GetReviewsComponent } from './get-reviews.component';

describe('GetReviewsComponent', () => {
  let component: GetReviewsComponent;
  let fixture: ComponentFixture<GetReviewsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GetReviewsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GetReviewsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
