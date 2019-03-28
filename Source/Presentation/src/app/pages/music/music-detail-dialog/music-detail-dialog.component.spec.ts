import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MusicDetailDialogComponent } from './music-detail-dialog.component';

describe('MusicDetailDialogComponent', () => {
  let component: MusicDetailDialogComponent;
  let fixture: ComponentFixture<MusicDetailDialogComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MusicDetailDialogComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MusicDetailDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
