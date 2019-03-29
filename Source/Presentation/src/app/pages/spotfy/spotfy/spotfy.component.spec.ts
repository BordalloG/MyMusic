import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SpotfyComponent } from './spotfy.component';

describe('SpotfyComponent', () => {
  let component: SpotfyComponent;
  let fixture: ComponentFixture<SpotfyComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SpotfyComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SpotfyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
