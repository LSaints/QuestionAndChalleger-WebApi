import { Injectable } from '@angular/core';
import { question } from '../shared/question';
import { HttpClient, HttpHeaders } from '@angular/common/http'
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})

export class QuestionServices {
  private apiUrl = 'https://localhost:7150/api/Question';

  constructor(private http: HttpClient) { }

  GetAll(): Observable<question[]> {
    return this.http.get<question[]>(this.apiUrl);
  }

  GetById(id: number): Observable<question> {
    return this.http.get<question>(this.apiUrl + "/" + id);
  }

   PostQuestion(data: any) {
     return this.http.post(this.apiUrl, data);
  }

  DeleteQuestion(id: number) {
    return this.http.delete(this.apiUrl + "/" + id).subscribe();
  }
}
