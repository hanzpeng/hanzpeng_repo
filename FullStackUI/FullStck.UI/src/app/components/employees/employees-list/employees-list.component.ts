import { Component, OnInit } from '@angular/core';
import { Employee } from 'src/app/models/employee.model';
import { EmployeesService } from 'src/app/services/employees.service';

@Component({
  selector: 'app-employees-list',
  templateUrl: './employees-list.component.html',
  styleUrls: ['./employees-list.component.css']
})
export class EmployeesListComponent implements OnInit {
  employees: Employee[] = [];
  constructor(private employeesService: EmployeesService){

  }
  ngOnInit(): void{

    let p1 = new Promise( (resolve, reject) => {
      let x = 1+2;
      if(x == 3){resolve("soap");
      }else{reject("soap reject");}
    });

    let p2 = new Promise( (resolve, reject) => {
      let x = 1+2;
      if(x == 3){resolve("soap");
      }else{reject("soap reject");}
    });

    p1.then((data)=>{console.log("got success message " + data);})
    .catch((data)=>{console.log("got error message " + data);});

    Promise.all([p1,p2]).then(([data1,data2]) => console.log("got success message " + data1 + " " + data2))
    .catch(([data1,data2]) => console.log("got failed message " + data1 + " " + data2));

    Promise.any([p1,p2]).then((data)=>{console.log("got success message " + data);})
    .catch((data)=>{console.log("got error message " + data);});

    this.employeesService.getAllEmployees()
    .subscribe({
      next: (employees) => {
        console.log(employees);
        this.employees = employees;
      },
      error: (response) => {
        console.log(response);
      }
    });
  }
}
