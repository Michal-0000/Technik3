import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Muzyka } from './muzyka';

describe('Muzyka', () => {
  let component: Muzyka;
  let fixture: ComponentFixture<Muzyka>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [Muzyka]
    })
    .compileComponents();

    fixture = TestBed.createComponent(Muzyka);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
