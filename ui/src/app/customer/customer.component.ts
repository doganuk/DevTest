import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { CustomerService } from '../services/customer.service';
import { Observable, of } from 'rxjs';
import { CustomerModel } from '../models/customer.model';
@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.scss']
})
export class CustomerComponent implements OnInit {

  public customers: Observable<CustomerModel[]>;
  public types:any[]=[];

  public newCustomer: CustomerModel = {
    customerId: null,
    name: null,
    type: null
  };

  constructor(
    public customerService: CustomerService) {
    }

  ngOnInit() {
    this.customers =this.customerService.GetCustomers();
    this.types=["Large","Small"];
  }

  public createCustomer(form: NgForm): void {
    if (form.invalid) {
      alert('form is not valid');
    } else {
      this.customerService.CreateCustomer(this.newCustomer).then(() => {
       this.customerService.GetCustomers().subscribe(customers => this.customers = of(customers));
      });
    }
  }

}
