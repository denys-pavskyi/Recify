import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { ErrorResponse } from '../../models/errorResponse';

@Injectable({
  providedIn: 'root'
})
export class AlertService {
  private subject = new Subject<ErrorResponse>();

  alert$ = this.subject.asObservable();

  triggerAlert(error: ErrorResponse) {
    this.subject.next(error);
  }
}