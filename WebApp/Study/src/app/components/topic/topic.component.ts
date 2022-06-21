import { Component, OnInit } from '@angular/core';
import { topicDto } from 'src/app/model/topicDto';
import { TopicService } from '../../services/topic.service';

@Component({
  selector: 'app-topic',
  templateUrl: './topic.component.html',
  styleUrls: ['./topic.component.css']
})
export class TopicComponent implements OnInit {

  topics: topicDto[] = [];
  constructor(private svc: TopicService) { }


  ngOnInit(): void {
    this.svc.getAllTopics().subscribe(
      data => {
        this.topics = data
      }
    );
  };
}
