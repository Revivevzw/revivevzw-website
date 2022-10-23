import { Component, OnInit } from '@angular/core';
import { Setting } from 'src/app/models/setting.model';
import { LocalizeService } from 'src/app/services';
import { SettingApiService } from 'src/app/services/setting-api.service';

@Component({
  selector: 'app-about',
  templateUrl: './about.component.html',
  styleUrls: ['./about.component.scss']
})
export class AboutComponent implements OnInit {
  public organigram: Setting;
  public articlesOfAssociation: Setting;

  public get isPdf() {
    return this.localize.localizeData(this.organigram.url).endsWith('.pdf');
  }

  constructor(
    private settingApi: SettingApiService,
    private localize: LocalizeService
  ) {}

  ngOnInit() { 
    this.settingApi.getOrganigram().subscribe(x => {
      this.organigram = x;
    });
    this.settingApi.getArticlesOfAssociation().subscribe(x => {
      this.articlesOfAssociation = x;
    })
  }
}
