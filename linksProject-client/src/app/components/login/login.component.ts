import { Component, Output, EventEmitter } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../../core/services/auth.service';
import { LoginModel } from '../../core/models/login.model';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  loginForm;
  errorMsg = '';

  @Output() closed = new EventEmitter<void>();
  @Output() switchToRegisterClicked = new EventEmitter<void>();
  @Output() loginSuccess = new EventEmitter<string>();

  constructor(
    private fb: FormBuilder,
    private authService: AuthService,
    private router: Router
  ) {
    this.loginForm = this.fb.group({
      userName: ['', Validators.required],
      password: ['', Validators.required]
    });
  }

  submit() {
    this.loginForm.markAllAsTouched();
    console.log('🟢 [Login] ניסיון התחברות עם הנתונים:', this.loginForm.value);

    if (this.loginForm.invalid) {
      console.log('🔴 [Login] הטופס לא תקין');
      return;
    }

    const loginData: LoginModel = {
      userName: this.loginForm.value.userName ?? '',
      password: this.loginForm.value.password ?? ''
    };

    this.authService.login(loginData).subscribe({
      next: (res) => {
        console.log('[Login] התחברות הצליחה');

        const token = res.token;
        const payload = JSON.parse(atob(token.split('.')[1]));
        localStorage.setItem('userId', payload.nameid); 

        localStorage.setItem('token', token); 

        this.loginSuccess.emit(loginData.userName);
        this.closed.emit();
        this.router.navigate(['/']);
      },
      error: (err) => {
        console.error(' [Login] שגיאה בהתחברות:', err);
        this.errorMsg = 'שם משתמש או סיסמה שגויים';
      }
    });
  }

  close() {
    console.log(' [Login] סגירת חלון התחברות');
    this.closed.emit();
  }

  switchToRegister() {
    console.log(' [Login] מעבר לחלון הרשמה');
    this.switchToRegisterClicked.emit();
  }
  resetForm() {
    this.loginForm.reset();
  }
}
