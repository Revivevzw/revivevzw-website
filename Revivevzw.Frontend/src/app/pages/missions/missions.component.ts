import { KeyValue } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { Mission } from 'src/app/models';
import { MissionApiService } from 'src/app/services';

@Component({
  selector: 'app-missions',
  templateUrl: './missions.component.html',
  styleUrls: ['./missions.component.scss']
})
export class MissionsComponent implements OnInit {

  constructor(private missionApi: MissionApiService) { }

  public missions: Mission[];
  public missionsByYear: KeyValue<number, Mission[]>[] = [];
  public imageUrl: "url('src/assets/media/header-img.jpg')"

  ngOnInit(): void {
    this.SetMissions();
  }

  public goToDetail(id: number){
    
  }

  private SetMissions(){
    this.missionApi.getAll().subscribe(result => {
      this.missions = result;

      this.missionsByYear = result.reduce((previous, current) => {
        const year = current.startDate.getFullYear();
        return (previous[year] = previous[year] || []).push(current);
      }, {});

      console.log(this.missionsByYear);
    })
  }

}
