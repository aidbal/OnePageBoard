import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormControl, FormGroup, Validators} from "@angular/forms";
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
  emailControl = new FormControl('', [Validators.required, Validators.email]);
  titleControl = new FormControl('', Validators.required);

  constructor(private postService: PostService,
              private router: Router) { }

  ngOnInit() {
  }

  getTitleErrorMessage() {
    return this.titleControl.hasError('required') ? 'You must enter a value' :
        '';
  }

  getEmailErrorMessage() {
    return this.emailControl.hasError('required') ? 'You must enter a value' :
      this.emailControl.hasError('email') ? 'Not a valid email' :
        '';
  }

  isFormEmpty(): boolean {
    if (this.title && this.text && this.email) {
      return false;
    }
    return true;
  }

  public create() {

    if (!this.isFormEmpty()) {
      let post: Post = new Post();
      post.email = this.email;
      post.title = this.title;
      post.text = this.text;
      this.postService.createPost(post).subscribe(() => {
        this.router.navigate(['posts']);
      }, error => {

      });
    }
  }
}
