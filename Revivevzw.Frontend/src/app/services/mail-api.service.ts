import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Mail } from '../models';
import { ApiService } from './api.service';

@Injectable({
  providedIn: 'root'
})
export class MailApiService {

  constructor(private apiService: ApiService) { }

  public send(mail: Mail){
    let url = "email/send";
    return this.apiService.post(url, mail);
  }
}
