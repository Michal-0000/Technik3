import { Component, signal } from '@angular/core';
import { Okno1 } from './okno1/okno1';
import { Okno2 } from './okno2/okno2';

@Component({
  selector: 'app-root',
  imports: [Okno1, Okno2],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  
  doEksportu: string = "Gra";


  onOdpowiedz(otrzymana: string){
    this.doEksportu = otrzymana;
    alert()
  }
}
