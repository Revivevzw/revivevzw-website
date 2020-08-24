import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Activity, Localization } from 'src/app/models';
import { ActivityApiService, LocalizeService } from 'src/app/services';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-calendar-detail',
  templateUrl: './calendar-detail.component.html',
  styleUrls: ['./calendar-detail.component.scss']
})
export class CalendarDetailComponent implements OnInit {
  public id: any;
  private sub: Subscription;
  public activity: Activity;

  constructor(
    private route: ActivatedRoute,
    private activityApiService: ActivityApiService,
    private localizeService: LocalizeService
  ) { }

  ngOnInit() {
    this.sub = this.route.params.subscribe(params => {
      this.id = +params['id'];
      this.activityApiService.get(+params['id']).subscribe(result => {
        this.activity = result;
      })
    });
  }

  public localize = (localization: Localization) => {
    return this.localizeService.localizeData(localization);
  }

  public reservateAction = () => {
    const url = "https://shop.revivevzw.be/ACTIVITEITEN/ShowOneACT.aspx?ID=" + this.id;
    window.open(url, '_blank');
  }

  ngOnDestroy() {
    this.sub.unsubscribe();
  }
}
