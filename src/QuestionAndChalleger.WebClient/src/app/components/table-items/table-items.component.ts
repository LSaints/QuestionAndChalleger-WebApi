import { Component, OnInit } from '@angular/core';
import { MatTableModule } from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button'
import { MatIconModule } from '@angular/material/icon'

import { question } from '../../../data/shared/question';
import { category } from '../../../data/shared/category';
import { level } from '../../../data/shared/level';
import { QuestionServices } from '../../../data/services/questionServices'



@Component({
  selector: 'table-items',
  templateUrl: './table-items.component.html',
  styleUrls: ['./table-items.component.css'],
  standalone: true,
  imports: [
    MatTableModule,
    MatButtonModule,
    MatIconModule,
  ],
})

export class TableItemsComponent implements OnInit {
  datasource: question[] = [];

  constructor(private questionServices: QuestionServices) {
    this.GetQuestions()
  }

  displayedColumns: string[] = ['id', 'description', 'category', 'level', 'actions']
  ngOnInit(): void { }

  GetQuestions(): void {
    this.questionServices.GetAll().subscribe((x) => (this.datasource = x));
  }

  DeleteQuestion(id: number) {
    if (window.confirm("You sure?")) {
      this.questionServices.DeleteQuestion(id);
    }
  }
}

