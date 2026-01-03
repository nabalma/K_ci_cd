import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TouristicCardComponent } from './touristic-card.component';

describe('TouristicCardComponent', () => {
  let component: TouristicCardComponent;
  let fixture: ComponentFixture<TouristicCardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TouristicCardComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(TouristicCardComponent);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
