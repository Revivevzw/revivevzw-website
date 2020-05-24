import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { NewsItem } from '../models/index';
import { ApiService } from './api.service';

@Injectable({
   providedIn: 'root'
})
export class NewsItemApiService {

   constructor(
      private apiService: ApiService
   ) { }

   private path = "news-items";

   public getAll = () => {
      let url = environment.strapiUrl + this.path;
      return this.apiService.get<Array<NewsItem>>(url);
   }
}