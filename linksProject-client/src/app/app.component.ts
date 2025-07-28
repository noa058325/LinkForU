import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';
import { HomePageComponent } from './components/home-page/home-page.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { FooterComponent } from './components/footer/footer.component';
import { CommentComponent } from './components/comment/comment.component';
@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterModule,NavbarComponent,CommentComponent,FooterComponent],
  templateUrl: './app.component.html',
})
export class AppComponent {}