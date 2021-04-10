import { Component, OnInit } from '@angular/core';
import { trigger, transition, style, animate } from "@angular/animations";
import { NewsItemApiService } from 'src/app/services/news-item-api.service';
import { NewsItem } from 'src/app/models/news-item.model';
import { Localization } from 'src/app/models/localization.model';
import { LocalizeService } from 'src/app/services/localize.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-news-bar',
  templateUrl: './news-bar.component.html',
  styleUrls: ['./news-bar.component.scss'],
  animations: [
    trigger('newsBarAnimation', [
      transition('void => *', [
        style({ marginLeft: '100vw' }),
        animate('500ms ease-in-out', style({ marginLeft: 0 }))
      ]),
      transition('* => void', [
        animate('500ms ease-in-out', style({ marginLeft: '-100vw' }))
      ])
    ])
  ]
})
export class NewsBarComponent implements OnInit {

  constructor(
    private newsItemApiService: NewsItemApiService,
    private localizeService: LocalizeService,
    private router: Router
  ) { }

  public newsItems: Array<NewsItem> = [];

  public currentItem = 0;

  ngOnInit(): void {
    this.startAnimation();
    this.SetNewsItems();
  }

  public redirect = () => {
    const url = this.newsItems[this.currentItem].url
    if(!url) return;
    // this.router.navigate([url]);
    window.open(url, 'blank');
  }

  public localize = (localization: Localization) => {
    return this.localizeService.localizeData(localization);
  }

  private SetNewsItems = () => {
    this.newsItemApiService.getAll().subscribe(newsItems => {
      this.newsItems = newsItems;
    })
  }

  private startAnimation = () => {
    setInterval(() => {
      if (this.newsItems.length - 1 <= this.currentItem) {
        this.currentItem = 0;
      } else {
        this.currentItem += 1;
      }
    }, 6000)
  }
}
