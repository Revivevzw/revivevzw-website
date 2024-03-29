import { Injectable } from '@angular/core';
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
      return this.apiService.get<Array<Sponsor>>(this.path + '/all', false);
   }

   public filterActiveSponsors = (sponsors: Array<Sponsor>) => {
      return sponsors.filter(s => !s.endDate || new Date(s.endDate) <= new Date()).sort((a, b) => b.amount - a.amount)
    }
}