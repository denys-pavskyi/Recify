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
  batchSize: number = 32;
  epoch: number = 10;
  learningRate: number = 0.01;
  selectedType: string = 'Content-based'; // Added type selector

  recommenderTypes: string[] = ['Content-based', 'Hybrid', 'RecGAN'];

  constructor() {}

  ngOnInit() {
    this.loadRecommenderSystems();
  }

  createRecommenderSystem() {
    const newSystem = {
      id: new Date().getTime().toString(),
      fileName: `System ${this.recommenderSystems.length + 1}`,
      uploadDate: new Date(),
      status: 1,
      batchSize: this.batchSize,
      epoch: this.epoch,
      learningRate: this.learningRate,
      type: this.selectedType // Added to the system configuration
    };

    this.recommenderSystems.push(newSystem);
    console.log('Creating recommender system with settings:', newSystem);
  }

  loadRecommenderSystems() {
    this.recommenderSystems = [
      { id: '1', fileName: 'System A', uploadDate: new Date(), status: 1 },
      { id: '2', fileName: 'System B', uploadDate: new Date(), status: 0 }
    ];
  }

  deleteRecommenderSystem(id: string) {
    this.recommenderSystems = this.recommenderSystems.filter(system => system.id !== id);
    console.log(`Deleted recommender system with ID: ${id}`);
  }
}