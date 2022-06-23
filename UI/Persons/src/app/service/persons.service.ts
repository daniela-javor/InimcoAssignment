import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Person } from '../models/person.model';

@Injectable({
  providedIn: 'root'
})
export class PersonsService {

  baseUrl = 'https://localhost:7110/api/Person';
  constructor(private http: HttpClient) { }

  // Save person
  savePerson(person: Person) : Observable<Person> {
    return this.http.post<Person>(this.baseUrl, person);
  }
  
}
