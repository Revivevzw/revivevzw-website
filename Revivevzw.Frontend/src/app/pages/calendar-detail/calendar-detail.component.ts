import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Activity } from 'src/app/models';
import { ActivityApiService } from 'src/app/services';
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

  constructor(private route: ActivatedRoute, private activityApiService: ActivityApiService) { }

  ngOnInit() {
    this.sub = this.route.params.subscribe(params => {
      this.id = +params['id'];
      this.activityApiService.get(+params['id']).subscribe(result => {
        console.log(result);
        this.activity = result;
      })
    });
  }

  ngOnDestroy() {
    this.sub.unsubscribe();
  }
}
