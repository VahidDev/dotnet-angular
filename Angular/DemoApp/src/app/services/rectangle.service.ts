import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Rectangle } from '../models/rectangle';
import { Result } from '../models/result';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})

export class RectangleService {
  private apiUrl = 'Rectangles';

  constructor(private http: HttpClient) { }

  SaveRectangle(rectangle: Rectangle) : Observable<Result>{
    return this.http.post<Result>(`${environment.apiUrl}/${this.apiUrl}/SaveDimensions`, rectangle);
  }

  GetRectangle() : Observable<Result>{
    return this.http.get<Result>(`${environment.apiUrl}/${this.apiUrl}/GetRectangle`);
  }
}
