import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { catchError } from 'rxjs/operators';
import { throwError } from 'rxjs/internal/observable/throwError';
import { LoggerService } from './logger.service';

@Injectable({
  providedIn: 'root'
})
export class AppService {

  constructor(private logger: LoggerService, private http: HttpClient) { }

  get(path: string, params: HttpParams = new HttpParams()): Observable<any> {
    this.logger.trace("--> ApiService.get()");
    return this.http.get(path, { params }).pipe(catchError(this.handleErrors));
  }

  post(path: string, body: Object = {}): Observable<any> {
    this.logger.trace("--> ApiService.post()");
    const headers = new HttpHeaders({
      'Content-Type': 'application/json'
    });
    return this.http.post(path, JSON.stringify(body),{headers:headers}).pipe(catchError(this.handleErrors));
  }
  private handleErrors(error: any) {
    this.logger.trace(`Error Code: ${error.status} and Error Message: ${error.message}`)
    return throwError(error.message);
  }
}
