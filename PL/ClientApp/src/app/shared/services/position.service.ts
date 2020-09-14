import { Injectable } from '@angular/core';
import { HttpClient ,HttpHeaders} from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Position } from '../models/position';
import { Observable } from 'rxjs';
import { $ } from 'protractor';
@Injectable({
  providedIn: 'root'
})
export class PositionService {

  private url :string ='/Position';
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };
  constructor(private http :HttpClient ) { }

  getpositions(){
    return this.http.get(environment.apiURL+this.url);
  }
addposition(position :Position){
  var js = JSON.stringify(position);
   return this.http.post(environment.apiURL+'/Position',js ,this.httpOptions )
   
}

}
