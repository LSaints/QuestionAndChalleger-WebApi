import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { IndexComponent } from './pages/index/index.component'
import { EditQuestionComponent } from './pages/edit-question/edit-question.component';
import { InsertQuestionComponent } from './pages/insert-question/insert-question.component';

const routes: Routes = [
  { path: '', component: IndexComponent },
  { path: 'insert', component: InsertQuestionComponent },
  { path: 'edit/:id', component: EditQuestionComponent},
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes),
  ],
  exports: [
    [RouterModule]
  ]
})
export class AppRoutingModule { }
