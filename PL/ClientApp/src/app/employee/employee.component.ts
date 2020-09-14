import { Component, OnInit } from '@angular/core';
import { NgModel } from '@angular/forms';
import { from } from 'rxjs';
import { Position } from '../shared/models/position';
import {HistoryService} from '../shared/services/history.service'
import { Router } from '@angular/router';
import { MatDialog, MatDialogConfig } from "@angular/material";
import { PositionService } from '../shared/services/position.service';
import {NgbDateStruct, NgbCalendar} from '@ng-bootstrap/ng-bootstrap';
import {MaterialModule} from "../material.module"
import { Employee } from '../shared/models/employee';
import { EmployeeService } from '../shared/services/employee.service';
import { History } from '../shared/models/history';
import { HistoryView} from '../shared/models/history_view';
import { getLocaleTimeFormat } from '@angular/common';
import { map } from 'rxjs/operators';


@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css']
})
export class EmployeeComponent implements OnInit {
  employee :Employee;
  date :Date;

  history : HistoryView ;
  positions :Position[];
 positionId :number;
  pick :Date;
  isDownload :boolean = false;
  emp_id :number;
  constructor(private emp_service : EmployeeService,private service: PositionService,
    private his_service :HistoryService,
    private router: Router ,private dialog: MatDialog ) { }

  ngOnInit() {
   
    
    this.isDownload=true;
    this.Initialize();
    this.getpositions();

  }

  
  
   async onsend(){

   
    await this.addemployee();
    // 
    await this.addhistory();
    
   }
    
   
    getpositions(){
     this.service.getpositions().subscribe(x=>{this.positions=x as Position[]})
   }
    

    async addemployee(){
      
      
     return  await this.emp_service.postempl(this.employee)
     .subscribe(x=>{this.history.EmployeeId= x['id']
      }
      
    );
      
   
    }

    OnPos(item: Position){
      this.positionId=item.Id;
    }
  
    async addhistory(){
      await this.delay(1200);
      this.history.PositionId=this.positionId;
   return await this.his_service.addhistory(this.history)
    }

    

    
    onclose(){
     this.dialog.closeAll();
    }


    Initialize(){
      this.employee = new Employee();
      this.history =new HistoryView() ;
     this.pick = new Date();
     
      
      
    }

    private delay(ms: number) {
      return new Promise( resolve => setTimeout(resolve, ms) );
  }
}
