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
    return this.apiService.get<Mission[]>(this.basePath + "/all");
  }

  public getById(id: number){
    return this.apiService.get<Mission>(this.basePath + "/" + id);
  }
}
