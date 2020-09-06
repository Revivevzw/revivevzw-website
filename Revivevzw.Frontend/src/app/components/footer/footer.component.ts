import { Component, OnInit } from '@angular/core';
import { MailchimpApiService } from 'src/app/services';


@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.scss']
})
export class FooterComponent implements OnInit {

  constructor(private mailchimpApi: MailchimpApiService) { }

  ngOnInit(): void {
  }

  public subscribe = (email: string) => {
    // this.mailchimpApi.subscribe(email).subscribe(x => {
    //   console.log(x);
    // })
  }
}
