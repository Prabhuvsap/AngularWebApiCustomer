import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { Customer } from 'src/app/models/customer.model';
import { CustomersService } from 'src/app/services/customers.service';
import { DialogComponent } from '../dialog/dialog.component';

@Component({
  selector: 'app-add-customer',
  templateUrl: './add-customer.component.html',
  styleUrls: ['./add-customer.component.css']
})

export class AddCustomerComponent implements OnInit { 

  addCustomerRequest: Customer = {
    id: '00000000-0000-0000-0000-000000000000',
    firstName: '',
    lastName: '',
    email: '',
    createdDateTime: new Date(Date.now()),
    updatedDateTime: new Date(Date.now())
  }
  constructor(private customerService: CustomersService,private router: Router, public dialog: MatDialog) { }

  openDialog(): void {
    const dialogRef = this.dialog.open(DialogComponent, { 
    });

    dialogRef.afterClosed();
  }

  ngOnInit(): void {    
  }

  addCustomer(){
    this.customerService.addCustomer(this.addCustomerRequest).subscribe({
      next: (customer) =>{
        this.openDialog();
      }
    })
  }

  onBackButtonClick(){
    this.router.navigate(['/customers']);
  }

}
