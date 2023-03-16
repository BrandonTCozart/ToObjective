import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ServiceService {
  private url: string = '/Objective/getObjectives';
  constructor(private http: HttpClient) { }

  
  getObjectivesTitles(): Observable<string[]> {
    return this.http.get<[]>(this.url);
  }

  testFunction(): void{
    console.log("works")
  }
  
}
