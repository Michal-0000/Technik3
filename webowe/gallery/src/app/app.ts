import { Component, signal } from '@angular/core';
import { Galeria } from './galeria/galeria';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Notes } from './notes/notes';


@Component({
  selector: 'app-root',
  imports: [ Galeria, CommonModule, FormsModule, Notes],
  templateUrl: './app.html',
  styleUrl: './app.css',
  standalone: true
})
export class App {

}
