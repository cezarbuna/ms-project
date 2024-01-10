import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OwnedReservationsComponent } from './owned-reservations.component';

describe('OwnedReservationsComponent', () => {
  let component: OwnedReservationsComponent;
  let fixture: ComponentFixture<OwnedReservationsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OwnedReservationsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(OwnedReservationsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
