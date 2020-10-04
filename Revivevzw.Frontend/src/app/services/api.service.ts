import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { isScullyRunning, TransferStateService } from '@scullyio/ng-lib';
import { tap, shareReplay } from 'rxjs/operators';
import { Injectable } from '@angular/core';

@Injectable({
   providedIn: 'root'
})
export class ApiService {
   constructor(
      private http: HttpClient,
      private transferStateService: TransferStateService
   ) { }

   private httpOptions = {
      headers: new HttpHeaders({
        'Access-Control-Allow-Origin': '*',
        'Access-Control-Allow-Methods': 'GET, HEAD, OPTIONS, POST, PUT',
        'Access-Control-Allow-Headers': 'Origin, Accept, X-Requested-With, Content-Type, Access-Control-Request-Method, Access-Control-Request-Headers',
        'Content-Type': "application/json"
      })
    };

   public get<T>(url: string, setToState: boolean = true) {
      if (environment.production && setToState) {
         const urlHash = btoa(url);
         if (isScullyRunning()) {
            return this.http
               .get<T>(url)
               .pipe(
                  tap(data => this.transferStateService.setState<T>(urlHash, data)),
                  shareReplay(1)
               );
         }
         return this.transferStateService.getState<T>(urlHash).pipe(shareReplay(1));
      } else {
         return this.http.get<T>(url);
      }
   }

   public post(url: string, object: any){
      return this.http.post(url, object);
   }
}