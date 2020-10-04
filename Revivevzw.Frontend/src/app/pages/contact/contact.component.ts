import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { MailApiService } from 'src/app/services';

@Component({
  selector: 'app-contact',
  templateUrl: './contact.component.html',
  styleUrls: ['./contact.component.scss']
})
export class ContactComponent implements OnInit {

  constructor(
    private fb: FormBuilder,
    private mailApi: MailApiService,
    private toastr: ToastrService
  ) { }

  public isBusy: boolean = false;
  public form: FormGroup;

  ngOnInit(): void {
    this.form = this.fb.group({
      name: ['', Validators.required],
      emailFrom: ['', [Validators.required, Validators.email]],
      message: ['', Validators.required],
      subject: ["Email via website form", Validators.required]
    })
  }

  public send = () => {
    const formValue = this.form.getRawValue();
    
    this.isBusy = true;
    this.mailApi.send(formValue).subscribe(result => {
      this.toastr.success("Mail succesvol verzonden!");
      this.form.reset();
    }, error => {
      this.toastr.error("Verzenden van mail mislukt.")
    }, () => {
      this.isBusy = false;
    });
  }
 
}
