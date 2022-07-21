import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InsertTopicComponent } from './insert-topic.component';

describe('InsertTopicComponent', () => {
  let component: InsertTopicComponent;
  let fixture: ComponentFixture<InsertTopicComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ InsertTopicComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(InsertTopicComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
