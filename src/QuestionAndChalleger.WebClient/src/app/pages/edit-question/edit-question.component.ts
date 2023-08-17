import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router'
import { QuestionServices } from '../../../data/services/questionServices';

import { NavbarComponent } from '../../components/navbar/navbar.component';
import { question } from '../../../data/shared/question';

@Component({
  providers: [NavbarComponent],
  selector: 'app-edit-question',
  templateUrl: './edit-question.component.html',
  styleUrls: ['./edit-question.component.css']
})
export class EditQuestionComponent implements OnInit {
  questionData: undefined | question
  constructor(private activeRoute: ActivatedRoute, private questionServices: QuestionServices) { }

  ngOnInit(): void {
    let questionId = this.activeRoute.snapshot.paramMap.get('id');
    console.warn(questionId);
    questionId && this.questionServices.GetById(Number(questionId)).subscribe((result) => {
      console.warn(result);
      this.questionData = result;
    })
  }
}
