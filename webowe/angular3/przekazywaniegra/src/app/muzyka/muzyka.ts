import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-muzyka',
  imports: [],
  templateUrl: './muzyka.html',
  styleUrl: './muzyka.css',
})
export class Muzyka {
   @Input() wybranaMuzyka: string ="";
}
