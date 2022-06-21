import { Injectable } from '@angular/core';
import { topicDto } from '../model/topicDto';
import { HttpClient} from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TopicService {
  path = environment.apiUri;
  constructor(private http: HttpClient) { }

  public getAllTopics():Observable<topicDto[]>{
    return this.http.get<topicDto[]>(this.path + 'AllTopics');
  }

}
