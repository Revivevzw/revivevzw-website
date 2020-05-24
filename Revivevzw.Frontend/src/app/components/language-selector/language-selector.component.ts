import { Component, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-language-selector',
  templateUrl: './language-selector.component.html',
  styleUrls: ['./language-selector.component.scss']
})
export class LanguageSelectorComponent implements OnInit {

  constructor(
    private translateService: TranslateService
  ) { }

  ngOnInit(): void {
  }

  public getCurrentLanguage = () => {
    return this.translateService.currentLang;
  }

  public changeLanguage = (language: string) => {
    this.translateService.use(language);
  }

}
