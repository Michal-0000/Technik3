import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Wnuk1 } from './wnuk1';

describe('Wnuk1', () => {
  let component: Wnuk1;
  let fixture: ComponentFixture<Wnuk1>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [Wnuk1]
    })
    .compileComponents();

    fixture = TestBed.createComponent(Wnuk1);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
