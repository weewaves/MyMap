import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AgmCoreModule } from '@agm/core';
import { environment } from 'src/environments/environment';
import { MapComponent } from './map/map.component';
import { MaterialModule } from 'src/app/shared/material.module';
import { WayPointDialogComponent } from './way-point-dialog/way-point-dialog.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

@NgModule({
  imports: [
    CommonModule,
    BrowserAnimationsModule,
    MaterialModule,
    AgmCoreModule.forRoot({
      apiKey: environment.googleMapAPIKey
    })
  ],
  entryComponents: [WayPointDialogComponent],
  declarations: [MapComponent, WayPointDialogComponent],
  exports: [MapComponent, WayPointDialogComponent]
})
export class ComponentModule { }
