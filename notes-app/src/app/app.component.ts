// src/app/app.component.ts
import { Component, OnInit } from '@angular/core';
import { Note } from './note.model';
import { NoteService } from './note.service';

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
    currentNote: Note = { id: 0, content: '' };

    constructor(private noteService: NoteService) { }

    ngOnInit(): void {
        // Load existing notes
        this.noteService.getNotes().subscribe(notes => {
            if (notes && notes.length > 0) {
                this.currentNote = notes[0];
            }
        });
    }

    onNoteChange(): void {
        // Autosave the note
        this.noteService.saveNote(this.currentNote).subscribe();
    }
}
