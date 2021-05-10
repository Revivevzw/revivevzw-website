import { Component, OnInit } from '@angular/core';
import { SponsorApiService } from 'src/app/services';
import { Sponsor } from 'src/app/models';
import { Meta } from '@angular/platform-browser';
import { TranslateService } from '@ngx-translate/core';
import { KeyValue } from '@angular/common';

@Component({
  selector: 'app-sponsors',
  templateUrl: './sponsors.component.html',
  styleUrls: ['./sponsors.component.scss']
})
export class SponsorsComponent implements OnInit {

  constructor(
    private sponsorApi: SponsorApiService,
    private translateService: TranslateService,
    private meta: Meta
    ) { }

  public sponsors: Array<Sponsor>;
  public translations: Array<KeyValue<string, string>>;

  ngOnInit(): void {
    this.setSponsors();
    this.setTranslations().then(this.setMetaData);
  }

  private setMetaData = () => {
    this.meta.addTags([
      {name: "description", content: "We present you our sponsors!"},
      {name: "keywords", content: 'Sponsors, logo, logos'}
    ])
  }

  private setTranslations = (): Promise<void> => {
    return new Promise((resolve) => {
      this.translateService.get([
        'HOME.HEAD_SUBTITLE'
      ]).subscribe(result => {
        this.translations = result;
        resolve(); 
      });
    })
  }

  private setSponsors = () => {
    this.sponsorApi.getAll().subscribe(result => {
      this.sponsors = this.sponsorApi.filterActiveSponsors(result);
    })
  }
}
