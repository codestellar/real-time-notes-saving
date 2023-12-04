// src/app/note.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Note } from './note.model';

@Injectable({
    providedIn: 'root'
})
export class NoteService {
    private apiUrl = 'http://localhost:5144/api/notes';

    constructor(private http: HttpClient) { }

    getNotes(): Observable<Note[]> {
        return this.http.get<Note[]>(this.apiUrl);
    }

    saveNote(note: Note): Observable<Note> {
        return this.http.post<Note>(this.apiUrl, note);
    }
}
