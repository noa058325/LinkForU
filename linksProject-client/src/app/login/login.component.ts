import { Component } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { AuthService } from '../core/services/auth.service';

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

  constructor(private fb: FormBuilder, private authService: AuthService, private router: Router)
   { this.loginForm = this.fb.group({
    userName: ['', Validators.required],
    password: ['', Validators.required]
  });}

  submit() {
    if (this.loginForm.invalid) return;

    // this.authService.login(this.loginForm.value).subscribe({
    //   next: () => this.router.navigate(['/']),
    //   error: () => this.errorMsg = 'שם משתמש או סיסמה שגויים'
    // });
  }
}
