import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MapService } from './common/map.service';

@NgModule({
  imports: [
    CommonModule
  ],
  declarations: [MapService],
  exports: [MapService]
})
export class ServiceModule { }
