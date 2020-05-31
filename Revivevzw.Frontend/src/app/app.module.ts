import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
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
import { NewsItemApiService, LocalizeService, ApiService, ActivityApiService } from './services';
import { SupportUsComponent } from './pages/support-us/support-us.component';



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
    TranslateModule.forRoot({
      loader: {
          provide: TranslateLoader,
          useFactory: HttpLoaderFactory,
          deps: [HttpClient]
      }
  })
  ],
  providers: [
    HttpClient,
    GoogleSheetApiService,
    NewsItemApiService,
    LocalizeService,
    ApiService,
    ActivityApiService
  ],
  bootstrap: [AppComponent]
})

export class AppModule {
  constructor(translate: TranslateService) {
      translate.use('nl-BE');
  }
}

export function HttpLoaderFactory(http: HttpClient) {
  return new TranslateHttpLoader(http);
}
