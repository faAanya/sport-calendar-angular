import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddWorkoutModal } from './add-workout-modal';

describe('AddWorkoutModal', () => {
  let component: AddWorkoutModal;
  let fixture: ComponentFixture<AddWorkoutModal>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AddWorkoutModal]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddWorkoutModal);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
