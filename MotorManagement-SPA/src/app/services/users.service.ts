import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { User } from '../models/user';

@Injectable({
  providedIn: 'root'
})
export class UsersService {
  baseUrl = environment.apiUrl;

constructor(private http: HttpClient) { }

getUsers() {
  return this.http.get<User[]>(`${this.baseUrl}/users`);
}

}
