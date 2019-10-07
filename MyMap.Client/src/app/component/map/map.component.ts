// tslint:disable: variable-name
import { Component, OnInit, ViewChild } from '@angular/core';
import { MouseEvent, AgmMap, AgmMarker, AgmInfoWindow } from '@agm/core';
import { MapService } from 'src/app/service/common/map.service';
import { WayPointService } from 'src/app/service/way-point/waypoint.service';
import { WayPointViewModel } from 'src/app/model/view-model/way-point/way-point-view-model';
import { MatDialog } from '@angular/material';
import { WayPointDialogComponent } from '../way-point-dialog/way-point-dialog.component';

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
  @ViewChild('WayPointInfoPopup', { static: true }) wayPointInfoPopup: AgmInfoWindow;


  private _googleMapElement: any;
  private _mapBoundChangedEventListener: any;
  private _currentWayPointInfoPopup: AgmInfoWindow;

  // Default settings
  zoom = 8;
  lat = 51.673858;
  lng = 7.815982;

  google = google;

  markers: WayPointViewModel[] = null;

  constructor(
    private _mapService: MapService,
    private _waypointService: WayPointService,
    public dialog: MatDialog) {
  }

  ngOnInit(): void {
    this.googleMap.mapReady.subscribe(this._onMapReady.bind(this));
  }

  getMarkerCollection(): WayPointViewModel[] {
    return this.markers;
  }

  clickedMarker(wayPointData: WayPointViewModel, _index: number, target?: AgmInfoWindow) {
    // this._updateCurrentWayPointPopup(target);

    // const dialogRef = this.dialog.open(WayPointDialogComponent, {
    //   width: '250px',
    //   data: wayPointData
    // });

    // dialogRef.afterClosed().subscribe(_result => {
    //   console.log('The dialog was closed');
    // });
  }

  openDialog(): void {
    const dialogRef = this.dialog.open(WayPointDialogComponent, {
      width: '250px',
      data: null
    });

    dialogRef.afterClosed().subscribe(_result => {
      console.log('The dialog was closed');
    });
  }

  trackMarker(index: number, trackedItem: WayPointViewModel): string {
    if (!trackedItem) {
      return null;
    }

    return trackedItem.id;
  }

  mapClicked($event: MouseEvent) {
    const self = this;
    const clickedData: WayPointViewModel = {
      name: '',
      lat: $event.coords.lat,
      lng: $event.coords.lng,
      draggable: true
    };

    const dialogRef = this.dialog.open(WayPointDialogComponent, {
      width: '250px',
      data: clickedData
    });

    dialogRef.afterClosed().subscribe(_result => {
      console.log('The dialog was closed');
    });
  }

  markerDragEnd(m: WayPointViewModel, $event: MouseEvent) {
    console.log('dragEnd', m, $event);
  }

  markerDouleClick(m: WayPointViewModel, $event: MouseEvent) {
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

    this._waypointService
      .loadRegionalWayPointCollection(currentMapRegion)
      .subscribe(res => {
        setTimeout(() => {
          self._updateCurrentWayPointPopup();
          self.markers = res;
        }, 10);
      });
  }

  private _updateCurrentWayPointPopup(currentPopup?: AgmInfoWindow) {
    if (this._currentWayPointInfoPopup) {
      this._currentWayPointInfoPopup.close();
    }

    this._currentWayPointInfoPopup = currentPopup;
  }
}
