import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Sponsor } from '../models/index';
import { ApiService } from './api.service';

@Injectable({
   providedIn: 'root'
})
export class SponsorApiService {

   constructor(
      private apiService: ApiService
   ) { }

   private path = "sponsor";

   public getAll = () => {
      let url = environment.revivevzwApiUrl + this.path;
      return this.apiService.get<Array<Sponsor>>(url + '/all');
   }
}