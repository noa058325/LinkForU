import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Web } from '../models/category.model';

@Injectable({
  providedIn: 'root'
})
export class WebService {
  private apiUrl = 'https://localhost:7091/api/Web';

  constructor(private http: HttpClient) {}

  getAllWebs(): Observable<Web[]> {
    return this.http.get<Web[]>(this.apiUrl);
  }
}