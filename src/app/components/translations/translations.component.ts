import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { DomSanitizer } from '@angular/platform-browser';

@Component({
  selector: 'app-translations',
  templateUrl: './translations.component.html',
  styleUrls: ['./translations.component.scss']
})
export class TranslationsComponent implements OnInit {
  private code = "1sXP2Ed6FHkzj_hfJjzTS8aamQmqAaolzkBW4W0kXE7I";
  private url = "https://spreadsheets.google.com/feeds/cells/" + this.code + "/1/public/full?alt=json";

  private nlColNr = 2;
  private frColNr = 3;
  private enColNr = 4;

  public downloadUrls = [];

  constructor(
    private http: HttpClient,
    private sanitizer: DomSanitizer
  ) { }

  ngOnInit(): void {
    this.generateJsonFiles();
  }

  public generateJsonFiles = () => {
    this.downloadUrls = [];
    this.getTranslations().subscribe(x => {
      let entry = x.feed.entry;

      let nl = this.formatTranslations(entry, this.nlColNr);
      let fr = this.formatTranslations(entry, this.frColNr);
      let en = this.formatTranslations(entry, this.enColNr);

      this.createJsonFile("nl-BE", nl);
      this.createJsonFile("fr-BE", fr);
      this.createJsonFile("en-GB", en);
    })
  }

  private getTranslations = () => {
    return this.http.get<any>(this.url);
  }

  private formatTranslations = (entry: any, languageCol: number) => {
    let translations = {};
    let keys = entry.filter(cell => cell.gs$cell.row != 1 && cell.gs$cell.col == 1).map(cell => <any>{ "row": cell.gs$cell.row, "key": cell.gs$cell.inputValue });
    keys.forEach(key => {
      let cell = entry.find(cell => cell.gs$cell.row == key.row && cell.gs$cell.col == languageCol);
      translations[key.key.trim()] = cell == null ? "" : cell.gs$cell.inputValue;
    });
    return translations;
  }

  private createJsonFile = (langCode: string, translations: any) => {
    var json = JSON.stringify(translations);
    var uri = this.sanitizer.bypassSecurityTrustUrl("data:text/json;charset=UTF-8," + encodeURIComponent(json));
    this.downloadUrls.push({'name': langCode, 'url': uri})
  }
}
