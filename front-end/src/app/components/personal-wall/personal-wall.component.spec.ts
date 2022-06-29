import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PersonalWallComponent } from './personal-wall.component';

describe('PersonalWallComponent', () => {
  let component: PersonalWallComponent;
  let fixture: ComponentFixture<PersonalWallComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PersonalWallComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PersonalWallComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
