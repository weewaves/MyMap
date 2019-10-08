// tslint:disable: variable-name
import { Component, OnInit, ViewChild } from '@angular/core';
import { MouseEvent, AgmMap, AgmMarker, AgmInfoWindow } from '@agm/core';
import { MapService } from 'src/app/service/common/map.service';
import { SpotService } from 'src/app/service/spot/spot.service';
import { SpotViewModel } from 'src/app/model/view-model/spot/spot-view-model';
import { MatDialog } from '@angular/material';
import { SpotDialogComponent } from '../spot-dialog/spot-dialog.component';

declare var google: any;
@Component({
  selector: 'app-map',
  templateUrl: './map.component.html',
  styleUrls: ['./map.component.scss']
})
export class MapComponent implements OnInit {
  public get mapService(): MapService {
    return this._mapService;
  }
  public set mapService(value: MapService) {
    this._mapService = value;
  }
  @ViewChild('GoogleMap', { static: true }) googleMap: AgmMap;
  @ViewChild('MakerLayer', { static: true }) markerLayer: AgmMarker;


  private _googleMapElement: any;
  private _mapBoundChangedEventListener: any;

  // Default settings
  zoom = 8;
  lat = 35.652216432742485;
  lng = 139.753400369244;

  google = google;

  markers: SpotViewModel[] = null;

  constructor(
    private _mapService: MapService,
    private _spotService: SpotService,
    public dialog: MatDialog) {
  }

  ngOnInit(): void {
    this.googleMap.mapReady.subscribe(this._onMapReady.bind(this));
  }

  getMarkerCollection(): SpotViewModel[] {
    return this.markers;
  }

  clickedMarker(spotData: SpotViewModel, _index: number, target?: AgmInfoWindow) {
    const dialogRef = this.dialog.open(SpotDialogComponent, {
      width: '250px',
      data: spotData
    });

    dialogRef.afterClosed().subscribe(_result => {
      console.log(_result);
    });
  }

  openDialog(): void {
    const dialogRef = this.dialog.open(SpotDialogComponent, {
      width: '250px',
      data: null
    });

    dialogRef.afterClosed().subscribe(_result => {
      console.log(_result);
    });
  }

  trackMarker(index: number, trackedItem: SpotViewModel): string {
    if (!trackedItem) {
      return null;
    }

    return trackedItem.id;
  }

  mapClicked($event: MouseEvent) {
    const self = this;
    const clickedData: SpotViewModel = {
      name: '',
      lat: $event.coords.lat,
      lng: $event.coords.lng,
      draggable: true
    };

    const dialogRef = this.dialog.open(SpotDialogComponent, {
      width: '250px',
      data: clickedData
    });

    dialogRef.afterClosed().subscribe(_result => {
      console.log(_result);
    });
  }

  markerDragEnd(m: SpotViewModel, $event: MouseEvent) {
    console.log('dragEnd', m, $event);
  }

  markerDouleClick(m: SpotViewModel, $event: MouseEvent) {
    console.log('double click', m, $event);
  }

  private _onMapReady(event: any) {
    this.markers = [];
    this._googleMapElement = event;
    this._mapBoundChangedEventListener = google
      .maps
      .event
      .addListener(this._googleMapElement, 'idle', this._onMapBoundChanged.bind(this));
  }

  private _onMapBoundChanged() {
    const self = this;
    const currentMapRegion = this._mapService.getCurrentBound(this._googleMapElement);

    this._spotService
      .loadRegionalSpotCollection(currentMapRegion)
      .subscribe(res => {
        setTimeout(() => {
          self.markers = res;
        }, 10);
      });
  }
}
