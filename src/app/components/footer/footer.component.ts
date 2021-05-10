import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { finalize } from 'rxjs/operators';
import { MailchimpApiService, PersonApiService } from 'src/app/services';


@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.scss']
})
export class FooterComponent implements OnInit {

  public isBusy: boolean;
  public email: string;

  // public form: FormGroup;

  constructor(
    private personApi: PersonApiService,
    private toastr: ToastrService,
    private fb: FormBuilder,
  ) { }

  ngOnInit(): void {
    // this.initForm();
  }

  // private initForm = () => {
  //   this.form = this.fb.group({
  //     email: ['', Validators.required]
  //   })
  // }

  public subscribe = () => {
    // if(!this.form.valid || this.isBusy) return;

    this.isBusy = true;
    this.personApi.subscribe(this.email).pipe(
      finalize(() => this.isBusy = false)
    ).subscribe(x => {
      this.toastr.success('Subscribed!');
      this.email = "";
    }, error => {
      this.toastr.error('Something went wrong.');
    })
  }
}
