import { Injectable } from '@angular/core';
import { Constants } from '../constants';
import {Observable} from 'rxjs/Observable';
import {Post} from '../models/post';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {ReplaySubject} from 'rxjs/ReplaySubject';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

@Injectable()
export class PostService {
  private _createPostSource = new ReplaySubject<Post>();
  public createPostObservable  = this._createPostSource.asObservable();

  constructor(private http: HttpClient, private constants: Constants) { }

  getPosts(): Observable<Post[]> {
    return this.http.get<Post[]>(this.constants.postsApiUrl, this.getRequestOptions());
  }

  getPost(postId): Observable<Post> {
    return this.http.get<Post>(`${this.constants.postsApiUrl}/${postId}`, this.getRequestOptions());
  }

  createPost(body: Post) {
    return this.http.post(this.constants.postsApiUrl, body, this.getRequestOptions())
      .map((response) => {
      body.id = parseInt(response['id'], 10);
      this._createPostSource.next(body);
      });
  }

  deletePost(postId) {
    return this.http.delete(`${this.constants.postsApiUrl}/${postId}`, this.getRequestOptions());
  }

  private getRequestOptions() {
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
    });
    return {headers: headers, withCredentials: true};
  }
}
