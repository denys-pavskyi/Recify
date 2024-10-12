import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { CsvUploadComponent } from './components/csv-upload/csv-upload.component';
import { RecommenderSettingsComponent } from './components/recommender-settings/recommender-settings.component';
import { LoginComponent } from './components/login/login.component';

export const routes: Routes = [
  { path: '', component: LoginComponent },
  { path: 'home', component: HomeComponent },
  { path: 'upload-csv', component: CsvUploadComponent },
  { path: 'recommender-settings', component: RecommenderSettingsComponent },
  { path: '**', redirectTo: '' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }