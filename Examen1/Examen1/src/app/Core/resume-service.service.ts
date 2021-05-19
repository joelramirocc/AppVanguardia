import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Resume } from '../Shared/Models/Resume';
import { Observable } from 'rxjs';
import { Accounts } from '../Shared/Models/Accounts';
import { Transactions } from '../Shared/Models/Transactions';

@Injectable({
  providedIn: 'root'
})
export class ResumeServiceService {

  baseUrl: string = "https://localhost:44343/api";

  constructor(private httpClient : HttpClient) { }

  getResume() : Observable<Resume>{
    return this.httpClient.get<Resume>(`${this.baseUrl}/transactions/GetResumeOfActualMonth`);
  }

  getAccounts() : Observable<Accounts[]>{
    return this.httpClient.get<Accounts[]>(`${this.baseUrl}/accounts`);
  }

  getLastFiveTransactionsOfCurrentMonth() : Observable<Transactions[]>{
    return this.httpClient.get<Transactions[]>(`${this.baseUrl}/transactions/GetLastFiveTransactionsOfCurrentMonth`);
  }
}
