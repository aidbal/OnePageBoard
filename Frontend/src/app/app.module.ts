import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {
  MatToolbarModule,
  MatButtonModule, MatCardModule, MatIconModule, MatDialogModule, MatInputModule, ErrorStateMatcher
} from '@angular/material';
import { AppComponent } from './app.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { PostComponent } from './components/post/post.component';
import { PostContainerComponent } from './components/post-container/post-container.component';
import { PostService } from './services/post.service';
import { Constants } from './constants';
import { HttpClientModule, HttpClient } from '@angular/common/http';
import { PostDetailsComponent } from './components/post-details/post-details.component';
import { RouterModule, Routes} from '@angular/router';
import { AppRoutingModule } from './/app-routing.module';
import { CommentService } from './services/comment.service';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {HttpModule} from '@angular/http';
import {CreatePostComponent} from './components/create-post/create-post.component';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    PostComponent,
    PostContainerComponent,
    PostDetailsComponent,
    CreatePostComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    MatToolbarModule,
    MatButtonModule,
    MatCardModule,
    MatIconModule,
    MatDialogModule,
    HttpClientModule,
    HttpModule,
    RouterModule,
    AppRoutingModule,
    FormsModule,
    MatInputModule,
    ReactiveFormsModule
  ],
  providers: [
    PostService,
    CommentService,
    Constants,
    ErrorStateMatcher
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
