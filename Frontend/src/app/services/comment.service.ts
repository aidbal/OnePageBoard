import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {Constants} from '../constants';
import {Observable} from 'rxjs/Observable';
import {Comment} from '../models/comment';

@Injectable()
export class CommentService {

  constructor(private http: HttpClient, private constants: Constants) { }

  getComments(postId): Observable<Comment[]> {
    return this.http.get<Comment[]>(`${this.constants.commentsApiUrl}?postId=${postId}`, this.getRequestOptions());
  }

  getComment(commentId): Observable<Comment> {
    return this.http.get<Comment>(`${this.constants.commentsApiUrl}/${commentId}`, this.getRequestOptions());
  }

  createComment(body: Comment, postId) {
    return this.http.post(`${this.constants.commentsApiUrl}?postId=${postId}`, body, this.getRequestOptions())
      .map((response) => {
        body.id = parseInt(response['id'], 10);
      });
  }
  updateComment(body: Comment, commentId) {
    return this.http.put(`${this.constants.commentsApiUrl}/${commentId}`, body, this.getRequestOptions());
  }

  deleteComment(commentId) {
    return this.http.delete(`${this.constants.commentsApiUrl}/${commentId}`, this.getRequestOptions());
  }

  private getRequestOptions() {
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
    });
    return {headers: headers, withCredentials: true};
  }
}
