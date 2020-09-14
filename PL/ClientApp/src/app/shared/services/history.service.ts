import { Injectable } from '@angular/core';
import { HttpClient ,HttpHeaders} from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Position } from '../models/position';
import { Observable } from 'rxjs';
import { $ } from 'protractor';
import { History } from '../models/history';
import { env } from 'process';
import { HistoryView } from '../models/history_view';

@Injectable({
  providedIn: 'root'
})
export class HistoryService {
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json; charset=utf-8'
    })
  };

  constructor(private http:HttpClient) {


   }
getemployees(){
  return this.http.get(environment.apiURL+'/History');
}

 addhistory(history :HistoryView){
 return  this.http.post(environment.apiURL+'/History/',history,this.httpOptions).toPromise();

}

 
}
