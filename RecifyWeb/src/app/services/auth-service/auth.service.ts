import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable, BehaviorSubject, throwError } from 'rxjs';
import { environment } from '../../environments/environment';
import { Client } from '../../models/client';
import { Router } from '@angular/router';
import { tap, catchError } from 'rxjs/operators';
import { ErrorResponse } from '../../models/errorResponse';
import Swal from 'sweetalert2';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private apiUrl = environment.apiUrl;
  private clientSubject = new BehaviorSubject<Client | null>(null);
  client$ = this.clientSubject.asObservable();

  constructor(private http: HttpClient, private router: Router) {}

  login(loginModel: { email: string; password: string }): Observable<Client> {
    return this.http.post<Client>(`${this.apiUrl}/Client/signIn`, loginModel).pipe(
      tap(client => {
        this.clientSubject.next(client);
      }),
      catchError((error: HttpErrorResponse) => {
        const errorResponse: ErrorResponse = {
          message: error.error.message || 'An error occurred',
          httpCode: error.status
        };
        
        Swal.fire({
          icon: 'error',
          title: 'Login Failed',
          text: errorResponse.message
        });

        return throwError(errorResponse);
      })
    );
  }

  logout() {
    this.clientSubject.next(null);
    this.router.navigate(['/']);
  }
}