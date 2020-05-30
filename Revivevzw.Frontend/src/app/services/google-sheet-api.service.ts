import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
   providedIn: 'root'
})
export class GoogleSheetApiService {

   constructor(private http: HttpClient) { }

   private code = "1sXP2Ed6FHkzj_hfJjzTS8aamQmqAaolzkBW4W0kXE7I";
   private url = "https://spreadsheets.google.com/feeds/cells/" + this.code + "/1/public/full?alt=json";

   public getTranslations = () => {
      return this.http.get<any>(this.url);
   }
}