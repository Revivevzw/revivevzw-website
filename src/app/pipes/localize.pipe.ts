import { Pipe, PipeTransform } from "@angular/core";
import { Localization } from "../models";
import { LocalizeService } from "../services";

@Pipe({ name: 'localize', pure: false })
export class LocalizePipe implements PipeTransform {
   constructor(private localize: LocalizeService) { }
   transform(value: Localization): string {
      return this.localize.localizeData(value);
   }
}