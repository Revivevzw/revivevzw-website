import { Injectable } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { Localization } from '../models/index';

@Injectable({
   providedIn: 'root'
})
export class LocalizeService {

   constructor(private translateService: TranslateService) { }

   public localizeData = (localization: Localization): string => {
      let language = this.translateService.currentLang.slice(0,2);
      return localization[language] || localization['nl'];
   }
}