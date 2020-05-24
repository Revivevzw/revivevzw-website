import { HttpClient } from '@angular/common/http';
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

   public get<T>(url: string) {
      if (environment.production) {
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
}