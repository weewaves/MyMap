import { Injectable } from '@angular/core';
import { LatLngBounds } from '@agm/core';
import { MapRegion } from 'src/app/model/common/map-region';
import { Coordinate } from 'src/app/model/common/coordinate';

declare var google: any;
@Injectable({
  providedIn: 'root'
})
export class MapService {
  constructor() { }

  public getCurrentBound(googleMapElement: any): MapRegion {
    if (!googleMapElement) {
      return;
    }

    const result = googleMapElement.getBounds();
    const currentMapRegion: MapRegion = {};

    if (!result) {
      return;
    }

    currentMapRegion.topRightCorner = {
      latitude: result.getNorthEast().lat(),
      longitude: result.getNorthEast().lng()
    };
    currentMapRegion.bottomLeftCorner = {
      latitude: result.getSouthWest().lat(),
      longitude: result.getSouthWest().lng()
    };

    return currentMapRegion;
  }

  public getMapCenter(googleMapObj: any): Coordinate {
    const mapCenter = googleMapObj.getCenter();

    return { latitude: mapCenter.lat(), longitude: mapCenter.lng() };
  }

  public getFitBoundFromCoordinateCollection(coordinates: Coordinate[]): LatLngBounds {
    let fitBound;

    if (!google || !coordinates || coordinates.length === 0) {
      return null;
    }

    fitBound = new google.maps.LatLngBounds();

    coordinates.forEach((coordinate) => {
      fitBound.extend(new google.maps.LatLng(coordinate.latitude, coordinate.longitude));
    });

    return fitBound;
  }

  public addReadOnlyMarker(mapObject: any, coordinate: any, ico: any, lbl: any) {
    const marker = new google.maps.Marker({
      position: new google.maps.LatLng(coordinate.latitude, coordinate.longitude),
      map: mapObject,
      icon: ico,
      label: lbl,
      opacity: ico.opacity
    });

    return marker;
  }

  public addDraggableMarker(mapObject: any, coordinate: any, ico: any, lbl: any) {
    const marker = new google.maps.Marker({
      position: new google.maps.LatLng(coordinate.latitude, coordinate.longitude),
      map: mapObject,
      icon: ico,
      draggable: true,
      label: lbl,
      opacity: ico.opacity
    });

    return marker;
  }

  public attachEventToMap(map: any, eventName: string, callback: any): any {
    if (!map) {
      return new Promise((resolve) => {
        resolve(true);
      });
    }

    return google.maps.event.addListener(map, eventName, callback);
  }
}
