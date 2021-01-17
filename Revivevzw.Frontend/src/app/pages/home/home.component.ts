import { Component, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { Meta } from '@angular/platform-browser';
import { KeyValue } from '@angular/common';
import { Router } from '@angular/router';
import { SponsorApiService } from 'src/app/services';
import { forkJoin } from 'rxjs';
import { Sponsor } from 'src/app/models';

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
    private sponsorApi: SponsorApiService
  ) { }

  private translations: Array<KeyValue<string, string>>;
  public sponsors: Sponsor[];
  // public images: { path: string }[];
  public loaded: boolean;

  ngOnInit() {
    this.setData().then(this.setMetaData);
    window.addEventListener('resize', () => {
      this.loaded = false;
      setTimeout(() => {
        this.loaded = true;
      }, 1);
    })
  }

  private setData = (): Promise<void> => {
    this.loaded = false;
    return new Promise((resolve) => {
      forkJoin([
        this.translateService.get(['HOME.HEAD_SUBTITLE']),
        this.sponsorApi.getAll()
      ]).subscribe(results => {
        this.loaded = false;
        this.translations = results[0];
        this.sponsors = this.sponsorApi.filterActiveSponsors(results[1]);
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

  public redirectToShop = () => {
    const url = "https://shop.revivevzw.be/";
    window.open(url, '_blank');
  }
}
