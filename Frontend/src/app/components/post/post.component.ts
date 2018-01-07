import {Component, Input, OnInit} from '@angular/core';
import {Post} from '../../models/post';
import {PostService} from '../../services/post.service';
import {Router} from '@angular/router';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.scss']
})
export class PostComponent implements OnInit {
  @Input() post: Post;
  @Input() posts: Post[];
  constructor(private postService: PostService, private router: Router) { }

  ngOnInit() {
  }

  removePost(postId) {
    const index = this.posts.findIndex(post => post.id === postId);
    this.postService.deletePost(postId).subscribe(() => {
      },
      error => {
      });
    this.posts.splice(index, 1);
  }

  showPost(postId) {
    this.router.navigate(['posts', 'detail', postId]);
  }
}
