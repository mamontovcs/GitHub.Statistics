import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  constructor(private _httpClient: HttpClient) { }

  public authtenticate() {
    return this._httpClient.get('http://github-statistics-authentication:5502/authtentication/getOAuthLink');
  }
}
