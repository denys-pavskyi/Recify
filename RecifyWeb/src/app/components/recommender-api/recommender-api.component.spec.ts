import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RecommenderApiComponent } from './recommender-api.component';

describe('RecommenderApiComponent', () => {
  let component: RecommenderApiComponent;
  let fixture: ComponentFixture<RecommenderApiComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [RecommenderApiComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RecommenderApiComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
