import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MapService } from './common/map.service';
import { SpotService } from './spot/spot.service';
import { HttpClientModule } from '@angular/common/http';


@NgModule({
  imports: [
    CommonModule,
    HttpClientModule
  ],
  providers: [
    MapService,
    SpotService
  ],
})
export class ServiceModule { }
