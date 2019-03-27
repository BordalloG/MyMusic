import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MusicRegisterComponent } from './music-register.component';

describe('MusicRegisterComponent', () => {
  let component: MusicRegisterComponent;
  let fixture: ComponentFixture<MusicRegisterComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MusicRegisterComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MusicRegisterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
