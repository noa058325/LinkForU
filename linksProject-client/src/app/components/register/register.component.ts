import { Component, EventEmitter, Output } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { AuthService } from '../../core/services/auth.service';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {
  registerForm: FormGroup;
  errorMsg = '';

  @Output() closed = new EventEmitter<void>();
  @Output() switchToLoginClicked = new EventEmitter<void>();

  constructor(private fb: FormBuilder, private authService: AuthService) {
    this.registerForm = this.fb.group({
      userName: ['', Validators.required],
      password: ['', [Validators.required, Validators.minLength(9)]],
      email: ['', [Validators.required, Validators.email]],
      phoneNumber: ['', [Validators.required, Validators.pattern(/^\d{9,10}$/)]],
      agreeToUpdates: [false, Validators.requiredTrue]
    });
  }

  submit() {
    this.registerForm.markAllAsTouched(); 
    console.log(' [Register] ניסיון הרשמה עם הנתונים:', this.registerForm.value);

    if (this.registerForm.invalid) {
      console.log(' [Register] הטופס לא תקין');
      return;
    }

    const newUser = {
      userName: this.registerForm.value.userName,
      password: this.registerForm.value.password,
      email: this.registerForm.value.email,
      phoneNumber: this.registerForm.value.phoneNumber
    };

    this.authService.register(newUser).subscribe({
      next: () => {
        console.log(' [Register] הרשמה הצליחה');
        this.closed.emit();
      },
      error: (err) => {
        console.error(' [Register] שגיאה בהרשמה:', err);
        this.errorMsg = 'אירעה שגיאה ברישום. נסה שוב.';
        
      }
      
    });
    
  }

  close() {
    console.log(' [Register] סגירת חלון הרשמה');
    this.closed.emit();
  }

  switchToLogin() {
    console.log(' [Register] מעבר לחלון התחברות');
    this.switchToLoginClicked.emit();
  }
}
