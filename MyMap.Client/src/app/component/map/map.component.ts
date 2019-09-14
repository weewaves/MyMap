// tslint:disable: variable-name
import { Component, OnInit, ViewChild } from '@angular/core';
import { MouseEvent, AgmMap, AgmMarker } from '@agm/core';
import { MapService } from 'src/app/service/common/map.service';
import { WayPointService } from 'src/app/service/way-point/waypoint.service';
import { WayPointViewModel } from 'src/app/model/view-model/way-point/way-point-view-model';

declare var google: any;
@Component({
  selector: 'app-map',
  templateUrl: './map.component.html',
  styleUrls: ['./map.component.css']
})
export class MapComponent implements OnInit {
  public get mapService(): MapService {
    return this._mapService;
  }
  public set mapService(value: MapService) {
    this._mapService = value;
  }
  @ViewChild('GoogleMap') googleMap: AgmMap;
  @ViewChild('MakerLayer') markerLayer: AgmMarker;


  private _googleMapElement: any;
  private _idleEventListener: any;

  // Default settings
  zoom = 8;
  lat = 51.673858;
  lng = 7.815982;

  markers: WayPointViewModel[] = [];

  constructor(private _mapService: MapService, private _waypointService: WayPointService) {
  }

  ngOnInit(): void {
    this.googleMap.mapReady.subscribe(this._onMapReady.bind(this));
  }

  _onMapReady(event: any) {
    this._googleMapElement = event;
    this._idleEventListener = google.maps.event.addListener(this._googleMapElement, 'idle', this._onMapIdle.bind(this));
  }

  _onMapIdle() {
    const self = this;
    const currentMapRegion = this._mapService.getCurrentBound(this._googleMapElement);

    this._waypointService
      .loadRegionalWayPointCollection(currentMapRegion)
      .subscribe(res => {
        self.markers = [];
        setTimeout(() => {
          self.markers = res;
        });
      });
  }

  clickedMarker(label: string, index: number) {
    console.log(`clicked the marker: ${label || index}`);
  }

  mapClicked($event: MouseEvent) {
    const self = this;
    const data: WayPointViewModel = {
      lat: $event.coords.lat,
      lng: $event.coords.lng,
      draggable: true
    };
    this._waypointService
      .createWayPoint(data)
      .subscribe(() => {
        self.markers.push({
          lat: $event.coords.lat,
          lng: $event.coords.lng,
          draggable: true
        });
      });
  }

  markerDragEnd(m: WayPointViewModel, $event: MouseEvent) {
    console.log('dragEnd', m, $event);
  }
}
