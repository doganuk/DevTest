import { CustomerModel } from './customer.model';

export interface JobModel {
  jobId: number;
  customerId : number;
  engineer: string;
  when: Date;
  customer:CustomerModel;
}
