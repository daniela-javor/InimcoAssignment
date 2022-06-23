import { Component } from '@angular/core';
import { PersonsService } from './service/persons.service';
import { Person } from './models/person.model';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Persons';
  person: Person = {
    firstName : '',
    lastName : '',
    socialSkills : [],
    socialNetworks : []
  }

  constructor (private personsService: PersonsService){
  }

  onSubmit(){
    console.log(this.person);
    this.personsService.savePerson(this.person)
    .subscribe(
      response => {
        console.log(response);
        this.person = {
          firstName : '',
          lastName : '',
          socialSkills : [],
          socialNetworks : []
        }
      }
    )
  }
}
