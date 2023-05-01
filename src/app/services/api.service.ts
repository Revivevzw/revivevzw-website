import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { isScullyRunning, TransferStateService } from '@scullyio/ng-lib';
import { empty, merge, Observable } from 'rxjs';
import { filter, shareReplay, tap } from 'rxjs/operators';
import { environment } from 'src/environments/environment';

@Injectable({
   providedIn: 'root'
})
export class ApiService {
   constructor(
      private http: HttpClient,
      private transferStateService: TransferStateService
   ) { }

   private getUrl(path: string) {
      return environment.revivevzwApiUrl + path;
   }

   // public get<T>(path: string, setToState: boolean = true) {
   //    var url = this.getUrl(path);

   //    if (environment.production && setToState) {
   //       const urlHash = btoa(url);
   //       if (isScullyRunning()) {
   //          return this.http
   //             .get<T>(url)
   //             .pipe(
   //                tap(data => this.transferStateService.setState<T>(urlHash, data)),
   //                shareReplay(1)
   //             );
   //       }
   //       return this.transferStateService.getState<T>(urlHash).pipe(shareReplay(1));
   //    } else {
   //       return this.http.get<T>(url);
   //    }
   // }

   public getFromState<T>(path: string): Observable<T> {
      const url = this.getUrl(path);
      const urlHash = btoa(url);
      
      return this.transferStateService.stateHasKey(urlHash) 
         ? this.transferStateService.getState<T>(urlHash).pipe(shareReplay(1), filter(x => x != null))
         : empty();
   }

   public getObservables<T>(path: string, setToState: boolean = true): Observable<T>[] {
      const observables: Observable<T>[] = [];

      var url = this.getUrl(path);

      if (setToState) {
         if (isScullyRunning()) {
            const urlHash = btoa(url);
            const observable = this.http
               .get<T>(url)
               .pipe(
                  tap(data => this.transferStateService.setState<T>(urlHash, data)),
                  shareReplay(1)
               );
            observables.push(observable);
         } else {
            // Get from state
            const stateObservable = this.getFromState<T>(path);
            observables.push(stateObservable);
         }
      }
      
      // Get from api
      const apiObservable = this.http.get<T>(url);
      observables.push(apiObservable);

      return observables;
   }

   public get<T>(path: string, setToState: boolean = true) {
      const observables = this.getObservables(path, setToState);
      return merge<T>(...observables);
   }

   public post(path: string, object: any) {
      var url = this.getUrl(path);
      return this.http.post(url, object);
   }
}