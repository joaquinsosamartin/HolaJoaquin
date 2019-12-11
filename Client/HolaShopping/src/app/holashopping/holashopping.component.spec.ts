import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HolashoppingComponent } from './holashopping.component';

describe('HolashoppingComponent', () => {
  let component: HolashoppingComponent;
  let fixture: ComponentFixture<HolashoppingComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HolashoppingComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HolashoppingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
