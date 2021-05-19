import { Component, Input, OnInit } from '@angular/core';
import { Post } from '../shared/models/Post';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.css']
})
export class PostComponent implements OnInit {

  @Input() postId: number;
  post: Post;
  constructor() { }

  ngOnInit(): void {
  }

}
