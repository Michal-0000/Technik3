import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Dziecko2 } from './dziecko2';

describe('Dziecko2', () => {
  let component: Dziecko2;
  let fixture: ComponentFixture<Dziecko2>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [Dziecko2]
    })
    .compileComponents();

    fixture = TestBed.createComponent(Dziecko2);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
