import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { isScullyRunning, TransferStateService } from '@scullyio/ng-lib';
import { tap, shareReplay } from 'rxjs/operators';
import { Injectable } from '@angular/core';
import { getuid } from 'process';

@Injectable({
   providedIn: 'root'
})
export class ApiService {
   constructor(
      private http: HttpClient,
      private transferStateService: TransferStateService
   ) { }

   private getUrl(path: string){
      return path;
      // return environment.revivevzwApiUrl + path;
   }

   public get<T>(path: string, setToState: boolean = true) {
      var url = this.getUrl(path);
      
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

   public post(path: string, object: any){
      var url = this.getUrl(path);
      return this.http.post(url, object);
   }
}