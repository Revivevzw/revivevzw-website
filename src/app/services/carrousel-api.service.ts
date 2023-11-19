import { Injectable } from "@angular/core";
import { ApiService } from "./api.service";
import { Carrousel } from "../models";

@Injectable({
    providedIn: 'root'
})
export class CarrouselApiService {
    constructor(private api: ApiService) { }

    public getCarrouselItems() {
        return this.api.get<Carrousel[]>("carrousel");
    }
}