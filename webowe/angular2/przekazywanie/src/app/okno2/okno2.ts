import { Component,Input } from '@angular/core';

@Component({
  selector: 'app-okno2',
  imports: [],
  templateUrl: './okno2.html',
  styleUrl: './okno2.css',
})
export class Okno2 {
  @Input() doImportu!: string;

  constructor(){}
  ngOnInit():void{}
  

}
