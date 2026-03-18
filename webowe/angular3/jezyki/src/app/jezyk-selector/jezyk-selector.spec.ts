import { ComponentFixture, TestBed } from '@angular/core/testing';

import { JezykSelector } from './jezyk-selector';

describe('JezykSelector', () => {
  let component: JezykSelector;
  let fixture: ComponentFixture<JezykSelector>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [JezykSelector],
    }).compileComponents();

    fixture = TestBed.createComponent(JezykSelector);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
