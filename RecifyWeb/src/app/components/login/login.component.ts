import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-login',
  standalone: true,
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
  imports: [FormsModule]
})
export class LoginComponent {
  loginModel = {
    email: '',
    password: ''
  };

  constructor(private authService: AuthService, private router: Router) {}

  onSubmit() {
    this.authService.login(this.loginModel).subscribe(user => {
      if (user) {
        console.log(`Welcome, ${user.username}`);
        this.router.navigate(['/home']);
      } else {
        // Handle login error
        alert('Invalid credentials');
      }
    });
  }
}