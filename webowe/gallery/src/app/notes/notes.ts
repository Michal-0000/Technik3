import { CommonModule } from '@angular/common';
import { Component, signal } from '@angular/core';


interface TextFileContent {
  name: string;
  content: string;
  size: number;
}


@Component({
  selector: 'app-notes',
  imports: [CommonModule],
  templateUrl: './notes.html',
  styleUrl: './notes.css',
})
export class Notes {
textFiles = signal<TextFileContent[]>([]);

  onFileSelected(event: Event): void {
    const input = event.target as HTMLInputElement;

    if (input?.files && input.files.length > 0) {
      Array.from(input.files).forEach((file) => {
        // Obsługujemy tylko pliki tekstowe
        if (file.type === 'text/plain' || file.name.endsWith('.txt')) {
          const reader = new FileReader();

          reader.onload = (e) => {
            const content = e.target?.result as string;
            this.textFiles.update(prev => [...prev, {
              name: this.removeExtension(file.name),
              content: content,
              size: file.size
            }]);
          };

          reader.readAsText(file, 'UTF-8'); // Kluczowa różnica: odczyt jako tekst
        }
      });
    }
  }

  private removeExtension(fileName: string): string {
    const dotIndex = fileName.lastIndexOf('.');
    return dotIndex === -1 ? fileName : fileName.substring(0, dotIndex);
  }

  remove(index: number): void {
    this.textFiles.update(prev => prev.filter((_, i) => i !== index));
  }
}