import { Component } from '@angular/core';
import { QuestionServices } from '../../../data/services/questionServices'

@Component({
  selector: 'app-insert-question',
  templateUrl: './insert-question.component.html',
  styleUrls: ['./insert-question.component.css'],
})
export class InsertQuestionComponent {
  questions: any;
  constructor(private questionServices: QuestionServices) { }

  getQuestionFormData(data: any) {
    if ((this.questionServices.PostQuestion(data)).subscribe((result) => {
      console.warn(result)
    })) {
      window.confirm("inserted successfully");
      window.open("/")
    }
  }
}
