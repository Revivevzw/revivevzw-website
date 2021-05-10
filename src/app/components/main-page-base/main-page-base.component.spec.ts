import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MainPageBaseComponent } from './main-page-base.component';

describe('MainPageBaseComponent', () => {
  let component: MainPageBaseComponent;
  let fixture: ComponentFixture<MainPageBaseComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MainPageBaseComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MainPageBaseComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
