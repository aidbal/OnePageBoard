import { Component, OnInit } from '@angular/core';
import { Post } from '../../models/post';
import { Comment } from '../../models/comment';
import { ActivatedRoute, Router } from '@angular/router';
import { PostService } from '../../services/post.service';
import { CommentService } from '../../services/comment.service';


@Component({
  selector: 'app-post-details',
  templateUrl: './post-details.component.html',
  styleUrls: ['./post-details.component.scss']
})
export class PostDetailsComponent implements OnInit {
  post: Post;
  comments: Comment[];
  postId: Number;
  commentsLength: Number;
  editorEnabled: boolean[] = [];
  editableEmail: string[] = [];
  editableText: string[] = [];
  newEmail: string;
  newText: string;

  constructor(private postService: PostService,
              private commentService: CommentService,
              private router: Router,
              private activatedRoute: ActivatedRoute) { }

  ngOnInit() {
    this.activatedRoute.params.subscribe((params) => {
      this.postId = params['id'];
    });
    this.postService.getPost(this.postId).subscribe(post => {
      this.post = post;
    });
    this.commentService.getComments(this.postId).subscribe(comments => {
      this.comments = comments;
      this.commentsLength = this.comments.length;
      this.initializeArray();
    });
  }



  initializeArray() {
    for (let i = 0; i < this.commentsLength; i++) {
      this.editorEnabled[i] = false;
      this.editableEmail[i] = this.comments[i].email;
      this.editableText[i] = this.comments[i].text;
    }
  }

  enableEditor(editableId) {
    for (let i = 0; i < this.commentsLength; i++) {
      this.editorEnabled[i] = false;
    }
    this.editorEnabled[editableId] = true;
  }

  saveNewComment(postId){
    let commentToSave: Comment = new Comment();
    if (this.newEmail.length > 0 && this.newText.length > 0) {
      commentToSave.email = this.newEmail;
      commentToSave.text = this.newText;
      this.commentService.createComment(commentToSave, postId).subscribe(() => {
        location.reload();
      });
      //
    }
  }

  save(commentId, editableId) {
    let commentToSave: Comment;
    commentToSave = this.comments.find(x => x.id === commentId);
    if (commentToSave != null &&
      this.editableEmail.length > 0 &&
      this.editableText.length > 0 ) {
      commentToSave.email = this.editableEmail[editableId];
      commentToSave.text = this.editableText[editableId];
      this.commentService.updateComment(commentToSave, commentId).subscribe(() => {
        location.reload();
      });
    }
  }

  cancel(editableId) {
    this.editorEnabled[editableId] = false;
  }

  removePost(postId) {
    this.postService.deletePost(postId).subscribe(() => {
      },
      error => {
      });
    this.router.navigate(['posts']);
  }

  removeComment(commentId) {
    const index = this.comments.findIndex(comment => comment.id === commentId);
    this.commentService.deleteComment(commentId).subscribe(() => {
      },
      error => {
      });
    this.comments.splice(index, 1);
  }
}

