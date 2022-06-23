import { Component } from '@angular/core';
import { PersonsService } from './service/persons.service';
import { Person } from './models/person.model';
import { SocialAccount } from './models/socialAccount.model';
import { PersonResponse } from './models/personResponse.model';
import { Router } from '@angular/router';

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
    socialAccounts : []
  }

  personResponseJson: string = '';
  showResponseData: boolean = false;
  showPersonForm: boolean = true;
  newSocialSkill: string = '';

  newSocialAccount: SocialAccount = {
    type: '',
    address: ''
  }

  personResponse: PersonResponse = {
    numberOfVowels : 0,
    numberOfConsonants : 0,
    reversedName : '',
    person: this.person
  }
  constructor (private personsService: PersonsService, private router: Router){
  }

  onSubmit(){
    this.personsService.savePerson(this.person)
    .subscribe(
      response => {
        this.personResponse = response;
        this.showPersonForm = false;
        this.showResponseData = true;
        this.personResponseJson = JSON.stringify(response.person, undefined, 4);
        this.person = {
          firstName : '',
          lastName : '',
          socialSkills : [],
          socialAccounts : []
        }
      }
    )
  }
  addSocialSkill(){
    this.person.socialSkills.push(this.newSocialSkill);
    this.newSocialSkill = '';
  }

  addSocialAccount(){
    this.person.socialAccounts.push(this.newSocialAccount);
    this.newSocialAccount = {
      type: '',
      address: ''
    }
  }
}
