import { Injectable } from '@angular/core';
import { Inject } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';
import { Regla } from '../models/regla.model';

@Injectable({
  providedIn: 'root'
})

export class ReglaService {
  private baseUrl: string;

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      'Access-Control-Allow-Origin': '*',
      'Access-Control-Allow-Methods': '*'
    })
  };

  registrarRegla(regla: Regla): Observable<Regla> {
    return this.http.post<Regla>(this.baseUrl + '/sucursal/CrearRegla', JSON.stringify(regla), this.httpOptions)
      .pipe(
        catchError((err) => {
          return throwError(err);
        })
      );
  }

  obtenerReglasPorSucursal(sucursalId: number): Observable<Regla[]> {
    return this.http.get<Regla[]>(this.baseUrl + '/sucursal/GetBySucursalId?id=' + sucursalId);
  }

  editarRegla(regla: Regla): Observable<Regla> {
    return this.http.put<Regla>(this.baseUrl + '/sucursal/ModificarRegla', JSON.stringify(regla), this.httpOptions)
      .pipe(
        catchError((err) => {
          return throwError(err);
        })
      )
  }

  eliminarRegla(reglaId: number): Observable<{}> {
    return this.http.delete(this.baseUrl + '/sucursal/EliminarRegla?id=' + reglaId, this.httpOptions)
      .pipe(
        catchError((err) => {
          return throwError(err);
        })
      );
  }
}
