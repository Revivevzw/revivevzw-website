import { KeyValue } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Activity, Localization } from 'src/app/models';
import { ActivityApiService, LocalizeService } from 'src/app/services';

@Component({
  selector: 'app-calendar',
  templateUrl: './calendar.component.html',
  styleUrls: ['./calendar.component.scss']
})
export class CalendarComponent implements OnInit {

  constructor(
    private activityApiService: ActivityApiService,
    private localizeService: LocalizeService,
    private router: Router
  ) { }

  public activities: Array<Activity>;
  public activityTypes: Array<KeyValue<number, Localization>>;
  public calendarTitleKey: string;

  public localize = (localization: Localization) => {
    return this.localizeService.localizeData(localization);
  }

  public getType = (key: number) => {
    let result = this.activityTypes.find(x => x.key == key);
    return (result && result.value) || <Localization>{ nl: "Andere", fr: "Autres", en: "Other" }
  }

  // public getRouterLink = (id: number) => "['../detail/" + id + "']";

  ngOnInit(): void {
    this.activityTypes = this.activityApiService.getTypes();
    if (this.router.url.includes('past')) {
      this.calendarTitleKey = "PAST_EVENTS";
      this.activityApiService.getPast().subscribe(result => {
        this.activities = result;
      })
    } else {
      this.calendarTitleKey = "CALENDAR.TITLE";
      this.activityApiService.getUpcoming().subscribe(result => {
        this.activities = result;
      })
    }
  }

}
