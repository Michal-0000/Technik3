import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Notatnik } from './notatnik';

describe('Notatnik', () => {
  let component: Notatnik;
  let fixture: ComponentFixture<Notatnik>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [Notatnik]
    })
    .compileComponents();

    fixture = TestBed.createComponent(Notatnik);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
