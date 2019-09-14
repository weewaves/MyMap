// tslint:disable: variable-name
import { Injectable } from '@angular/core';
import { HttpClient, HttpRequest, HttpResponse, HttpHeaders } from '@angular/common/http';
import { MapRegion } from 'src/app/model/common/map-region';
import { environment } from 'src/environments/environment';
import { WayPointViewModel } from 'src/app/model/view-model/way-point/way-point-view-model';
import { WayPointContract } from 'src/app/model/contract-model/waypoint/way-point-contract';
import * as uuid from 'uuid';
import { Observable, of } from 'rxjs';
import { map, filter, switchMap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class WayPointService {
  constructor(private __httpClient: HttpClient) { }

  createWayPoint(waypointViewModel?: WayPointViewModel): Observable<any> {
    const data: WayPointContract = {
      id: uuid.v4(),
      height: 1,
      latitude: waypointViewModel.lat,
      longitude: waypointViewModel.lng,
      name: new Date().toISOString(),
      type: 1
    };

    return this.createWayPointResponse(data).pipe(
      map(_r => _r.body.returnValue)
    );
  }

  LoadWayPointCollectionByRegionResponse(data?: MapRegion): Observable<StrictHttpResponse<Array<WayPointContract>>> {
    let __headers = new HttpHeaders();
    const __body: any = data;

    __headers = __headers.append('Accept', 'application/json');
    __headers = __headers.append('Access-Control-Allow-Origin', '*');

    const req = new HttpRequest<any>(
      'POST',
      environment.apiEndPoint + `/api/LoadWayPointCollectionByRegion`,
      __body,
      {
        headers: __headers,
        responseType: 'json'
      });

    return this.__httpClient.request<any>(req).pipe(
      filter(_r => _r instanceof HttpResponse),
      map((_r) => {
        return _r as StrictHttpResponse<Array<WayPointContract>>;
      })
    );
  }

  loadRegionalWayPointCollection(mapRegion?: MapRegion): Observable<WayPointViewModel[]> {
    return this.LoadWayPointCollectionByRegion(mapRegion)
      .pipe(
        map(res => {
          return res.map(r => {
            const waypointViewModel: WayPointViewModel = {
              id: r.id,
              name: r.name,
              lat: r.latitude,
              lng: r.longitude,
              height: r.height,
              draggable: true,
              label: null,
              type: r.type
            };

            return waypointViewModel;
          });
        })
      );
  }

  LoadWayPointCollectionByRegion(mapRegion?: MapRegion): Observable<Array<WayPointContract>> {
    return this.LoadWayPointCollectionByRegionResponse(mapRegion)
      .pipe(
        map(_r => _r.body as Array<WayPointContract>)
      );
  }

  createWayPointResponse(data?: WayPointContract): Observable<StrictHttpResponse<any>> {
    let __headers = new HttpHeaders();
    const __body: any = data;

    __headers = __headers.append('Accept', 'application/json');
    __headers = __headers.append('Access-Control-Allow-Origin', '*');

    const req = new HttpRequest<any>(
      'POST',
      environment.apiEndPoint + `/api/WayPoint`,
      __body,
      {
        headers: __headers,
        responseType: 'text'
      });

    return this.__httpClient.request<any>(req).pipe(
      filter(_r => _r instanceof HttpResponse),
      map((_r) => {
        return _r as StrictHttpResponse<any>;
      })
    );
  }
}

/**
 * Constrains the http to not expand the response type with `| null`
 */
export type StrictHttpResponse<T> = HttpResponse<T> & {
  readonly body: T;
};


