import { CommonModule, DecimalPipe } from '@angular/common';
import { Component, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';


@Component({
  selector: 'app-galeria',
  imports: [CommonModule, FormsModule, DecimalPipe],
  templateUrl: './galeria.html',
  styleUrl: './galeria.css',
  standalone: true
})
export class Galeria {

  images = signal<string[]>([]);
  files = signal<File[]> ([]);
  
  onFileSelected(event: Event): void{
    const input = event.target as HTMLInputElement;

    if(input?.files && input.files.length > 0){
      Array.from(input.files).forEach( (file) =>{
          this.files.update( (fls) => [...fls, file]);
          this.images.update( (imgs) => [...imgs, URL.createObjectURL(file)]);

        const reader = new FileReader();
        reader.onload = (e: ProgressEvent<FileReader>)=> {
          const result = e.target?.result as string;
          if(result){
            this.images.update( (imgs) => [...imgs, result]);
            this.files.update( (fls) => [...fls, file]);
          }
        };
     // reader.readAsDataURL(file);
      });
    }
  }

  getName(fileName: string) : string{
    const dotIndex = fileName.lastIndexOf('.');    
    return dotIndex === -1 ? fileName : fileName.substring(0, dotIndex);
  } 

  remove(index: number) : void{
      this.images.update( prev => prev.filter((_, i) => i !== index));
      this.files.update( prev => prev.filter((_, i) => i !== index));

  }
} 
