import { Component, OnInit } from '@angular/core';
import { CsvUploadService } from '../../services/csv-upload/csv-upload.service';
import { AuthService } from '../../services/auth-service/auth.service';
import { CommonModule } from '@angular/common';  
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-csv-upload',
  standalone: true,
  imports: [
    CommonModule,
    RouterModule
  ],
  templateUrl: './csv-upload.component.html',
  styleUrls: ['./csv-upload.component.scss']
})
export class CsvUploadComponent implements OnInit {
  selectedFile: File | null = null;
  uploadedFiles: any[] = [];

  constructor(private csvUploadService: CsvUploadService, private authService: AuthService) {}

  ngOnInit() {
    this.loadUploadedFiles();
  }

  onFileSelected(event: any) {
    this.selectedFile = event.target.files[0];
  }

  uploadCsv() {
    const clientId = this.authService.clientId || ""; 
    if (this.selectedFile) {
      this.csvUploadService.uploadCsv(clientId, this.selectedFile).subscribe(
        response => {
          this.loadUploadedFiles();
          this.selectedFile = null;
        },
        error => {
          console.error('Upload failed', error);
        }
      );
    }
  }

  loadUploadedFiles() {
    const clientId = this.authService.clientId || "";
    this.csvUploadService.getUploadedFiles(clientId).subscribe(
      files => {
        this.uploadedFiles = files;
      },
      error => {
        console.error('Failed to load files', error);
      }
    );
  }

  deleteCsv(uploadedCsvId: string) {
    this.csvUploadService.deleteUploadedCsv(uploadedCsvId).subscribe(
      response => {
        this.loadUploadedFiles();
      },
      error => {
        console.error('Deletion failed', error);
      }
    );
  }
}