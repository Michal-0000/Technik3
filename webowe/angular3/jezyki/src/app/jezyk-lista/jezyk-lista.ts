import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-jezyk-lista',
  imports: [],
  templateUrl: './jezyk-lista.html',
  styleUrl: './jezyk-lista.css',
})
export class JezykLista {
  @Input() jezyki: string[] = [];
}
