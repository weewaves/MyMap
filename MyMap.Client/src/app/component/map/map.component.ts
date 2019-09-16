// tslint:disable: variable-name
import { Component, OnInit, ViewChild } from '@angular/core';
import { MouseEvent, AgmMap, AgmMarker } from '@agm/core';
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


  private _googleMapElement: any;
  private _mapBoundChangedEventListener: any;

  // Default settings
  zoom = 8;
  lat = 51.673858;
  lng = 7.815982;

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

  clickedMarker(wayPointData: WayPointViewModel, index: number) {
    const dialogRef = this.dialog.open(WayPointDialogComponent, {
      width: '250px',
      data: wayPointData
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
    });
  }

  openDialog(): void {
    const dialogRef = this.dialog.open(WayPointDialogComponent, {
      width: '250px',
      data: null
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
    });
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

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
    });

    // this._waypointService
    //   .createWayPoint(clickedData)
    //   .subscribe(() => {
    //     self.markers.push({
    //       lat: $event.coords.lat,
    //       lng: $event.coords.lng,
    //       draggable: true
    //     });
    //   });
  }

  markerDragEnd(m: WayPointViewModel, $event: MouseEvent) {
    console.log('dragEnd', m, $event);
  }

  markerDouleClick(m: WayPointViewModel, $event: MouseEvent) {
    console.log('double click', m, $event);
  }

  _onMapReady(event: any) {
    this.markers = [];
    this._googleMapElement = event;
    this._mapBoundChangedEventListener = google
      .maps
      .event
      .addListener(this._googleMapElement, 'bounds_changed', this._onMapBoundChanged.bind(this));
  }

  _onMapBoundChanged() {
    const self = this;
    const currentMapRegion = this._mapService.getCurrentBound(this._googleMapElement);

    this._waypointService
      .loadRegionalWayPointCollection(currentMapRegion)
      .subscribe(res => {
        setTimeout(() => {
          self.markers = res;
        }, 10);
      });
  }
}
