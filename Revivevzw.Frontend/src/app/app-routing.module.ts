import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';
import { AboutComponent } from './pages/about/about.component';
import { TranslationsComponent } from './components/translations/translations.component';
import { MissionsComponent } from './pages/missions/missions.component';
import { SponsorsComponent } from './pages/sponsors/sponsors.component';
import { CalendarComponent } from './pages/calendar/calendar.component';
import { VolunteersComponent } from './pages/volunteers/volunteers.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  // { path: 'about', component: AboutComponent },
  // { path: 'missions', component: MissionsComponent },
  { path: 'sponsors', component: SponsorsComponent },
  { path: 'calendar', component: CalendarComponent },
  { path: 'volunteers', component: VolunteersComponent },
  { path: 'translations', component: TranslationsComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
