import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-home-section',
  templateUrl: './home-section.component.html',
  styleUrls: ['./home-section.component.scss']
})
export class HomeSectionComponent {

  @Input() titleKey: string;
  @Input() subtitleKey: string;
  @Input() actionTitleKey: string;
  @Input() path: string;
  @Input() hasBackground: boolean;
  @Input() hasBorders: boolean;
}
