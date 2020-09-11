import {Employee} from "./employee"
import {Position} from "./position"
import { from } from "rxjs";
export class History {
    Id :number;
    EmployeeId :number;
    Employee :Employee;
    PositionId : number;
    Position :Position;

    Hired :Date;
    Fired :Date;
    Salary :number;




}