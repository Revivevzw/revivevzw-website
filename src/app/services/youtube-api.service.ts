import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
    providedIn: 'root'
})
export class YoutubeApiService {

    public url = 'https://www.googleapis.com/youtube/v3/';

    constructor(private http: HttpClient) { }

    public getDetails(id: string) {
        const path = `${this.url}search?key=${environment.youtubeApiKey}&id=${id}`
        return this.http.get(path);
    }
}
