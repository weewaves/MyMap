// tslint:disable: variable-name
import { Injectable } from '@angular/core';
import { HttpClient, HttpRequest, HttpResponse, HttpHeaders } from '@angular/common/http';
import { MapViewPort } from 'src/app/model/common/map-view-port';
import { environment } from 'src/environments/environment';
import { SpotViewModel } from 'src/app/model/view-model/spot/spot-view-model';
import { SpotContract } from 'src/app/model/contract-model/spot/spot-contract';
import * as uuid from 'uuid';
import { Observable } from 'rxjs';
import { map, filter } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class SpotService {
  constructor(private __httpClient: HttpClient) { }

  createSpot(spotViewModel?: SpotViewModel): Observable<any> {
    const data: SpotContract = {
      id: uuid.v4(),
      height: 1,
      latitude: spotViewModel.lat,
      longitude: spotViewModel.lng,
      name: new Date().toISOString(),
      type: 1
    };

    return this.createSpotResponse(data).pipe(
      map(_r => _r.body.returnValue)
    );
  }

  LoadSpotCollectionByViewPortResponse(data?: MapViewPort): Observable<StrictHttpResponse<Array<SpotContract>>> {
    let __headers = new HttpHeaders();
    const __body: any = data;

    __headers = __headers.append('Accept', 'application/json');
    __headers = __headers.append('Access-Control-Allow-Origin', '*');

    const req = new HttpRequest<any>(
      'POST',
      environment.apiEndPoint + `/api/LoadSpotCollectionByViewPort`,
      __body,
      {
        headers: __headers,
        responseType: 'json'
      });

    return this.__httpClient.request<any>(req).pipe(
      filter(_r => _r instanceof HttpResponse),
      map((_r) => {
        return _r as StrictHttpResponse<Array<SpotContract>>;
      })
    );
  }

  loadRegionalSpotCollection(mapViewPort?: MapViewPort): Observable<SpotViewModel[]> {
    return this.LoadSpotCollectionByViewPort(mapViewPort)
      .pipe(
        map(res => {
          return res.map(r => {
            const spotViewModel: SpotViewModel = {
              id: r.id,
              name: r.name,
              lat: r.latitude,
              lng: r.longitude,
              height: r.height,
              draggable: true,
              label: null,
              type: r.type
            };

            return spotViewModel;
          });
        })
      );
  }

  LoadSpotCollectionByViewPort(mapViewPort?: MapViewPort): Observable<Array<SpotContract>> {
    return this.LoadSpotCollectionByViewPortResponse(mapViewPort)
      .pipe(
        map(_r => _r.body as Array<SpotContract>)
      );
  }

  createSpotResponse(data?: SpotContract): Observable<StrictHttpResponse<any>> {
    let __headers = new HttpHeaders();
    const __body: any = data;

    __headers = __headers.append('Accept', 'application/json');
    __headers = __headers.append('Access-Control-Allow-Origin', '*');

    const req = new HttpRequest<any>(
      'POST',
      environment.apiEndPoint + `/api/spot`,
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


