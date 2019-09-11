// tslint:disable: variable-name
import { Component, OnInit, ViewChild } from '@angular/core';
import { MouseEvent, AgmMap } from '@agm/core';
import { MapService } from 'src/app/service/common/map.service';

declare var google: any;
@Component({
  selector: 'app-map',
  templateUrl: './map.component.html',
  styleUrls: ['./map.component.css']
})
export class MapComponent implements OnInit {
  @ViewChild('GoogleMap') googleMap: AgmMap;


  private _googleMapElement: any;
  private _idleEventListener: any;
  private _mapService: MapService;

  // google maps zoom level
  zoom = 8;

  // initial center position for the map
  lat = 51.673858;
  lng = 7.815982;

  markers: Marker[] = [
    {
      lat: 51.673858,
      lng: 7.815982,
      label: 'A',
      draggable: true
    },
    {
      lat: 51.373858,
      lng: 7.215982,
      label: 'B',
      draggable: false
    },
    {
      lat: 51.723858,
      lng: 7.895982,
      label: 'C',
      draggable: true
    }
  ];

  constructor(mapService: MapService) {
    this._mapService = mapService;
  }

  ngOnInit(): void {
    this.googleMap.mapReady.subscribe(this._onMapReady.bind(this));
  }

  _onMapReady(event: any) {
    console.log('_onMapReady');
    this._googleMapElement = event;
    this._idleEventListener = google.maps.event.addListener(this._googleMapElement, 'idle', this._onMapIdle.bind(this));
  }

  _onMapIdle() {
    const currentMapRegion = this._mapService.getCurrentBound(this._googleMapElement);
    console.log('Idle');
  }

  clickedMarker(label: string, index: number) {
    console.log(`clicked the marker: ${label || index}`);
  }

  mapClicked($event: MouseEvent) {
    this.markers.push({
      lat: $event.coords.lat,
      lng: $event.coords.lng,
      draggable: true
    });
  }

  markerDragEnd(m: Marker, $event: MouseEvent) {
    console.log('dragEnd', m, $event);
  }
}

// just an interface for type safety.
interface Marker {
  lat: number;
  lng: number;
  label?: string;
  draggable: boolean;
}
