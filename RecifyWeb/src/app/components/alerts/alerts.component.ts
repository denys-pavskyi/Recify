import { Component, OnInit } from '@angular/core';
import { AlertService } from '../../services/alert-service/alert.service';
import { ErrorResponse } from '../../models/errorResponse';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-alert',
  standalone: true,
  imports: [
    CommonModule
  ],
  templateUrl: './alerts.component.html',
  styleUrls: ['./alerts.component.scss']
})
export class AlertComponent implements OnInit {
  errorMessage: string | null = null;

  constructor(private alertService: AlertService) {}

  ngOnInit() {
    this.alertService.alert$.subscribe((error: ErrorResponse) => {
      this.errorMessage = error.message || null;
      setTimeout(() => {
        this.errorMessage = null;
      }, 5000);
    });
  }
}