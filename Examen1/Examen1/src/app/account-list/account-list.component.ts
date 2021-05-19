import { Component, OnInit } from '@angular/core';
import { Accounts } from '../Shared/Models/Accounts';
import { ResumeServiceService } from '../Core/resume-service.service';

@Component({
  selector: 'app-account-list',
  templateUrl: './account-list.component.html',
  styleUrls: ['./account-list.component.css']
})
export class AccountListComponent implements OnInit {

  accounts!:Accounts[];
  constructor(private resumeService:ResumeServiceService) { }

  ngOnInit(): void {
    this.resumeService.getAccounts()
    .subscribe( (data : Accounts[]) => {
      this.accounts = data;
    }, error => {
      alert(`${error.status} - ${error.message}`);
    });
  }

}
