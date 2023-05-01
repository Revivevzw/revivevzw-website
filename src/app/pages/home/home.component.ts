import { Component, OnInit } from '@angular/core';
import { LangChangeEvent, TranslateService } from '@ngx-translate/core';
import { Meta } from '@angular/platform-browser';
import { KeyValue } from '@angular/common';
import { Router } from '@angular/router';
import { LocalizeService, NewsItemApiService, SponsorApiService } from 'src/app/services';
import { forkJoin } from 'rxjs';
import { Localization, NewsItem, Sponsor } from 'src/app/models';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  constructor(
    private translateService: TranslateService,
    private meta: Meta,
    private router: Router,
    private sponsorApi: SponsorApiService,
    private newsItemApi: NewsItemApiService,
    private localizeService: LocalizeService
  ) { }

  private translations: Array<KeyValue<string, string>>;
  public sponsors: Sponsor[];
  public newsItems: NewsItem[]; 
  public loaded: boolean;
  public currentLanguage: string;

  ngOnInit() {
    this.setData().then(this.setMetaData);
    this.translateService.onLangChange.subscribe((params: LangChangeEvent) => this.currentLanguage = params.lang);
    window.addEventListener('resize', () => {
      this.loaded = false;
      setTimeout(() => {
        this.loaded = true;
      }, 1);
    })
  }

  public localize = (localization: Localization) => {
    return this.localizeService.localizeData(localization);
  }

  private setData = (): Promise<void> => {
    this.loaded = false;
    return new Promise((resolve) => {
      forkJoin([
        this.translateService.get(['HOME.HEAD_SUBTITLE']),
        this.sponsorApi.getAll(),
        this.newsItemApi.getAll(),
      ]).subscribe(results => {
        this.loaded = false;
        this.translations = results[0];
        this.sponsors = this.sponsorApi.filterActiveSponsors(results[1]);
        this.newsItems = results[2].slice(0, 3);
        // this.images = this.sponsors.map(x => ({path: x.logoUrl}));
        this.loaded = true;
        resolve();
      })
    })
  }

  private setMetaData = () => {
    this.meta.addTags([
      { name: "description", content: this.translations['HOME.HEAD_SUBTITLE'] },
      { name: "keywords", content: 'Revive vzw, humanitaire hulp, vrijwilligers' }
    ])
  }

  public ctaAction = () => {
    this.router.navigate(["about"])
  }

  public redirectToSponsoring = () => {
    const url = "https://shop.revivevzw.be/shop/pergroep.aspx";
    window.open(url, '_blank');
  }

  public redirectToShop = () => {
    const url = "https://shop.revivevzw.be/";
    window.open(url, '_blank');
  }
}
