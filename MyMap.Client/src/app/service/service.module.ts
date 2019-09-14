import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MapService } from './common/map.service';
import { WayPointService } from './way-point/waypoint.service';
import { HttpClientModule } from '@angular/common/http';


@NgModule({
  imports: [
    CommonModule,
    HttpClientModule
  ],
  providers: [
    MapService,
    WayPointService
  ],
})
export class ServiceModule { }
