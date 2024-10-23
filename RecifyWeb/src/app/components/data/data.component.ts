import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';  
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';

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
  hasDatabase: boolean = true;
  createViewsTable: boolean = false;
  createRatingsTable: boolean = false;
  itemColumns: { name: string; type: string }[] = [{ name: '', type: 'String' }];
  dataTypes: string[] = ['String', 'Number', 'Boolean', 'Date', 'Array'];

  constructor() {}

  ngOnInit() {

  }

  addColumn() {
    this.itemColumns.push({ name: '', type: 'String' });
  }

  generateJson() {
    const jsonOutput = {
      tables: {
        items: {
          columns: this.itemColumns
        },
        views: this.createViewsTable,
        ratings: this.createRatingsTable
      }
    };
    console.log(JSON.stringify(jsonOutput, null, 2));
  }
}