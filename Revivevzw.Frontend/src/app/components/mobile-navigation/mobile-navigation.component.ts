import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-mobile-navigation',
  templateUrl: './mobile-navigation.component.html',
  styleUrls: ['./mobile-navigation.component.scss']
})
export class MobileNavigationComponent implements OnInit {

  public navigationIsOpen = false;

  constructor(
  ) { }

  public toggleNavigation = () => {
    this.navigationIsOpen = !this.navigationIsOpen;
  }

  ngOnInit(): void {
  }
}
