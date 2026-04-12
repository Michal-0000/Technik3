import { CommonModule } from '@angular/common';
import { Component, signal } from '@angular/core';

@Component({
  selector: 'app-notatnik',
  imports: [CommonModule],
  templateUrl: './notatnik.html',
  styleUrl: './notatnik.css',
})
export class Notatnik {

files = signal<File[]>([]);
texts = signal<string[]>([]);

onFileChanged(event: Event): void{
  const input = event.target as HTMLInputElement;

  if(input?.files && input.files.length>0){
    Array.from(input.files).forEach((file)=>{
        if(file.type === 'text/plain'){
          const reader = new FileReader();
          reader.readAsText(file, 'UTF-8')

      reader.onload = (e: ProgressEvent<FileReader>) =>{
        const result = e.target?.result as string;
        if(result){
          this.files.update((fls) => [...fls, file]);
          this.texts.update((texts) => [...texts, result]);
        }
      }
        }
    });
  }
}

getName(fileName: string): string{
  const dotIndex  = fileName.lastIndexOf('.');
  return dotIndex === -1 ? fileName : fileName.substring(0, dotIndex);
}

remove(index: number): void{
  this.files.update( prev => prev.filter((_, i) => i != index));
  this.texts.update( prev => prev.filter((_, i) => i != index));
}


}
