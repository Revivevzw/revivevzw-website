import { Injectable } from "@angular/core";
import { Organigram } from "../models/organigram.model";
import { ApiService } from "./api.service";

@Injectable({
    providedIn: 'root'
})

export class SettingApiService {

    constructor(private apiService: ApiService) { }

    private basePath = "setting";

    public getOrganigram() {
        const path = this.basePath + "/organigram";
        return this.apiService.get<Organigram>(path);
    }

}