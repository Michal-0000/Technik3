import { CommonModule } from '@angular/common';
import { Component, OnInit} from '@angular/core';
import { FormsModule, FormGroup, FormBuilder } from '@angular/forms';

interface Note {
  id: number;
  title: string;
  content: string;
  image?: string;
  datautworzenia: string;
}

@Component({
  selector: 'app-root',
  imports: [CommonModule, FormsModule],
  templateUrl: './app.html',
  styleUrl: './app.css'
})


export class App implements OnInit {

}

ngOnInit(){
  this.loadNotes();
}

loadNotes(){
  this.http.get<Note[]>('http://localhost:3000/notes').subscribe((data) => {
    this.notes = data;
  });
}