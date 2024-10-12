import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RecommenderSettingsComponent } from './recommender-settings.component';

describe('RecommenderSettingsComponent', () => {
  let component: RecommenderSettingsComponent;
  let fixture: ComponentFixture<RecommenderSettingsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [RecommenderSettingsComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RecommenderSettingsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
