import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { PersonService } from '../person.service';

interface SocialAccount {
  type: string;
  address: string;
}

interface Person {
  firstName: string;
  lastName: string;
  socialSkills: string[];
  socialAccounts: SocialAccount[];
}

@Component({
  selector: 'app-person',
  templateUrl: './person.component.html',
  styleUrls: ['./person.component.css']
})

export class PersonComponent implements OnInit{
  title = 'Person Details';
  person: Person = {
    firstName: '',
    lastName: '',
    socialSkills: [],
    socialAccounts: []
  };

  personForm!: FormGroup;

  constructor(private fb: FormBuilder, private ps: PersonService) {}

  ngOnInit(): void {
    this.personForm = this.fb.group({
      firstName: [''],
      lastName: [''],
      socialSkills: [''],
      socialAccounts: this.fb.array([
        this.fb.group({
          type: [''],
          address: ['']
        })
      ])
    });
  }

  addSocialAccount() {
    this.person.socialAccounts.push({ type: '', address: '' });
  }

  onSubmit(personForm: FormGroup<any>) {

    //here you addPerson and post request in another method and voila
    //this.ps.addPerson()

    
    const numVowels = (this.person.firstName + this.person.lastName).toLowerCase().match(/[aeiou]/g)?.length ?? 0;
    const numConsonants = (this.person.firstName + this.person.lastName).toLowerCase().match(/[bcdfghjklmnpqrstvwxyz]/g)?.length ?? 0;
    const reversedName = this.person.firstName.split('').reverse().join('') + ' ' + this.person.lastName.split('').reverse().join('');

    console.log('The number of VOWELS:', numVowels);
    console.log('The number of CONSONANTS:', numConsonants);
    console.log('The firstname + lastname entered:', this.person.firstName + ' ' + this.person.lastName);
    console.log('The reverse version of the firstname and lastname:', reversedName);
    console.log('The JSON format of the entire object:', JSON.stringify(this.person, null, 2));  }
}
