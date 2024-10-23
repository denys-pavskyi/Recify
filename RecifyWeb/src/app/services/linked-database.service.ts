import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../environments/environment';
import { LinkedDatabase } from '../models/linkedDatabase';
import { ErrorResponse } from '../models/errorResponse';

@Injectable({
  providedIn: 'root'
})
export class LinkedDatabaseService {
  private apiUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  // Endpoint to create a new database
  createDatabase(clientId: string, jsonConfig: string): Observable<void> {
    return this.http.post<void>(`${this.apiUrl}/api/LinkedDatabase/createDatabase`, {
      clientId,
      jsonConfig
    });
  }

  // Endpoint to delete a linked database
  deleteDatabase(linkedDatabaseId: string): Observable<void> {
    return this.http.post<void>(`${this.apiUrl}/api/LinkedDatabase/deleteDatabase`, {
      linkedDatabaseId
    });
  }

  // Endpoint to add data to a specific collection
  addDataToCollection(linkedDatabaseId: string, collectionType: string, jsonData: string): Observable<void | ErrorResponse> {
    return this.http.post<void | ErrorResponse>(`${this.apiUrl}/api/LinkedDatabase/addDataToCollection`, {
      linkedDatabaseId,
      collectionType,
      jsonData
    });
  }

  // Endpoint to get information about a linked database
  getLinkedDatabase(linkedDatabaseId: string): Observable<LinkedDatabase> {
    return this.http.get<LinkedDatabase>(`${this.apiUrl}/api/LinkedDatabase/getLinkedDatabase`, {
      params: { linkedDatabaseId }
    });
  }

  getLinkedDatabaseByClientId(clientId: string): Observable<LinkedDatabase> {
    return this.http.get<LinkedDatabase>(`${this.apiUrl}/api/LinkedDatabase/getLinkedDatabaseByClientId`, {
      params: { clientId }
    });
  }


}