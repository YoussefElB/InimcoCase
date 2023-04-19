import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Person } from './person';

import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class PersonService {

  private contentHeaders: HttpHeaders

  constructor(private http: HttpClient) {
    this.contentHeaders = new HttpHeaders().set('Content-Type', 'application/x-www-form-urlencoded')
 }
  private baseUrl: string = "https://localhost:7155"

  addPerson(person: Person): void {
    let url = `${this.baseUrl}/api/people`
    // !!! subscribe is needed to execute POST
    this.http.post(url, person.getParams(),
                  { headers: this.contentHeaders})
                  .subscribe(data => { console.log(data) }, 
                             error => { console.error(error) })}
  }
