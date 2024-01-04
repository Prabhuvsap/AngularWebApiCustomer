import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Customer } from 'src/app/models/customer.model';
import { CustomersService } from 'src/app/services/customers.service';
import { MatDialog } from '@angular/material/dialog';
import { DialogComponent } from '../dialog/dialog.component';
import { DialogDeleteComponent } from '../dialog-delete/dialog-delete.component';

@Component({
  selector: 'app-edit-customer',
  templateUrl: './edit-customer.component.html',
  styleUrls: ['./edit-customer.component.css']
})
export class EditCustomerComponent implements OnInit {

  editCustomerDetails: Customer = {
    id: '',
    firstName: '',
    lastName: '',
    email: '',
    createdDateTime: new Date(Date.now()),
    updatedDateTime: new Date(Date.now())
  }
  customerID: any;
  constructor(private route: ActivatedRoute, private customerService: CustomersService,private router: Router, public dialog: MatDialog) { }

  openDialog(): void {
    const dialogRef = this.dialog.open(DialogComponent, { 
    });
  }

  openDeleteDialog(cusId: string): void {
    const dialogRef = this.dialog.open(DialogDeleteComponent, {      
    });
  }

  ngOnInit(): void {
    this.route.paramMap.subscribe({
      next: (params)=> {
        this.customerID = params.get('id');
        console.log(this.customerID);
        if(this.customerID){
          sessionStorage.setItem('selectedCustomerId',this.customerID );
          this.editCustomerDetails.id = this.customerID;
          this.getCustomerData();
        }
      }
    })
  } 

  getCustomerData(){
    console.log('getCustomerData is');
    this.customerService.getCustomer(this.editCustomerDetails.id).subscribe({
      next: (customer) =>{
        console.log('success');
        this.editCustomerDetails = customer;
      }
    })
  }

  editCustomer(){
    console.log(this.editCustomerDetails);
    this.customerService.editCustomer(this.editCustomerDetails.id, this.editCustomerDetails).subscribe({
      next: (response) =>{
       sessionStorage.setItem('selectedCustomerId',this.editCustomerDetails.id );
        this.openDialog();
        //this.router.navigate(['/customers']);
      }
    })
  }

  onBackButtonClick(){
    //sessionStorage.clear();
    this.router.navigate(['/customers']);
  }

  onDeleteButtonClick(){
    sessionStorage.setItem('deleteCustomerId',this.editCustomerDetails.id );
    this.openDeleteDialog(this.editCustomerDetails.id);
    
  }

}
