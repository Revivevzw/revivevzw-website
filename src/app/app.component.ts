import { Component, OnInit, AfterViewInit, ViewChild, ElementRef, Renderer2 } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit, AfterViewInit {
  title = 'revive-vzw';

  constructor(private renderer: Renderer2) {}

  ngOnInit() { }

  @ViewChild('newsBar', { read: ElementRef }) public newsBar: ElementRef<any>;
  @ViewChild('navigation', { read: ElementRef }) public navigation: ElementRef<any>;

  ngAfterViewInit() {
    // window.addEventListener('scroll', this.scrolled);
  }

  private scrolled = () => {
    let newsBarBoundingClientRect = this.newsBar.nativeElement.getBoundingClientRect();
    if (newsBarBoundingClientRect.height + newsBarBoundingClientRect.y <= 0) {
      this.renderer.setStyle(this.navigation.nativeElement, 'position', 'fixed');
      this.renderer.addClass(this.navigation.nativeElement.children[0], 'header--scrolled');
    } else {
      this.renderer.setStyle(this.navigation.nativeElement, 'position', 'static');
      this.renderer.removeClass(this.navigation.nativeElement.children[0], 'header--scrolled');
    }
  }
}
