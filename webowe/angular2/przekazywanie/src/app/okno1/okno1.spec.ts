import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Okno1 } from './okno1';

describe('Okno1', () => {
  let component: Okno1;
  let fixture: ComponentFixture<Okno1>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [Okno1]
    })
    .compileComponents();

    fixture = TestBed.createComponent(Okno1);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
