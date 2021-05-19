import { Component, OnInit } from '@angular/core';
import { ResumeServiceService } from '../Core/resume-service.service';
import { Transactions } from '../Shared/Models/Transactions';

@Component({
  selector: 'app-transaction-list',
  templateUrl: './transaction-list.component.html',
  styleUrls: ['./transaction-list.component.css']
})
export class TransactionListComponent implements OnInit {
  transactions!:Transactions[];

  constructor(private resumeService:ResumeServiceService) { }
  
  ngOnInit(): void {
    this.resumeService.getLastFiveTransactionsOfCurrentMonth()
    .subscribe( (data : Transactions[]) => {
      this.transactions = data;
    }, error => {
      alert(`${error.status} - ${error.message}`);
    });
  }

}
