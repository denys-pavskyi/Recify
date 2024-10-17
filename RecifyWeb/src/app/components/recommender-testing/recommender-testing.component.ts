import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';  
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-recommender-testing',
  standalone: true,
  imports: [
    CommonModule,
    RouterModule
  ],
  templateUrl: './recommender-testing.component.html',
  styleUrl: './recommender-testing.component.scss'
})
export class RecommenderTestingComponent implements OnInit {
  recommenders: any[] = [];
  selectedRecommender: string = '';
  userId: string = '';
  results: string = '';

  constructor() {}

  ngOnInit() {
    this.loadRecommenders();
  }

  loadRecommenders() {
    this.recommenders = [
      { id: '1', fileName: 'Recommender A' },
      { id: '2', fileName: 'Recommender B' }
    ];
  }

  runRecommender() {
    console.log('Running recommender for User ID:', this.userId);
  }
}