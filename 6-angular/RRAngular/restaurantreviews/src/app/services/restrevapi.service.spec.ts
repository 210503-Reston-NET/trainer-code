import { TestBed } from '@angular/core/testing';

import { RestRevApiService } from './restrevapi.service';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing'
import { environment } from 'src/environments/environment';
import { restaurant } from '../models/restaurant';

describe('RestrevapiService', () => {
  let service: RestRevApiService;
  let httpMock: HttpTestingController;
  const dummyRestaurant: restaurant = {
    id: 1,
    name: 'test',
    city: 'test',
    state: 'test',
    reviews: null
  }

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [RestRevApiService]
    });
    service = TestBed.inject(RestRevApiService);
    httpMock = TestBed.inject(HttpTestingController);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should get restaurant', () => {
    service.GetRestaurant(1).then(
      result => {
        expect(result.city).toBe('test');
      }
    )
    const req = httpMock.expectOne(environment.RESTREVAPI + '/1');
    // request.method just holds a string that gives the outgoing http request as a string 
    expect(req.request.method).toBe('GET');
    //return the dummy restaurant
    req.flush(dummyRestaurant);
  });
});
