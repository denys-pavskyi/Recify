import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';  
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-recommender-api',
  standalone: true,
  imports: [
    CommonModule,
    RouterModule,
    FormsModule
  ],
  templateUrl: './recommender-api.component.html',
  styleUrls: ['./recommender-api.component.scss']
})
export class RecommenderApiComponent {
  recommenders: any[] = [];
  selectedRecommender: string = '';
  apiLink: string = '';
  userId: string = ''; // Added for user ID input

  constructor() {}

  ngOnInit() {
    this.loadRecommenders();
  }

  loadRecommenders() {
    this.recommenders = [
      { id: 'ec458d1c-360c-406f-1336-08dcf34c6614', fileName: 'Recommender A' },
      { id: 'bd759d3f-5db4-4b5c-bb71-2950edcdff20', fileName: 'Recommender B' }
    ];
  }

  fetchApiLink() {
    if (this.selectedRecommender && this.userId) {
      this.apiLink = `https://localhost:44354/api/Recommender/getRecommendation?recommenderSystemId=${this.selectedRecommender}&userId=${this.userId}`;
      console.log('Generated API link:', this.apiLink);
    } else {
      console.log('Please select a recommender system and enter a user ID.');
    }
  }
}