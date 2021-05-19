import { Component, OnInit } from '@angular/core';
import { ResumeServiceService } from '../Core/resume-service.service';
import { Resume } from '../Shared/Models/Resume';

@Component({
  selector: 'app-resume',
  templateUrl: './resume.component.html',
  styleUrls: ['./resume.component.css']
})
export class ResumeComponent implements OnInit {

  resume!:Resume;
  
  constructor( private resumeService:ResumeServiceService) 
  {
    this.resume = {income : 5,expenses:6,total:-1};
  }

  ngOnInit(): void {
    this.resumeService.getResume()
    .subscribe( (data : Resume) => {
      this.resume = data;
    }, error => {
      alert(`${error.status} - ${error.message}`);
    });
  }

}
