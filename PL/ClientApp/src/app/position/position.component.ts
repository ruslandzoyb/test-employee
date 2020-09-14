import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { MatDialog, MatDialogConfig } from "@angular/material";
import {HistoryService} from '../shared/services/history.service'
import { Position } from '../shared/models/position';
import {PositionService} from '../shared/services/position.service'
import { from } from 'rxjs';
@Component({
  selector: 'app-position',
  templateUrl: './position.component.html',
  styleUrls: ['./position.component.css']
})
export class PositionComponent implements OnInit {
  position :Position= new Position();
  pos : Position ;
  
  constructor(private service : PositionService, private router: Router ,private dialog: MatDialog) { }

  ngOnInit() {
    
  }

  onsend(){
   

     this.service.addposition(this.position).subscribe();
    
    }
    onclose(){
      this.dialog.closeAll();
    }
    

}
