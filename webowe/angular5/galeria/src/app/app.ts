import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Obrazki } from './obrazki/obrazki'
import { Notatnik } from './notatnik/notatnik';


@Component({
  selector: 'app-root',
  imports: [RouterOutlet, Obrazki, Notatnik],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('galeria');
}
