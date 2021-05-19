import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Post } from '../shared/models/Post';

@Injectable({
  providedIn: 'root'
})
export class PostService {

  baseUrl: string = "http://localhost:64439";

  constructor(private httpClient : HttpClient) { }

  getPosts() : Observable<Post[]>{
    return this.httpClient.get<Post[]>(`${this.baseUrl}/posts`);
  }


  getPost(postId : number): Observable<Post>{
    return this.httpClient.get<Post>(`${this.baseUrl}/posts/${postId}`);
  }

}
