import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { WayPointInfoComponent } from './way-point-info.component';

describe('WayPointInfoComponent', () => {
  let component: WayPointInfoComponent;
  let fixture: ComponentFixture<WayPointInfoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ WayPointInfoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WayPointInfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
