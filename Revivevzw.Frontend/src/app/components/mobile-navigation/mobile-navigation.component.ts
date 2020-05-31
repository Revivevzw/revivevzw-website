import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-mobile-navigation',
  templateUrl: './mobile-navigation.component.html',
  styleUrls: ['./mobile-navigation.component.scss']
})
export class MobileNavigationComponent implements OnInit {

  public navigationIsOpen = false;

  constructor(
    private router: Router
  ) { }

  public toggleNavigation = () => {
    this.navigationIsOpen = !this.navigationIsOpen;
  }

  ngOnInit(): void {
  }

  public ctaAction = () => {
    this.toggleNavigation();
    this.router.navigate(["support-us"]);
  }
}
