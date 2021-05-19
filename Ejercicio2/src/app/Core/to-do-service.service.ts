import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { Observable } from 'rxjs';
import { Post } from '../Shared/Post';

@Injectable({
  providedIn: 'root'
})

export class ToDoServiceService {

  baseUrl: string = "http://localhost:64439";

  constructor(private httpClient : HttpClient) { }

  getPosts() : Observable<Post[]>{
    return this.httpClient.get<Post[]>(`${this.baseUrl}/posts`);
  }


  getPost(postId : number): Observable<Post>{
    return this.httpClient.get<Post>(`${this.baseUrl}/posts/${postId}`);
  }

}

