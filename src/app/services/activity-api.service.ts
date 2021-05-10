import { Injectable } from '@angular/core';
import { ApiService } from './api.service';
import { Activity, Localization } from '../models';
import { KeyValue } from '@angular/common';

@Injectable({
   providedIn: 'root'
})
export class ActivityApiService {

   constructor(private apiService: ApiService) { }

   public getUpcoming = () => {
      return this.apiService.get<Array<Activity>>("activity/upcoming");
   }

   public getPast(){
      return this.apiService.get<Activity[]>("activity/past");
   }

   public get = (id: number) => {
      return this.apiService.get<Activity>("activity/" + id);
   }

   public getTypes = () => {
      return <Array<KeyValue<number, Localization>>>[
         { key: 36, value: { nl: "Fundraiser", fr: "Fundraiser", en: "Fundraiser" } },
         { key: 35, value: { nl: "Missie", fr: "Opération", en: "Operation" } },
         { key: 107, value: { nl: "Scouting", fr: "Repérage", en: "Scouting" } },
      ];
   }
}