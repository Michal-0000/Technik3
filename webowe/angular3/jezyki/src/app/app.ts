import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { JezykSelector } from './jezyk-selector/jezyk-selector';
import { JezykLista } from './jezyk-lista/jezyk-lista';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, JezykSelector, JezykLista],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  wybrane: string[] = [];
}
