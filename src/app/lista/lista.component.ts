import { Component, inject } from '@angular/core';
import { ListaService } from '../lista.service';
import { Observable } from 'rxjs';
import { Film } from '../../models/film';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-lista',
  imports: [CommonModule, RouterLink],
  templateUrl: './lista.component.html',
  styleUrl: './lista.component.css'
})
export class ListaComponent {
  private readonly listaService = inject(ListaService);
  public dane$: Observable<Film[]>;

  constructor() {
    this.dane$ = this.listaService.get();
  
    // Debuguj czy coś przychodzi
    this.dane$.subscribe(data => {
      console.log('DANE Z API:', data);
    });
  }
 
}
