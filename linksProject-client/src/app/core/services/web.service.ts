import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Web } from '../models/web.model';
import { WebDetail } from '../models/web-detail.model';

@Injectable({
  providedIn: 'root'
})
export class WebService {
  private apiUrl = 'https://localhost:7091/api/Web';

  constructor(private http: HttpClient) {}

  getAllWebs(): Observable<Web[]> {
    return this.http.get<Web[]>(this.apiUrl);
  }

  getWebsByCategory(categoryId: number): Observable<WebDetail[]> {
    const url = '${this.apiUrl}/category/${categoryId}';
    return this.http.get<WebDetail[]>(url);
  }

  searchWebs(query: string): Observable<WebDetail[]> {
    const url = '${this:apiUrl}/search?query=${encodeURIComponent(query)}';
    return this.http.get<WebDetail[]>(url);
  }

  getWebById(id: number): Observable<WebDetail> {
    const url = '${this,apiUrl}/${id}';
    return this.http.get<WebDetail>(url);
  }
}