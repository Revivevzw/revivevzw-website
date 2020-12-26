import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';
import { AboutComponent } from './pages/about/about.component';
import { TranslationsComponent } from './components/translations/translations.component';
import { MissionsComponent } from './pages/missions/missions.component';
import { SponsorsComponent } from './pages/sponsors/sponsors.component';
import { CalendarComponent } from './pages/calendar/calendar.component';
import { VolunteersComponent } from './pages/volunteers/volunteers.component';
import { SupportUsComponent } from './pages/support-us/support-us.component';
import { CalendarDetailComponent } from './pages';
import { ContactComponent } from './pages/contact/contact.component';
import { GdprComponent } from './pages/gdpr/gdpr.component';
import { MissionDetailComponent } from './pages/mission-detail/mission-detail.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'about', component: AboutComponent },
  { path: 'missions', children: [
    { path: '', component: MissionsComponent },
    { path: ':id', component: MissionDetailComponent }
  ]},
  { path: 'sponsors', component: SponsorsComponent },
  { path: 'calendar', component: CalendarComponent },
  { path: 'calendar-detail/:id', component: CalendarDetailComponent },
  { path: 'volunteers', component: VolunteersComponent },
  { path: 'support-us', component: SupportUsComponent },
  { path: 'translations', component: TranslationsComponent },
  { path: 'contact', component: ContactComponent },
  { path: 'gdpr', component: GdprComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
