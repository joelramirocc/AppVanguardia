import { Component, OnInit } from '@angular/core';
import { ToDoServiceService } from '../Core/to-do-service.service';
import { Post } from '../Shared/Post';

@Component({
  selector: 'app-todo-list',
  templateUrl: './todo-list.component.html',
  styleUrls: ['./todo-list.component.css']
})
export class TodoListComponent implements OnInit {

  posts !: Post[];
  selectedPost!: Post;

  constructor(private PostService:ToDoServiceService) { }

  ngOnInit(): void {
    this.PostService.getPosts()
    .subscribe( (data : Post[]) => {
      this.posts = data;
    }, error => {
      alert(`${error.status} - ${error.message}`);
    });
  }

  selectPost(post: Post){
    // this.selectedPost = post.postId;

    this.PostService.getPost(post.postId)
    .subscribe((data : Post) => {
      debugger;
      this.selectedPost = data;
    }, error => console.log(error));
  }

}
