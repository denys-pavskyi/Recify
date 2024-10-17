import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RecommenderTestingComponent } from './recommender-testing.component';

describe('RecommenderTestingComponent', () => {
  let component: RecommenderTestingComponent;
  let fixture: ComponentFixture<RecommenderTestingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [RecommenderTestingComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RecommenderTestingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
