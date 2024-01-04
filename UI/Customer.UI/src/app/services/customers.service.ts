import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Customer } from '../models/customer.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CustomersService {

  baseApiUrl: string =  environment.baseApiUrl;
  constructor(private http: HttpClient) { }

  getAllCustomers(): Observable<Customer[]>{
    return this.http.get<Customer[]>(this.baseApiUrl + '/api/Customer')
  }

  addCustomer(addCustomerRequest: Customer): Observable<Customer>{
    return this.http.post<Customer>(this.baseApiUrl + '/api/Customer', addCustomerRequest);
  }
  
  getCustomer(id: string): Observable<Customer>{
    return this.http.get<Customer>(this.baseApiUrl +'/api/Customer/' + id);
  }

  editCustomer(id: string, editCustomerRequest: Customer): Observable<Customer>{
    return this.http.put<Customer>(this.baseApiUrl + '/api/Customer/' + id, editCustomerRequest);
  }

  deleteCustomer(id: string){
    return this.http.delete(this.baseApiUrl + '/api/Customer/' + id);
  }
}
