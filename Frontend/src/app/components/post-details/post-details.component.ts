import { Component, OnInit } from '@angular/core';
import {Post} from '../../models/post';
import { Comment } from '../../models/comment';

@Component({
  selector: 'app-post-details',
  templateUrl: './post-details.component.html',
  styleUrls: ['./post-details.component.css']
})
export class PostDetailsComponent implements OnInit {
  post: Post;
  comments: Comment[];
  constructor() { }

  ngOnInit() {
  }

}
