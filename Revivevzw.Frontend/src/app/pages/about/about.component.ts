import { Component, OnInit } from '@angular/core';
import { GoogleSheetApiService } from '../../services/google-sheet-api.service';

@Component({
  selector: 'app-about',
  templateUrl: './about.component.html',
  styleUrls: ['./about.component.scss']
})
export class AboutComponent implements OnInit {
  cells: any;

  constructor(
    private googleSheetApiService: GoogleSheetApiService
  ) { }

  ngOnInit() {
    this.googleSheetApiService.getTranslations().subscribe(x => {
      this.cells = x.feed.entry;
    });
  }
}
