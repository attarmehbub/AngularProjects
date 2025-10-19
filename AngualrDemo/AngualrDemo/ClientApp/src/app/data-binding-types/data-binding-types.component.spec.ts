import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DataBindingTypesComponent } from './data-binding-types.component';

describe('DataBindingTypesComponent', () => {
  let component: DataBindingTypesComponent;
  let fixture: ComponentFixture<DataBindingTypesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DataBindingTypesComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DataBindingTypesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
