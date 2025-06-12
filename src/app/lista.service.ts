import { Injectable } from '@angular/core';
import { Film } from '../models/film';
import { FilmBody } from '../models/film-body';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ListaService {
  private readonly baseUrl = 'http://localhost:5001/api/film';

  constructor(private http: HttpClient) {}

  get(): Observable<Film[]> {
    return this.http.get<Film[]>(this.baseUrl);
  }

  getByID(id: number): Observable<Film> {
    return this.http.get<Film>(`${this.baseUrl}/${id}`);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }

  put(id: number, body: FilmBody): Observable<void> {
    return this.http.put<void>(`${this.baseUrl}/${id}`, body);
  }

  post(body: FilmBody): Observable<void> {
    return this.http.post<void>(this.baseUrl, body);
  }
}