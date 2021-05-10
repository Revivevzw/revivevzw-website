import { Injectable } from '@angular/core';
import { ApiService } from './api.service';

@Injectable({
  providedIn: 'root'
})
export class PersonApiService {

  constructor(
    private apiService: ApiService
  ) { }

  private path = "person";

  public subscribe(email: string) {
    const path = this.path + '/subscribe';
    return this.apiService.post(path, { email: email });
  }
}
