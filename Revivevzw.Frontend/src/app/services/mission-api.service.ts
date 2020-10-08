import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Mission } from '../models';
import { ApiService } from './api.service';

@Injectable({
  providedIn: 'root'
})
export class MissionApiService {

  constructor(private apiService: ApiService) { }

  private basePath = "mission";

  public getAll(){
    const url = environment.revivevzwApiUrl + this.basePath + "/all"
    return this.apiService.get<Mission[]>(url);
  }

  public getById(id: number){
    const url = environment.revivevzwApiUrl + this.basePath + "/" + id;
    return this.apiService.get<Mission>(url);
  }
}
