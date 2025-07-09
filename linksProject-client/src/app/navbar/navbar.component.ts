import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';

// אם יש לך קומפוננטות התחברות והרשמה, תייבא אותן פה:
import { LoginComponent } from '../login/login.component';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css'],
  standalone: true,
  imports: [FormsModule, LoginComponent]
})
export class NavbarComponent {
  showLogin = false;
  showRegister = false;

  isLoggedIn = false;
  userName = '';
  searchQuery = '';
  historyCount = 0;

  constructor() {
    // כאן את יכולה לטעון סטטוס התחברות אמיתי ושם משתמש משירות Auth
  }

  onSearch() {
    if(this.searchQuery.trim()) {
      console.log('מחפשים:', this.searchQuery);
      // כאן ניתן לנתב לדף תוצאות חיפוש או להפעיל לוגיקת חיפוש
    }
  }

  openHistory() {
    console.log('פותחים היסטוריה');
    // ניווט או פתיחת מודאל של היסטוריית צפיות
  }

  logout() {
    this.isLoggedIn = false;
    this.userName = '';
    console.log('התנתקות');
    // קריאה לשירות התנתקות אמיתי
  }
}
