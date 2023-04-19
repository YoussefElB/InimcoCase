import { HttpParams } from "@angular/common/http";

export class Person {

    constructor (public firstname: string,
                 public lastname: string, 
                 public Socialskills: string, 
                 public Socialaccounts: string,) {}
    getParams() : HttpParams {
       return new HttpParams()
          .set('firstname', this.firstname)
          .set('lastname', this.lastname)
          .set('socialskills', this.Socialskills)
          .set('socialaccounts', this.Socialaccounts);
    }
 }