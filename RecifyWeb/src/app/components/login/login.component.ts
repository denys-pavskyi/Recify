import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth-service/auth.service';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';  
import { BrowserModule } from '@angular/platform-browser';
import { ErrorResponse } from '../../models/errorResponse';
import Swal from 'sweetalert2';


@Component({
  selector: 'app-login',
  standalone: true,
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
  imports: [
    FormsModule,
    CommonModule
  ]
})
export class LoginComponent {
  loginModel = {
    email: '',
    password: ''
  };

  constructor(private authService: AuthService, private router: Router) {}

  onSubmit() {
    this.authService.login(this.loginModel).subscribe({
      next: (client) => {
        this.router.navigate(['/home']);
      },
      error: (errorResponse) => {
        // Replace standard alert with SweetAlert
        Swal.fire({
          icon: 'error',
          title: errorResponse.message || 'Invalid credentials'
        });
      }
    });
  }
}