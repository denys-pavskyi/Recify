import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';  
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-recommender-settings',
  standalone: true,
  imports: [
    CommonModule,
    RouterModule,
    FormsModule
  ],
  templateUrl: './recommender-settings.component.html',
  styleUrls: ['./recommender-settings.component.scss']
})
export class RecommenderSettingsComponent implements OnInit {
  recommenderSystems: any[] = [];

  constructor() {}

  ngOnInit() {
    this.loadRecommenderSystems();
  }

  createRecommenderSystem() {
    console.log('Creating recommender system...');
  }

  loadRecommenderSystems() {
    this.recommenderSystems = [
      { id: '1', fileName: 'System A', uploadDate: new Date(), status: 1 },
      { id: '2', fileName: 'System B', uploadDate: new Date(), status: 0 }
    ];
  }

  deleteRecommenderSystem(id: string) {
    console.log(`Deleting recommender system with ID: ${id}`);
  }
}