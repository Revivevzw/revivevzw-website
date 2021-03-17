import { KeyValue } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Route, Router } from '@angular/router';
import { Localization, Mission } from 'src/app/models';
import { LocalizeService, MissionApiService } from 'src/app/services';

@Component({
  selector: 'app-missions',
  templateUrl: './missions.component.html',
  styleUrls: ['./missions.component.scss']
})
export class MissionsComponent implements OnInit {

  constructor(
    private missionApi: MissionApiService,
    public localize: LocalizeService,
    private route: ActivatedRoute) { }

  public missions: Mission[];
  public missionsByYear: KeyValue<number, Mission[]>[] = [];
  public missionTypes: KeyValue<number, string>[] = [
    { key: 0, value: 'PLANNED_MISSIONS' },
    { key: 1, value: 'PLANNED_SCOUTINGS' },
    { key: 2, value: 'PAST_MISSIONS' },
    { key: 3, value: 'PAST_SCOUTINGS' }
  ]
  public selectedType: KeyValue<number, string>;

  ngOnInit(): void {
    this.setMissions();
    this.setKey();
  }

  public typeSelected = () => {
    const missions = this.missions.filter(x => x.type == this.selectedType.key);
    this.setMissionsByYear(missions);
  }

  private setKey() {
    this.route.params.subscribe(x => {
      if (x && x.key) {
        this.selectedType = this.missionTypes.find(y => y.key == x.key);
      } else {
        this.selectedType = this.missionTypes[2];
      }
    })
  }

  public splitInterventions = (localization: Localization) => {
    const data = this.localize.localizeData(localization);
    var split = data.split(/,|-|–/).filter(x => x).map(x => x.trim())
    return split;
  } 

  private setMissionsByYear = (missions: Mission[]) => {
    this.missionsByYear = missions.reduce((previous, current) => {
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
  }

  private setMissions() {
    this.missionApi.getAll().subscribe(result => {
      if (!result) return;

      this.missions = result;
      this.typeSelected();
    });
  }
}
