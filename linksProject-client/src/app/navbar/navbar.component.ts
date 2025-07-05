import { Component } from '@angular/core';
import { LoginComponent } from '../login/login.component';

@Component({
  selector: 'app-navbar',
  standalone: true,
  imports: [LoginComponent],
  template: `
    <nav>
      <button (click)="showLogin = true">התחברות</button>
      <!-- כאן תוסיף לינקים או כפתורים אחרים -->
    </nav>

    <app-login *ngIf="showLogin" (close)="showLogin = false"></app-login>
  `
})
export class NavbarComponent {
  showLogin = false;
}
