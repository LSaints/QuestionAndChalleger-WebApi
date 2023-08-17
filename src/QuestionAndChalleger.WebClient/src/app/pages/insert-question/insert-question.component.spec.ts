import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InsertQuestionComponent } from './insert-question.component';

describe('InsertQuestionComponent', () => {
  let component: InsertQuestionComponent;
  let fixture: ComponentFixture<InsertQuestionComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [InsertQuestionComponent]
    });
    fixture = TestBed.createComponent(InsertQuestionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
