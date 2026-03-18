import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { NgForOf } from "../../node_modules/@angular/common/types/_common_module-chunk";
import { Muzyka } from "./muzyka/muzyka";

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, NgForOf, Muzyka],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  gry :string[] = ["Wiedzmin", "Cuberpukn", "Tetris"];
  tempWybor: string = "";
  potwierdzonyWybor:string = "";
  wyslij(){

  }
}
