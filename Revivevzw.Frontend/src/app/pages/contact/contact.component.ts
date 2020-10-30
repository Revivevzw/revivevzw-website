import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';
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
    private toastr: ToastrService,
    private translate: TranslateService
  ) { }

  public isBusy: boolean = false;
  public form: FormGroup;

  ngOnInit(): void {
    this.form = this.fb.group({
      name: ['', Validators.required],
      emailFrom: ['', [Validators.required, Validators.email]],
      message: ['', Validators.required],
      subject: ["Email via revivevzw.be", Validators.required]
    })
  }

  public send = () => {
    const formValue = this.form.getRawValue();
    
    this.isBusy = true;
    this.mailApi.send(formValue).subscribe(result => {
      this.toastr.success(this.translate.instant("SHARED.SEND_EMAIL_SUCCESSFULL"));
      this.form.reset();
      this.isBusy = false;
    }, error => {
      this.toastr.error(this.translate.instant("SHARED.SEND_EMAIL_ERROR"))
      this.isBusy = false;
    });
  }
 
}
