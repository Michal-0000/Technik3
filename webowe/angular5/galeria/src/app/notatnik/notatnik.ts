import { CommonModule } from '@angular/common';
import { Component, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-notatnik',
  imports: [FormsModule, CommonModule],
  templateUrl: './notatnik.html',
  styleUrl: './notatnik.css',
})
export class Notatnik {

images = signal<string[]>([]);
contents = signal<string[]>([]);
files = signal<File[]>([]);

onFileChanged(event: Event) :void{
 const input = event.target as HTMLInputElement;

 if(input?.files && input.files.length > 0){
  Array.from(input.files).forEach((file) => {
    this.files.update((fls)=>[...fls,file]);
    //this.contents.update((cnts) => [...cnts,])
    this.images.update((imgs)=>[...imgs, URL.createObjectURL(file)]);

    const reader = new FileReader;

    reader.onload = (e: ProgressEvent<FileReader>) => {
      const result = e.target?.result as string;
      if(result){
        this.images.update((imgs)=>[...imgs, result]);
        this.files.update((fls)=>[...fls, file]);
      }
    }
  });
 }

}

getName(fileName: string): string{
  const dotIndex = fileName.lastIndexOf('.');
  return dotIndex === -1 ? fileName : fileName.substring(0, dotIndex);
}

remove(index: number): void{
  this.images.update( prev => prev.filter((_, i) => i != index));
    this.files.update( prev => prev.filter((_, i) => i != index));
}
}
