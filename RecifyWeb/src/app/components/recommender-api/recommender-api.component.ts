import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';  
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-recommender-api',
  standalone: true,
  imports: [
    CommonModule,
    RouterModule
  ],
  templateUrl: './recommender-api.component.html',
  styleUrl: './recommender-api.component.scss'
})
export class RecommenderApiComponent {
  recommenders: any[] = [];
  selectedRecommender: string = '';
  apiLink: string = '';

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

  fetchApiLink() {
    // Placeholder for fetching the API link
    console.log('Fetching API link for:', this.selectedRecommender);
    this.apiLink = 'https://api.example.com/recommenders/' + this.selectedRecommender;
  }
}
