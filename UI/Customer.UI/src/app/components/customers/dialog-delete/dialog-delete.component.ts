import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { CustomersService } from 'src/app/services/customers.service';

@Component({
  selector: 'app-dialog-delete',
  templateUrl: './dialog-delete.component.html',
  styleUrls: ['./dialog-delete.component.css']
})
export class DialogDeleteComponent implements OnInit {

  constructor(private router: Router, private customerService: CustomersService, public dialogRef: MatDialogRef<DialogDeleteComponent>) { }

  ngOnInit(): void {
  }

  onDeleteButtonClick(){
    this.dialogRef.close();
    var id = sessionStorage.getItem('deleteCustomerId');
    console.log('id for delete');
    console.log(id);
    if(id){
      this.customerService.deleteCustomer(id).subscribe({
        next: () =>{          
          this.router.navigate(['/customers']);
        }
      })
    }   
    
  }

}
