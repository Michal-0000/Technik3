import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Okno2 } from './okno2';

describe('Okno2', () => {
  let component: Okno2;
  let fixture: ComponentFixture<Okno2>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [Okno2]
    })
    .compileComponents();

    fixture = TestBed.createComponent(Okno2);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
