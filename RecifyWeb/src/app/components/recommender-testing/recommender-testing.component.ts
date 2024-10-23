import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';  
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-recommender-testing',
  standalone: true,
  imports: [
    CommonModule,
    RouterModule,
    FormsModule
  ],
  templateUrl: './recommender-testing.component.html',
  styleUrls: ['./recommender-testing.component.scss']
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
    const randomItems = this.generateRandomItems();
    this.results = `Recommended Items for User ID ${this.userId}: ${randomItems.join(', ')}`;
    console.log('Running recommender for User ID:', this.userId, 'Results:', this.results);
  }

  generateRandomItems(): string[] {
    const items = ['Item1', 'Item2', 'Item3', 'Item4', 'Item5', 'Item6', 'Item7', 'Item8', 'Item9', 'Item10'];
    const randomCount = Math.floor(Math.random() * 5) + 1;
    const randomItems = [];

    for (let i = 0; i < randomCount; i++) {
      const randomIndex = Math.floor(Math.random() * items.length);
      randomItems.push(items[randomIndex]);
    }

    return randomItems;
  }
}