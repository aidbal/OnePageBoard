import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {Post} from "../../models/post";
import {PostService} from "../../services/post.service";
import {Router} from "@angular/router";

@Component({
  selector: 'app-create-post',
  templateUrl: './create-post.component.html',
  styleUrls: ['./create-post.component.scss']
})
export class CreatePostComponent implements OnInit {
  email: string;
  text: string;
  title: string;

  constructor(private postService: PostService,
              private router: Router) { }

  ngOnInit() {
  }

  public create() {

    if (this.email.length > 0 &&
      this.title.length > 0 &&
        this.text.length > 0) {
      let post: Post = new Post();
      post.email = this.email;
      post.title = this.title;
      post.text = this.text;
      this.postService.createPost(post).subscribe(() => {
        this.router.navigate(['posts']);
      });
    }
  }
}
