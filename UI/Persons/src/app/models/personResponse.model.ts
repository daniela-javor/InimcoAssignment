import { Person } from './person.model';

export interface PersonResponse {
    numberOfVowels : number;
    numberOfConsonants : number;
    reversedName : string;
    person : Person;
}