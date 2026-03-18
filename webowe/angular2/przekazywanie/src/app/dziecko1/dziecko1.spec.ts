import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Dziecko1 } from './dziecko1';

describe('Dziecko1', () => {
  let component: Dziecko1;
  let fixture: ComponentFixture<Dziecko1>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [Dziecko1]
    })
    .compileComponents();

    fixture = TestBed.createComponent(Dziecko1);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
