import { Component, OnInit } from '@angular/core';
import {Post} from '../../models/post';
import {PostService} from '../../services/post.service';
import {MatDialog} from '@angular/material';

@Component({
  selector: 'app-post-container',
  templateUrl: './post-container.component.html',
  styleUrls: ['./post-container.component.css']
})
export class PostContainerComponent implements OnInit {
  posts: Post[] = [];
  postCount = 0;
  constructor(private postService: PostService) { }

  ngOnInit() {
    this.postService.getPosts().subscribe(posts => {
      this.posts = posts;
      console.log(posts[0]);
      this.postCount = posts.length;
      console.log(posts);
    });
    this.postService.createPostObservable.subscribe((newPost: Post) => {
      this.posts.unshift(newPost);
      this.postCount++;
    });
  }

}
