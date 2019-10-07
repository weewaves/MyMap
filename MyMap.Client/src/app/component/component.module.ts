import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AgmCoreModule } from '@agm/core';
import { environment } from 'src/environments/environment';
import { MapComponent } from './map/map.component';
import { MaterialModule } from 'src/app/shared/material.module';
import { WayPointDialogComponent } from './way-point-dialog/way-point-dialog.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AgmSnazzyInfoWindowModule } from '@agm/snazzy-info-window';
import { WayPointInfoComponent } from './way-point-info/way-point-info.component';

@NgModule({
  imports: [
    CommonModule,
    BrowserAnimationsModule,
    MaterialModule,
    AgmCoreModule.forRoot({
      apiKey: environment.googleMapAPIKey
    }),
    AgmSnazzyInfoWindowModule
  ],
  entryComponents: [WayPointDialogComponent],
  declarations: [MapComponent, WayPointDialogComponent, WayPointInfoComponent],
  exports: [MapComponent, WayPointDialogComponent]
})
export class ComponentModule { }
