import { Component } from '@angular/core';
import { AuthService } from '../../services/auth-service/auth.service';
import { Client } from '../../models/client';
import { CommonModule } from '@angular/common';  
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-navbar',
  standalone: true,
  imports: [
    CommonModule,
    RouterModule
  ],
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.scss',
})

export class NavbarComponent {
  clientName: string | null = null;
  isLoggedIn: boolean = false;

  constructor(private authService: AuthService) {
    this.authService.client$.subscribe(client => {
      this.clientName = client?.username || null;
      this.isLoggedIn = !!client;
    });
  }

  logout() {
    this.authService.logout();
    this.clientName = null;
    this.isLoggedIn = false;
  }
}