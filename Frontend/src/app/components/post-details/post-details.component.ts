import { Component, OnInit } from '@angular/core';
import { Post } from '../../models/post';
import { Comment } from '../../models/comment';
import { ActivatedRoute, Router } from '@angular/router';
import { PostService } from '../../services/post.service';
import { CommentService } from '../../services/comment.service';
import {FormControl, Validators} from "@angular/forms";


@Component({
  selector: 'app-post-details',
  templateUrl: './post-details.component.html',
  styleUrls: ['./post-details.component.scss']
})
export class PostDetailsComponent implements OnInit {
  post: Post;
  comments: Comment[];
  postId: Number;
  newEmail: string;
  newText: string;
  emailControl = new FormControl('', [Validators.required, Validators.email]);

  constructor(private postService: PostService,
              private commentService: CommentService,
              private router: Router,
              private activatedRoute: ActivatedRoute) { }

  ngOnInit() {
    this.activatedRoute.params.subscribe((params) => {
      this.postId = params['id'];
    });
    this.postService.getPost(this.postId).subscribe(post => {
      if (post == null) {
        this.router.navigate(['posts']);
      } else {
        this.post = post;
      }
    });

    this.commentService.getComments(this.postId).subscribe(comments => {
      this.comments = comments;
    });
  }

  getEmailErrorMessage() {
    return this.emailControl.hasError('required') ? 'You must enter a value' :
      this.emailControl.hasError('email') ? 'Not a valid email' :
        '';
  }

  isNewCommentEmpty(): boolean {
    if (this.newEmail && this.newText) {
      return false;
    }
    return true;
  }

  saveNewComment() {
    let commentToSave: Comment = new Comment();
    if (this.newEmail != null && this.newText != null) {
      if (this.newEmail.length > 0 && this.newText.length > 0) {
        commentToSave.email = this.newEmail;
        commentToSave.text = this.newText;
        this.commentService.createComment(commentToSave, this.post.id).subscribe(() => {
          location.reload();
        });
      }
    }
  }

  removePost() {
    this.postService.deletePost(this.post.id).subscribe(() => {
        this.router.navigate(['posts']);
      });
  }
}

