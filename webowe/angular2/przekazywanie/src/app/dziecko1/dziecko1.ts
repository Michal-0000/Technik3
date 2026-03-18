import { Component, Input, OnInit, Output, EventEmitter, output } from '@angular/core';

@Component({
  selector: 'app-dziecko1',
  imports: [],
  templateUrl: './dziecko1.html',
  styleUrl: './dziecko1.css',
})
export class Dziecko1 implements OnInit{
  constructor(){}
  ngOnInit(): void {
    
  }

  @Input() doImportu!: string[];
  @Output() odpowiedz = new EventEmitter<string>();

  wyslij(){
    this.odpowiedz.emit("Dostalem imie i email....");
  }
}
