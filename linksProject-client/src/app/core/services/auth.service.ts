import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable, tap } from 'rxjs';

export interface LoginModel {
    userName: string;
    password: string;
}

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private apiUrl = 'https://localhost:7091/api/auth';
  private loggedIn = new BehaviorSubject<boolean>(false);
  isLoggedIn$ = this.loggedIn.asObservable();

  constructor(private http: HttpClient) {
    this.loggedIn.next(!!localStorage.getItem('token'));
  }

  login(credentials: LoginModel): Observable<any> {
    return this.http.post<{ token: string }>(this.apiUrl, credentials).pipe(
      tap(response => {
        localStorage.setItem('token', response.token);
        this.loggedIn.next(true);
      })
    );
  }

  logout() {
    localStorage.removeItem('token');
    this.loggedIn.next(false);
  }

  getToken(): string | null {
    return localStorage.getItem('token');
  }
}
