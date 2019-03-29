import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MusicEditDialogComponent } from './music-edit-dialog.component';

describe('MusicEditDialogComponent', () => {
  let component: MusicEditDialogComponent;
  let fixture: ComponentFixture<MusicEditDialogComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MusicEditDialogComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MusicEditDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
