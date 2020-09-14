import { Injectable } from '@angular/core';
import { HttpClient ,HttpHeaders} from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Position } from '../models/position';
import { Observable } from 'rxjs';
import { $ } from 'protractor';
import { Employee } from '../models/employee';
import { map, catchError } from 'rxjs/operators';
@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
  private url :string ='/Employee';
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' }),

    
  };
  
   
  
  constructor(private http:HttpClient) { 

    
  }
    postempl(empl:Employee) {
    
      return   this.http.post<Employee>(environment.apiURL+'/Employee',empl,this.httpOptions);
      
      
  
   
  }


}
