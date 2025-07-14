import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';
import { HomePageComponent } from './home-page/home-page.component';
import { NavbarComponent } from './navbar/navbar.component';
import { CommentComponent } from './comment/comment.component';
@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterModule, HomePageComponent,NavbarComponent,CommentComponent],
  templateUrl: './app.component.html',
})
export class AppComponent {}