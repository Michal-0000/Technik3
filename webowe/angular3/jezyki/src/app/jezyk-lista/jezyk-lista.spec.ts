import { ComponentFixture, TestBed } from '@angular/core/testing';

import { JezykLista } from './jezyk-lista';

describe('JezykLista', () => {
  let component: JezykLista;
  let fixture: ComponentFixture<JezykLista>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [JezykLista],
    }).compileComponents();

    fixture = TestBed.createComponent(JezykLista);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
