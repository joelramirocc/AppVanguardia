import { Component, OnInit } from '@angular/core';
import { PostService } from '../core/post.service';
import { Post } from '../shared/models/Post';

@Component({
  selector: 'app-posts-list',
  templateUrl: './posts-list.component.html',
  styleUrls: ['./posts-list.component.css']
})
export class PostsListComponent implements OnInit {

  posts : Post[];
  selectedPost: Post;

  constructor(private postService : PostService) { }

  ngOnInit(): void {
    this.postService.getPosts()
    .subscribe( (data : Post[]) => {
      this.posts = data;
    }, error => {
      alert(`${error.status} - ${error.message}`);
    });
  }

  selectPost(post: Post){
    // this.selectedPost = post.postId;

    this.postService.getPost(post.postId)
    .subscribe((data : Post) => {
      debugger;
      this.selectedPost = data;
    }, error => console.log(error));
  }

}
