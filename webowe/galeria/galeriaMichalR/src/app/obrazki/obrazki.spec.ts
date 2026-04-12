import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Obrazki } from './obrazki';

describe('Obrazki', () => {
  let component: Obrazki;
  let fixture: ComponentFixture<Obrazki>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [Obrazki]
    })
    .compileComponents();

    fixture = TestBed.createComponent(Obrazki);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
