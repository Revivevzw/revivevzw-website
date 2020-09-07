import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';

@Injectable({
   providedIn: 'root'
})
export class MailchimpApiService {
   constructor(private http: HttpClient) { }

   private apiKey = "3f973ec77e3323ca3e01a12cf3a2cbcd-us7";
   private serverPrefix = "us7";
   private url = "";


   public subscribe(email: string) {
      // const listId = 0;
      // const mailchimp = require("@mailchimp/mailchimp_marketing");

      // mailchimp.setConfig({
      //    apiKey: this.apiKey,
      //    server: this.serverPrefix
      // });

      // return mailchimp.lists.addListMember(listId, {
      //    email_address: email,
      //    status: "subscribed",
      // })

      const body = { members: [{ email_address: email, language: 'nl' }], update_existing: false };

      this.http.post(this.url, body, { headers: { 'authorization': "Basic <USERNAME:PASSWORD>" } }).subscribe(x => {
         console.log(x);
      }, error => {
         console.log(error);
      })
   }
}