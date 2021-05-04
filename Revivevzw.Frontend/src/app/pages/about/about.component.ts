import { Component, OnInit } from '@angular/core';
import { Setting } from 'src/app/models/setting.model';
import { SettingApiService } from 'src/app/services/setting-api.service';
import { GoogleSheetApiService } from '../../services/google-sheet-api.service';

@Component({
  selector: 'app-about',
  templateUrl: './about.component.html',
  styleUrls: ['./about.component.scss']
})
export class AboutComponent implements OnInit {
  cells: any;
  public setting: Setting;

  constructor(private settingApi: SettingApiService) {}

  ngOnInit() {
    this.settingApi.getOrganigram().subscribe(x => {
      this.setting = x;
    });
  }
}
