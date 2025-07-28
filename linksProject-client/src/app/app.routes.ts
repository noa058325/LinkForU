import { Routes } from '@angular/router';
import { HomePageComponent } from './components/home-page/home-page.component';
import { LoginComponent } from './components/login/login.component';

export const routes: Routes = [
  { path: '', component: HomePageComponent },
  { path: 'login', component: LoginComponent },
  {
    path: 'web-list-by-category/:id',
    loadComponent: () =>
      import('./components/web-list-by-category/web-list-by-category-component').then(
        m => m.WebListByCategoryComponent
      )
  },
  {
    path: 'search',
    loadComponent: () =>
      import('./components/search-results/search-results.component').then(
        m => m.SearchResultsComponent
      )
  }
];
