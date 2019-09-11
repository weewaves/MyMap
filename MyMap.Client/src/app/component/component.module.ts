import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AgmCoreModule } from '@agm/core';
import { environment } from 'src/environments/environment';
import { MapComponent } from './map/map.component';

@NgModule({
  imports: [
    CommonModule,
    AgmCoreModule.forRoot({
      apiKey: environment.googleMapAPIKey
    })
  ],
  declarations: [MapComponent],
  exports: [MapComponent]
})
export class ComponentModule { }
