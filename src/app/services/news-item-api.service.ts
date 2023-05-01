import { Injectable } from '@angular/core';
import { NewsItem } from '../models/index';
import { ApiService } from './api.service';

@Injectable({
   providedIn: 'root'
})
export class NewsItemApiService {

   constructor(
      private apiService: ApiService
   ) { }

   private path = "splash";

   public getAll = () => {
      return this.apiService.get<Array<NewsItem>>(this.path, false); // Disabled SetToState because for some reason something goes wrong resulting in no data shown on home page in production.
   }
}