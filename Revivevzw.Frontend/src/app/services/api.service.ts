import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { isScullyRunning, TransferStateService } from '@scullyio/ng-lib';
import { tap, shareReplay, mergeAll, mergeScan } from 'rxjs/operators';
import { Injectable } from '@angular/core';
import { getuid } from 'process';
import { AsyncSubject, BehaviorSubject, forkJoin, Observable, Subject } from 'rxjs';

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

   public getObservables<T>(path: string, setToState: boolean = true): Observable<T>[] {
      const observables: Observable<T>[] = [];

      var url = this.getUrl(path);

      if (environment.production && setToState) {
         const urlHash = btoa(url);
         if (isScullyRunning()) {
            var observable = this.http
               .get<T>(url)
               .pipe(
                  tap(data => this.transferStateService.setState<T>(urlHash, data)),
                  shareReplay(1)
               );
            observables.push(observable);
         } else {
            var observable = this.transferStateService.getState<T>(urlHash).pipe(shareReplay(1));
            observables.push(observable);
         }
      }

      var observable = this.http.get<T>(url);
      observables.push(observable);

      return observables;
   }

   public get<T>(path: string, setToState: boolean = true) {
      const observables = this.getObservables(path, setToState);
      const subject = new Subject<T>();

      observables.forEach(x => x.subscribe((y: T) => subject.next(y)));

      return subject.asObservable();
   }

   public post(path: string, object: any) {
      var url = this.getUrl(path);
      return this.http.post(url, object);
   }
}