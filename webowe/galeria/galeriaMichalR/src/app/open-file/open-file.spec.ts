import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OpenFile } from './open-file';

describe('OpenFile', () => {
  let component: OpenFile;
  let fixture: ComponentFixture<OpenFile>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [OpenFile]
    })
    .compileComponents();

    fixture = TestBed.createComponent(OpenFile);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
