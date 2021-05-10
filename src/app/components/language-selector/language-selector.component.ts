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
    const language = localStorage.getItem('language') || this.translateService.currentLang;
    return language;
  }

  public changeLanguage = (language: string) => {
    localStorage.setItem('language', language);
    this.translateService.use(language);
  }
}
