import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Person } from '../models/person.model';
import { PersonResponse } from '../models/personResponse.model';

@Injectable({
  providedIn: 'root'
})
export class PersonsService {

  baseUrl = 'https://localhost:7110/api/Person';
  constructor(private http: HttpClient) { }

  // Save person
  savePerson(person: Person) : Observable<PersonResponse> {
    return this.http.post<PersonResponse>(this.baseUrl, person);
  }
}
