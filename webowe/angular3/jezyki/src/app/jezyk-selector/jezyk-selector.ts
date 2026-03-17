import { Component, EventEmitter, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-jezyk-selector',
  imports: [CommonModule, FormsModule],
  templateUrl: './jezyk-selector.html',
  styleUrl: './jezyk-selector.css',
})
export class JezykSelector {
  jezyki = [
     { name: 'Java', checked: false },
    { name: 'Python', checked: true },
    { name: 'C++', checked: false },
    { name: 'Angular', checked: true }
  ];

  @Output() wybraneJezyki = new EventEmitter<string[]>();

  wyslijWybraneJezyki() {
    const wybrane = this.jezyki
      .filter(jezyk => jezyk.checked)
      .map(jezyk => jezyk.name);
    this.wybraneJezyki.emit(wybrane);
  }
}
