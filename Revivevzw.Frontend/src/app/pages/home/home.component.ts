import { Component, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { Meta } from '@angular/platform-browser';
import { KeyValue } from '@angular/common';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  constructor(
    private translateService: TranslateService,
    private meta: Meta
  ) { }

  private translations: Array<KeyValue<string, string>>;

  ngOnInit() {
    this.setTranslations().then(this.setMetaData);
  }

  private setMetaData = () => {
    this.meta.addTags([
      {name: "description", content: this.translations['HOME.HEAD_SUBTITLE']},
      {name: "keywords", content: 'Revive vzw, humanitaire hulp, vrijwilligers'}
    ])
  }

  private setTranslations = () => {
    return new Promise((resolve, reject) => {
      this.translateService.get([
        'HOME.HEAD_SUBTITLE'
      ]).subscribe(result => {
        this.translations = result;
        resolve(); 
      });
    })
  }

  public ctaAction = () => {
    console.log('action');
  } 
}
