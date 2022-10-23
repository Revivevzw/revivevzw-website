import { Injectable } from "@angular/core";
import { Setting } from "../models/setting.model";
import { ApiService } from "./api.service";

@Injectable({
    providedIn: 'root'
})

export class SettingApiService {

    constructor(private apiService: ApiService) { }

    private basePath = "setting";

    public getOrganigram() {
        const path = this.basePath + "/organigram";
        return this.apiService.get<Setting>(path);
    }

    public getArticlesOfAssociation() {
        const path = this.basePath + "/articles-of-association";
        return this.apiService.get<Setting>(path);
    }

}