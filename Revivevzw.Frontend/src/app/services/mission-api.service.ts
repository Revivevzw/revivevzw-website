import { Injectable } from '@angular/core';
import { Mission } from '../models';
import { ApiService } from './api.service';

@Injectable({
  providedIn: 'root'
})
export class MissionApiService {

  constructor(private apiService: ApiService) { }

  private basePath = "mission";

  public getAll(){
    const path = this.basePath + "/all"
    return this.apiService.get<Mission[]>(path);
  }

  public getAllFromState(){
    const path = this.basePath + "/all"
    return this.apiService.getFromState<Mission[]>(path);
  }

  public getById(id: number){
    const path = this.basePath + "/" + id;
    return this.apiService.get<Mission>(path);
  }
}
