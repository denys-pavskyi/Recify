import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';  
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { LinkedDatabase } from '../../models/linkedDatabase';
import { LinkedDatabaseService } from '../../services/linked-database-service/linked-database.service';
import Swal from 'sweetalert2';
import { AuthService } from '../../services/auth-service/auth.service';

@Component({
  selector: 'app-data',
  templateUrl: './data.component.html',
  styleUrls: ['./data.component.scss'],
  standalone: true,
  imports: [
    CommonModule,
    RouterModule,
    FormsModule
  ],
})


export class DataComponent implements OnInit {
  hasDatabase: boolean = false;
  createViewsTable: boolean = false;
  createRatingsTable: boolean = false;
  itemColumns: { name: string, type: string }[] = [{ name: '', type: 'String' }];
  dataTypes: string[] = ['String', 'Number', 'Boolean', 'Date', 'Array'];
  linkedDatabase: LinkedDatabase | null = null;
  apiLinks: { items: string, views?: string, ratings?: string, users: string } = {
    items: '',
    users: ''
  };

  constructor(private linkedDatabaseService: LinkedDatabaseService, private authService: AuthService) {}

  ngOnInit(): void {
    const clientId = this.authService.clientId || ""; 
    this.linkedDatabaseService.getLinkedDatabaseByClientId(clientId).subscribe({
      next: (db) => {
        this.linkedDatabase = db;
        this.hasDatabase = true;
        this.generateApiLinks();
      },
      error: () => {
        this.hasDatabase = false;
      }
    });
  }

  // Generate JSON from user input and create a new database
  generateJson(): void {
    const jsonConfig = JSON.stringify({
      tables: {
        items: {
          columns: this.itemColumns
        },
        views: this.createViewsTable,
        ratings: this.createRatingsTable
      }
    });

    const clientId = this.authService.clientId || ""; 
    this.linkedDatabaseService.createDatabase(clientId, jsonConfig).subscribe({
      next: () => {
        Swal.fire('Success', 'Database created successfully!', 'success');
        this.ngOnInit();
      },
      error: (err) => {
        Swal.fire('Error', 'Failed to create database: ' + err.message, 'error');
      }
    });
  }

  // Delete the existing linked database
  deleteDatabase(): void {
    if (this.linkedDatabase) {
      this.linkedDatabaseService.deleteDatabase(this.linkedDatabase.id).subscribe({
        next: () => {
          Swal.fire('Success', 'Database deleted successfully!', 'success');
          this.hasDatabase = false;
          this.linkedDatabase = null;
        },
        error: (err) => {
          Swal.fire('Error', 'Failed to delete database: ' + err.message, 'error');
        }
      });
    }
  }

  // Generate API links for the user
  generateApiLinks(): void {
    if (this.linkedDatabase) {
      const baseUrl = 'https://localhost:44354/api/Data/addDataToCollection';
      const dbId = this.linkedDatabase.id;

      this.apiLinks.items = `${baseUrl}?linkedDatabaseId=${dbId}&collectionType=Items`;
      this.apiLinks.users = `${baseUrl}?linkedDatabaseId=${dbId}&collectionType=Users`;

      if (this.linkedDatabase.hasViews) {
        this.apiLinks.views = `${baseUrl}?linkedDatabaseId=${dbId}&collectionType=Views`;
      }

      if (this.linkedDatabase.hasRatings) {
        this.apiLinks.ratings = `${baseUrl}?linkedDatabaseId=${dbId}&collectionType=Ratings`;
      }
    }
  }

  // Add a new column configuration
  addColumn(): void {
    this.itemColumns.push({ name: '', type: 'String' });
  }
}