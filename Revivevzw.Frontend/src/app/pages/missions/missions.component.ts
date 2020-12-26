import { KeyValue } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { Localization, Mission } from 'src/app/models';
import { LocalizeService, MissionApiService } from 'src/app/services';

@Component({
  selector: 'app-missions',
  templateUrl: './missions.component.html',
  styleUrls: ['./missions.component.scss']
})
export class MissionsComponent implements OnInit {

  constructor(private missionApi: MissionApiService, public localize: LocalizeService) { }

  public missions: Mission[];
  public missionsByYear: KeyValue<number, Mission[]>[] = [];

  ngOnInit(): void {
    this.SetMissions();
  }

  public splitInterventions = (localization: Localization) => {
    const data = this.localize.localizeData(localization);
    var split = data.split(/[\s, -]+/).filter(x => x);
    return split;
  }

  private SetMissions() {
    this.missionApi.getAll().subscribe(result => {
      if (!result) return;

      this.missions = result;
      this.missionsByYear = result.reduce((previous, current) => {
        const year = new Date(current.startDate).getFullYear();
        let missions = previous.find(x => x.key == year);
        if (!missions) {
          missions = { key: year, value: [] };
          previous.push(missions);
        }
        (missions.value).push(current);
        return previous;
      }, []);

      this.missionsByYear.sort((a, b) => b.key - a.key);
    });
  }

}
