import { Component, OnInit } from '@angular/core';
import { NewsItemApiService } from 'src/app/services/news-item-api.service';
import { NewsItem } from 'src/app/models/news-item.model';
import { Localization } from 'src/app/models/localization.model';
import { LocalizeService } from 'src/app/services/localize.service';

@Component({
  selector: 'app-news-bar',
  templateUrl: './news-bar.component.html',
  styleUrls: ['./news-bar.component.scss']
})
export class NewsBarComponent implements OnInit {

  constructor(
    private newsItemApiService: NewsItemApiService,
    private localizeService: LocalizeService,
  ) { }

  public newsItems: Array<NewsItem> = [];
  public isBusy: boolean = true;

  ngOnInit(): void {
    this.SetNewsItems();
  }

  public localize = (localization: Localization) => {
    return this.localizeService.localizeData(localization);
  }

  private SetNewsItems = () => {
    this.isBusy = true;
    this.newsItemApiService.getAll().subscribe(newsItems => {
      this.newsItems = newsItems;
      this.isBusy = false;
    })
  }
}
