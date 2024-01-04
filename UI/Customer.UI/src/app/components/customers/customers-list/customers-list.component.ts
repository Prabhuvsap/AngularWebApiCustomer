import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Customer } from 'src/app/models/customer.model';
import { CustomersService } from 'src/app/services/customers.service';

import {AfterViewInit, ViewChild} from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import {MatSort} from '@angular/material/sort';

@Component({
  selector: 'app-customers-list',
  templateUrl: './customers-list.component.html',
  styleUrls: ['./customers-list.component.css'],
})
export class CustomersListComponent implements OnInit {
  displayedColumns: string[] = ['id', 'firstName', 'lastName', 'email' , 'createdDateTime' , 'updatedDateTime' ,'edit'];

  dataSource : any = new MatTableDataSource<any>([]);
  lastSelectedCutomerId : any = '';
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;


  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }

  customers: Customer[] = [];
  constructor(private customerService: CustomersService, private router: Router) { }

  ngOnInit(): void {
    this.lastSelectedCutomerId = sessionStorage.getItem('selectedCustomerId');
    this.customerService.getAllCustomers()
    .subscribe({
        next: (customers) => {
         // console.log(customers);          
         this.customers = customers;
         this.dataSource = new MatTableDataSource<any>(this.customers);
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
        },
        error: (response) => {
          console.log(response);  
        }
      })

  }
  oneditButtonClick(customer: any){
    console.log("on edit click"); 
    console.log(customer);
    sessionStorage.setItem("selectedCustomerId", customer.id);
    this.router.navigate(['/edit']);
  }
}
