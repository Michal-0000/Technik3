import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Obrazki } from './obrazki/obrazki';
import { Notatnik } from './notatnik/notatnik';
import { OpenFile } from './open-file/open-file';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, Obrazki, Notatnik, OpenFile],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('galeria');
}
