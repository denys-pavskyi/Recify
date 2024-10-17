import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AuthService } from '../auth-service/auth.service';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CsvUploadService {
  private baseUrl = environment.apiUrl;

  constructor(private http: HttpClient, private authService: AuthService) {}

  uploadCsv(clientId: string, file: File): Observable<any> {
    const formData = new FormData();
    formData.append('file', file);
    
    return this.http.post(`${this.baseUrl}/api/CsvUpload/upload?clientId=${clientId}`, formData);
}

  getUploadedFiles(clientId: string): Observable<any[]> {
    return this.http.get<any[]>(`${this.baseUrl}/api/CsvUpload/getUploadedFiles?clientId=${clientId}`);
  }

  deleteUploadedCsv(uploadedCsvId: string): Observable<any> {
    return this.http.delete(`${this.baseUrl}/api/CsvUpload/removeUploadedCsv?uploadedCsvId=${uploadedCsvId}`);
  }
}