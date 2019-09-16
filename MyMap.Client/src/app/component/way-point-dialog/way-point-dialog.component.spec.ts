import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { WayPointDialogComponent } from './way-point-dialog.component';

describe('WayPointDialogComponent', () => {
  let component: WayPointDialogComponent;
  let fixture: ComponentFixture<WayPointDialogComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ WayPointDialogComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WayPointDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
