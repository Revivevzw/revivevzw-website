import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Mission } from 'src/app/models';
import { LocalizeService, MissionApiService } from 'src/app/services';

@Component({
  selector: 'app-mission-detail',
  templateUrl: './mission-detail.component.html',
  styleUrls: ['./mission-detail.component.scss']
})
export class MissionDetailComponent implements OnInit {

  public id: number;
  public mission: Mission;
  
  constructor(
    private route: ActivatedRoute,
    private missionApi: MissionApiService,
    public localizeService: LocalizeService
  ) { }

  ngOnInit(): void {
    this.setIdFromRoute().then(() => this.setMission())
    window.scroll(0,0);
  }

  private setMission(){
    this.missionApi.getById(this.id).subscribe(x => {
      this.mission = x;
    })
  }
  
  private setIdFromRoute(): Promise<void>{
    return new Promise((resolve, reject) => {
      this.route.paramMap.subscribe(x => {
        if (x.has('id')) this.id = parseInt(x.get('id'));
        resolve();
      });
    })
  }
}
