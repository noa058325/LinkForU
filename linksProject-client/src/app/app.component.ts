import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';
import { HomePageComponent } from './home-page/home-page.component';
import { NavbarComponent } from './navbar/navbar.component';
import { CommentComponent } from './comment/comment.component';
import { FooterComponent } from './footer/footer.component';
@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterModule, HomePageComponent,NavbarComponent,CommentComponent,FooterComponent],
  templateUrl: './app.component.html',
})
export class AppComponent {}