import {Component, Input, OnInit} from '@angular/core';
import {CommentService} from '../../services/comment.service';
import { Comment } from '../../models/comment';
import {FormControl, Validators} from "@angular/forms";

@Component({
  selector: 'app-comment',
  templateUrl: './comment.component.html',
  styleUrls: ['./comment.component.scss']
})
export class CommentComponent implements OnInit {
  @Input() comment: Comment;
  editorEnabled = false;
  emailControl = new FormControl('', [Validators.required, Validators.email]);

  constructor(private commentService: CommentService) { }

  ngOnInit() {
  }

  getEmailErrorMessage() {
    return this.emailControl.hasError('required') ? 'You must enter a value' :
      this.emailControl.hasError('email') ? 'Not a valid email' :
        '';
  }

  isCommentEmpty(): boolean {
    if (this.comment.email && this.comment.text) {
      return false;
    }
    return true;
  }

  changeEditorState() {
    this.editorEnabled = !this.editorEnabled ;
  }

  removeComment() {
    this.commentService.deleteComment(this.comment.id).subscribe(() => {
      location.reload();
    });
  }

  save() {
    if (this.isCommentEmpty()) {
      this.commentService.updateComment(this.comment, this.comment.id).subscribe(() => {
        location.reload();
      });
    }
  }
}
