import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-call-to-action',
  templateUrl: './call-to-action.component.html',
  styleUrls: ['./call-to-action.component.scss']
})
export class CallToActionComponent implements OnInit {

  @Input() color: string;
  @Input() text: string;
  @Input() action: any;

  constructor() { }

  ngOnInit(): void {
  }

}
