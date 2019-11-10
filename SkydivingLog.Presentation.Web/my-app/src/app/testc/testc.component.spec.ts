import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TESTCComponent } from './testc.component';

describe('TESTCComponent', () => {
  let component: TESTCComponent;
  let fixture: ComponentFixture<TESTCComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TESTCComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TESTCComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
