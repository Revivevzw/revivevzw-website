import { Component, OnInit, AfterViewInit, ViewChild, ElementRef, Renderer2 } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit, AfterViewInit {
  title = 'revive-vzw';

  constructor(private renderer: Renderer2) { }

  ngOnInit() { }

  @ViewChild('navigation', { read: ElementRef }) public navigation: ElementRef<any>;

  ngAfterViewInit() {
    window.addEventListener('scroll', this.scrolled);
  }

  private scrolled = () => {
    if (window.scrollY > 0) {
      this.renderer.addClass(this.navigation.nativeElement.children[0], 'header--scrolled');
    } else {
      this.renderer.removeClass(this.navigation.nativeElement.children[0], 'header--scrolled');
    }
  }
}
