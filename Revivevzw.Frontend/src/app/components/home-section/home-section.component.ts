import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-home-section',
  templateUrl: './home-section.component.html',
  styleUrls: ['./home-section.component.scss']
})
export class HomeSectionComponent implements OnInit {

  @Input() titleKey: string;
  @Input() subtitleKey: string;
  @Input() actionTitleKey: string;
  @Input() path: string;
  @Input() hasBackground: boolean;

  constructor() { }

  ngOnInit(): void {
  }
}
