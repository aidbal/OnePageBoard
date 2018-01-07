import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {
  MatToolbarModule,
  MatButtonModule, MatCardModule, MatIconModule, MatDialogModule
} from '@angular/material';
import { AppComponent } from './app.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { PostComponent } from './components/post/post.component';
import { PostContainerComponent } from './components/post-container/post-container.component';
import {PostService} from './services/post.service';
import {Constants} from './constants';
import {HttpClientModule} from '@angular/common/http';
import { PostDetailsComponent } from './components/post-details/post-details.component';
import {RouterModule, Routes} from '@angular/router';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    PostComponent,
    PostContainerComponent,
    PostDetailsComponent,
  ],
  imports: [
    BrowserModule,
    MatToolbarModule,
    MatButtonModule,
    MatCardModule,
    MatIconModule,
    MatDialogModule,
    HttpClientModule,
    RouterModule,
  ],
  providers: [
    PostService,
    Constants
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
