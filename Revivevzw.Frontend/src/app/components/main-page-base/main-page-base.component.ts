import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-main-page-base',
  templateUrl: './main-page-base.component.html',
  styleUrls: ['./main-page-base.component.scss']
})
export class MainPageBaseComponent implements OnInit {

  @Input() title: string;

  constructor() { }

  ngOnInit(): void {
  }

}
