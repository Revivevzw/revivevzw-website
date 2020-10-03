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
    private sponsorApiService: SponsorApiService,
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

  private setSponsors = () => {
    this.sponsorApiService.getAll().subscribe(result => {
      this.sponsors = this.filterActiveSponsors(result);
    })
  }

  private filterActiveSponsors = (sponsors: Array<Sponsor>) => {
    return sponsors.filter(s => !s.endDate || new Date(s.endDate) <= new Date()).sort((a, b) => b.amount - a.amount)
  }

}
