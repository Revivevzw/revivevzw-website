import { Component, OnInit } from '@angular/core';
import { DomSanitizer, Meta } from '@angular/platform-browser';
import { Router } from '@angular/router';
import { LangChangeEvent, TranslateService } from '@ngx-translate/core';
import { forkJoin } from 'rxjs';
import { Carrousel, Localization, NewsItem, Sponsor } from 'src/app/models';
import { CarrouselApiService, LocalizeService, NewsItemApiService, SponsorApiService } from 'src/app/services';

@Component({
    selector: 'app-home',
    templateUrl: './home.component.html',
    styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
    constructor(
        private translateService: TranslateService,
        private meta: Meta,
        private router: Router,
        private sponsorApi: SponsorApiService,
        private newsItemApi: NewsItemApiService,
        private localizeService: LocalizeService,
        private carrouselApi: CarrouselApiService,
        private sanitizer: DomSanitizer
    ) {
        this.setData();
    }

    public sponsors: Sponsor[];
    public newsItems: NewsItem[];
    public loaded: boolean;
    public currentLanguage: string;
    public carrouselItems: Carrousel[];

    ngOnInit() {
        this.setMetaData();
        this.translateService.onLangChange.subscribe((params: LangChangeEvent) => this.currentLanguage = params.lang);
        window.addEventListener('resize', () => {
            this.loaded = false;
            setTimeout(() => {
                this.loaded = true;
            }, 1);
        })
    }

    // public $carrouselItems = this.carrouselApi.getCarrouselItems().pipe(map(x => x.map(y => Object.assign(y, { url: y.isEmbededYoutubeUrl ? this.buildYoutubeUrl(y.url) : y.url })).filter(y => new Date(y.expDate) > new Date())));
    // public $carrouselImages = this.$carrouselItems.pipe(map(x => x.filter(y => !y.isEmbededYoutubeUrl)));
    // public $carrouselYoutubeUrls = this.$carrouselItems.pipe(map(x => x.filter(y => y.isEmbededYoutubeUrl).map(y => this.buildYoutubeUrl(y.url))));

    public localize = (localization: Localization) => {
        return this.localizeService.localizeData(localization);
    }

    public buildYoutubeUrl(url: string) {
        return this.sanitizer.bypassSecurityTrustResourceUrl(url);
    }

    private setData = () => {
        forkJoin([
            this.sponsorApi.getAll(),
            this.newsItemApi.getAll(),
            // this.carrouselApi.getCarrouselItems(),
        ]).subscribe(results => {
            this.loaded = false;
            this.sponsors = this.sponsorApi.filterActiveSponsors(results[0]);
            this.newsItems = results[1];
            // this.carrouselItems = results[2].map(y => Object.assign(y, { url: y.isEmbededYoutubeUrl ? this.buildYoutubeUrl(y.url) : y.url })).filter(y => new Date(y.expDate) > new Date());
            this.loaded = true;
            console.log(this.carrouselItems);
            console.log(this.sponsors);
        })
    }

    private setMetaData = () => {
        this.meta.addTags([
            { name: "description", content: this.translateService.instant('HOME.HEAD_SUBTITLE') },
            { name: "keywords", content: 'Revive vzw, humanitaire hulp, vrijwilligers' }
        ])
    }

    public ctaAction = () => {
        this.router.navigate(["about"])
    }

    public redirectToSponsoring = () => {
        const url = "https://shop.revivevzw.be/shop/pergroep.aspx";
        window.open(url, '_blank');
    }

    public redirectToShop = () => {
        const url = "https://shop.revivevzw.be/";
        window.open(url, '_blank');
    }
}
