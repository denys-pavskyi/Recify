import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { AuthService } from '../services/auth-service/auth.service';
import { map, Observable, tap } from 'rxjs';
import { Client } from '../models/client';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(private authService: AuthService, private router: Router) {}

  canActivate(): Observable<boolean> {
    return this.authService.client$.pipe(
      map(client => !!client),
      tap((isLoggedIn: any) => {
        if (!isLoggedIn) {
          this.router.navigate(['/']);
        }
      })
    );
  }
}