import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';
import { HomePageComponent } from './home-page/home-page.component';
import { NavbarComponent } from './navbar/navbar.component';
@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterModule, HomePageComponent,NavbarComponent],
  templateUrl: './app.component.html',
})
export class AppComponent {}