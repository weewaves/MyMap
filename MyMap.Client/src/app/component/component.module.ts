import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AgmCoreModule } from '@agm/core';
import { environment } from 'src/environments/environment';
import { MapComponent } from './map/map.component';
import { MaterialModule } from 'src/app/shared/material.module';
import { SpotDialogComponent } from './spot-dialog/spot-dialog.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AgmSnazzyInfoWindowModule } from '@agm/snazzy-info-window';

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
  entryComponents: [SpotDialogComponent],
  declarations: [MapComponent, SpotDialogComponent],
  exports: [MapComponent, SpotDialogComponent]
})
export class ComponentModule { }
