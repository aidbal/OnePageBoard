import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PostContainerComponent } from './components/post-container/post-container.component';
import { PostDetailsComponent} from './components/post-details/post-details.component';
import {CreatePostComponent} from "./components/create-post/create-post.component";

const routes: Routes = [
  { path: 'posts/detail/:id', component: PostDetailsComponent },
  { path: 'posts/create-post', component: CreatePostComponent },
  { path: 'posts', component: PostContainerComponent },
  { path: '', redirectTo: '/posts', pathMatch: 'full' }
];

@NgModule({
  imports: [ RouterModule.forRoot(routes) ],
  exports: [ RouterModule ]
})
export class AppRoutingModule {}
