import { Component, OnInit } from '@angular/core';
import { ActivityApiService, LocalizeService } from 'src/app/services';
import { Activity, Localization } from 'src/app/models';
import { KeyValue } from '@angular/common';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-calendar',
  templateUrl: './calendar.component.html',
  styleUrls: ['./calendar.component.scss']
})
export class CalendarComponent implements OnInit {

  constructor(
    private activityApiService: ActivityApiService,
    private localizeService: LocalizeService
  ) { }

  public activities: Array<Activity>;
  public activityTypes: Array<KeyValue<number, Localization>>;

  public localize = (localization: Localization) => {
    return this.localizeService.localizeData(localization);
  }

  public getType = (key: number) => {
    let result = this.activityTypes.find(x => x.key == key);
    return (result && result.value) || <Localization>{ nl: "Andere", fr: "Autres", en: "Other" }
  }

  public getRouterLink = (id: number) => "['/calendar-detail/" + id + "']";

  ngOnInit(): void {
    this.activityTypes = this.activityApiService.getTypes();
    this.activityApiService.getUpcoming().subscribe(result => {
      this.activities = result;
    })
  }

}
