import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { ScullyLibModule } from '@scullyio/ng-lib';
import { TranslateModule, TranslateLoader, TranslateService } from '@ngx-translate/core';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { GoogleSheetApiService } from './services/google-sheet-api.service';
import { HeaderSecondaryComponent, TranslationsComponent, NavigationComponent, LanguageSelectorComponent, FooterComponent, MobileNavigationComponent, NewsBarComponent, CallToActionComponent } from './components';
import { HomeComponent, AboutComponent, SponsorsComponent, MissionsComponent, VolunteersComponent, CalendarComponent } from './pages';
import { NewsItemApiService, LocalizeService, ApiService, ActivityApiService, MailchimpApiService, MailApiService, MissionApiService } from './services';
import { SupportUsComponent } from './pages/support-us/support-us.component';
import { CalendarDetailComponent } from './pages/calendar-detail/calendar-detail.component';
import { MissionDetailComponent } from './pages/mission-detail/mission-detail.component';
import { ContactComponent } from './pages/contact/contact.component';
import { HighlightComponent } from './components/highlight/highlight.component';
import { MainPageBaseComponent } from './components/main-page-base/main-page-base.component';
import { GdprComponent } from './pages/gdpr/gdpr.component';
import { ServiceWorkerModule } from '@angular/service-worker';
import { environment } from '../environments/environment';
import { ToastrModule } from 'ngx-toastr';
import { HomeSectionComponent } from './components/home-section/home-section.component';
import {IvyCarouselModule} from 'angular-responsive-carousel';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { LocalizePipe } from './pipes/localize.pipe';


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    AboutComponent,
    TranslationsComponent,
    NavigationComponent,
    LanguageSelectorComponent,
    FooterComponent,
    MobileNavigationComponent,
    NewsBarComponent,
    CallToActionComponent,
    SponsorsComponent,
    MissionsComponent,
    VolunteersComponent,
    CalendarComponent,
    HeaderSecondaryComponent,
    SupportUsComponent,
    CalendarDetailComponent,
    MissionDetailComponent,
    ContactComponent,
    HighlightComponent,
    MainPageBaseComponent,
    GdprComponent,
    HomeSectionComponent,
    LocalizePipe
  ],
  imports: [
    BrowserAnimationsModule,
    BrowserModule,
    AppRoutingModule,
    ScullyLibModule,
    ScullyLibModule.forRoot({useTransferState: true, alwaysMonitor: true}),
    HttpClientModule,
    FormsModule,
    CommonModule,
    ReactiveFormsModule,
    IvyCarouselModule,
    ToastrModule.forRoot({
      positionClass: 'toast-bottom-right',
    }),
    TranslateModule.forRoot({
      loader: {
          provide: TranslateLoader,
          useFactory: HttpLoaderFactory,
          deps: [HttpClient]
      }
  }),
    ServiceWorkerModule.register('ngsw-worker.js', { enabled: environment.production }),
    NgbModule
  ],
  providers: [
    HttpClient,
    GoogleSheetApiService,
    NewsItemApiService,
    LocalizeService,
    ApiService,
    ActivityApiService,
    MailchimpApiService,
    MailApiService,
    MissionApiService
  ],
  bootstrap: [AppComponent]
})

export class AppModule {
  constructor(translate: TranslateService) {
      const language = localStorage.getItem('language') || 'nl-BE';
      translate.use(language);
  }
}

export function HttpLoaderFactory(http: HttpClient) {
  return new TranslateHttpLoader(http);
}
