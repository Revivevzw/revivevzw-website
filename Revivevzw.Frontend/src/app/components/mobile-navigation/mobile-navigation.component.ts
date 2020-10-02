import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-mobile-navigation',
  templateUrl: './mobile-navigation.component.html',
  styleUrls: ['./mobile-navigation.component.scss']
})
export class MobileNavigationComponent implements OnInit {

  public navigationIsOpen = false;

  public toggleNavigation = () => {
    this.navigationIsOpen = !this.navigationIsOpen;
  }

  ngOnInit(): void {
  }

  public ctaAction = () => {
    this.toggleNavigation();
    const url = "https://shop.revivevzw.be/SHOP/SHOP.aspx";
    window.open(url, '_blank');
  }
}
