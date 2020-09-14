import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import {MatDialogModule} from '@angular/material/dialog';
import {MaterialModule} from "../app/material.module"
import {NgbModule} from '@ng-bootstrap/ng-bootstrap'
import { AppComponent } from './app.component';
import {MatDatepickerModule} from '@angular/material/datepicker';

import { HomeComponent } from './home/home.component';
import { HistoryComponent } from './history/history.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { EmployeeComponent } from './employee/employee.component';
import { PositionComponent } from './position/position.component';
import { from } from 'rxjs';
import {MatInputModule} from '@angular/material/input';
import {MatNativeDateModule} from '@angular/material/core';





@NgModule({
  declarations: [
    AppComponent,

    HomeComponent,

    HistoryComponent,

    EmployeeComponent,

    PositionComponent,
    
  
    
    
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    MatDialogModule,
    MaterialModule,
    NgbModule,
    MatDatepickerModule,
    MatNativeDateModule,
    
    
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' }
     
    ]),
    BrowserAnimationsModule
  ],
  providers: [ ],
  bootstrap: [AppComponent],
  entryComponents :[EmployeeComponent,PositionComponent]

})
export class AppModule { }
