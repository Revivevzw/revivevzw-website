import { Injectable } from '@angular/core';
import { ApiService } from './api.service';
import { environment } from 'src/environments/environment';
import { Activity, Localization } from '../models';
import { KeyValue } from '@angular/common';

@Injectable({
   providedIn: 'root'
})
export class ActivityApiService {

   constructor(private apiService: ApiService) { }

   private path = "activity";

   public getUpcoming = () => {
      return this.apiService.get<Array<Activity>>(environment.revivevzwApiUrl + this.path + "/upcoming");
   }

   public getTypes = () => {
      return <Array<KeyValue<number, Localization>>>[
         { key: 36, value: { nl: "Fundraiser", fr: "Fundraiser", en: "Fundraiser" } },
         { key: 35, value: { nl: "Missie", fr: "Opération", en: "Operation" } },
         { key: 107, value: { nl: "Scouting", fr: "Repérage", en: "Scouting" } },
      ];
   }
}