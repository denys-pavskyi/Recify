import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CsvUploadComponent } from './components/csv-upload/csv-upload.component';
import { RecommenderSettingsComponent } from './components/recommender-settings/recommender-settings.component';
import { LoginComponent } from './components/login/login.component';
import { AuthGuard } from './guards/auth.guard';
import { RecommenderTestingComponent } from './components/recommender-testing/recommender-testing.component';
import { RecommenderApiComponent } from './components/recommender-api/recommender-api.component';
import { DataComponent } from './components/data/data.component';

export const routes: Routes = [
  { path: '', redirectTo: '/login', pathMatch: 'full' },
  { path: 'login', component: LoginComponent },
  { path: 'upload-csv', component: CsvUploadComponent, canActivate: [AuthGuard] },
  { path: 'data', component: DataComponent, canActivate: [AuthGuard] },
  { path: 'recommender-settings', component: RecommenderSettingsComponent, canActivate: [AuthGuard] },
  { path: 'recommender-testing', component: RecommenderTestingComponent, canActivate: [AuthGuard] },
  { path: 'recommender-api', component: RecommenderApiComponent, canActivate: [AuthGuard] },
  { path: '**', redirectTo: '/login' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }