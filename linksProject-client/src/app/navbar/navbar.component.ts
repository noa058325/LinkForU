import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { LoginComponent } from '../login/login.component';
import { RegisterComponent } from '../register/register.component';
import { ViewChild } from '@angular/core';


@Component({
  selector: 'app-navbar',
  standalone: true,
  imports: [CommonModule, FormsModule, LoginComponent, RegisterComponent],
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit{
  @ViewChild(LoginComponent) loginComponent!: LoginComponent;
  showLogin = false;
  showRegister = false;

  isLoggedIn = false;
  userName = '';
  searchQuery = '';
  historyCount = 0;
  ngOnInit() {
    const sessionUser = sessionStorage.getItem('userName');
    if (sessionUser) {
      this.userName = sessionUser;
      this.isLoggedIn = true;
      console.log('🔄 [Navbar] משתמש משוחזר מה-sessionStorage:', sessionUser);
    }
  }
  onSearch() {
    if (this.searchQuery.trim()) {
      console.log('מחפשים:', this.searchQuery);
    }
  }

  openHistory() {
    console.log('פותחים היסטוריה');
  }

  logout() {
      this.isLoggedIn = false;
      this.userName = '';
      sessionStorage.removeItem('userName');
    
      // איפוס טופס ההתחברות אם פתוח
      if (this.loginComponent) {
        this.loginComponent.resetForm();
      }
    
      console.log('התנתקות וניקוי טופס');
    }

  openLogin() {
    console.log('🔓 [Navbar] פתיחת חלון התחברות');
    this.showLogin = true;
    this.showRegister = false;
    setTimeout(() => {
      if (this.loginComponent) {
        this.loginComponent.resetForm();
      }
    }, 0);
  }
  
  openRegister() {
    console.log('📝 [Navbar] פתיחת חלון הרשמה');
    this.showRegister = true;
    this.showLogin = false;
  }
  
  closeModals() {
    console.log('❌ [Navbar] סגירת כל החלונות');
    this.showLogin = false;
    this.showRegister = false;
  }
  onLoginSuccess(userName: string) {
    console.log('🟩 [Navbar] התחברות הצליחה - קיבלנו שם משתמש:', userName);
    alert('ברוך הבא');
    this.userName = userName;
    this.isLoggedIn = true;
    sessionStorage.setItem('userName', userName); 
    this.closeModals();
    setTimeout(() => {
      console.log('🟢 [Navbar] אחרי סגירת מודאל, isLoggedIn:', this.isLoggedIn, 'userName:', this.userName);
    }, 0);
  }
  
  onRegisterSuccess(userName: string) {
    this.userName = userName;
    this.isLoggedIn = true;
    this.closeModals();
  }
}
