import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ResetsucessComponent } from './resetsucess.component';

describe('ResetsucessComponent', () => {
  let component: ResetsucessComponent;
  let fixture: ComponentFixture<ResetsucessComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ResetsucessComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ResetsucessComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
