import { Component, EventEmitter, Input,OnInit, Output} from '@angular/core';

@Component({
  selector: 'app-okno1',
  imports: [],
  templateUrl: './okno1.html',
  styleUrl: './okno1.css',
})
export class Okno1 {
  
  @Output() odpowiedz = new EventEmitter<string>();
  constructor(){}
  ngOnInit():void{

  }
  wyslij(){
    const select = document.getElementById("cars");
    const value = select.value; // Selected option's value
    const text = select.options[select.selectedIndex].text; // Selected option's text
    alert(`Value: ${value}\nText: ${text}`);
    this.odpowiedz.emit()
  }
}
