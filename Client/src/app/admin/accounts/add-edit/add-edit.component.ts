import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { first } from 'rxjs/operators';
import { MustMatch } from 'src/app/_helpers';
import { AccountService } from 'src/app/_services/account.service';
import { AlertService } from 'src/app/_services/alert.service';
import { BreadcrumbService } from 'xng-breadcrumb';

@Component({
  selector: 'app-add-edit',
  templateUrl: './add-edit.component.html',
  styleUrls: ['./add-edit.component.scss']
})
export class AddEditComponent implements OnInit {
  form: FormGroup;
  id: string;
  isAddMode: boolean;
  loading = false;
  submitted = false;

  constructor(
      private formBuilder: FormBuilder,
      private route: ActivatedRoute,
      private router: Router,
      private accountService: AccountService,
      private alertService: AlertService,
      private bcService: BreadcrumbService,
      private toastrService: ToastrService
  ) {
    this.bcService.set('@Account', '');
  }

  ngOnInit() {
      this.id = this.route.snapshot.params['id'];
      this.isAddMode = !this.id;

      this.form = this.formBuilder.group({
          title: ['', Validators.required],
          firstName: ['', Validators.required],
          lastName: ['', Validators.required],
          email: ['', [Validators.required, Validators.email]],
          role: ['', Validators.required],
          password: ['', [Validators.minLength(6), this.isAddMode ? Validators.required : Validators.nullValidator]],
          confirmPassword: ['']
      }, {
          validator: MustMatch('password', 'confirmPassword')
      });

      if (!this.isAddMode) {
          this.accountService.getById(this.id)
              .pipe(first())
              .subscribe(x => this.form.patchValue(x));
      }
  }

  // convenience getter for easy access to form fields
  get f() { return this.form.controls; }

  onSubmit() {
      this.submitted = true;

      // reset alerts on submit
      this.alertService.clear();

      // stop here if form is invalid
      if (this.form.invalid) {
          return;
      }

      this.loading = true;
      if (this.isAddMode) {
          this.createAccount();
      } else {
          this.updateAccount();
      }
  }

  private createAccount() {
      this.accountService.create(this.form.value)
          .pipe(first())
          .subscribe({
              next: () => {
                  this.toastrService.success('Account created successfully');
                  this.router.navigate(['../'], { relativeTo: this.route });
              },
              error: error => {
                  this.toastrService.error(error);
                  this.loading = false;
              }
          });
  }

  private updateAccount() {
      this.accountService.update(this.id, this.form.value)
          .pipe(first())
          .subscribe({
              next: () => {
                  this.alertService.success('Update successful', { keepAfterRouteChange: true });
                  this.router.navigate(['../../'], { relativeTo: this.route });
              },
              error: error => {
                  this.alertService.error(error);
                  this.loading = false;
              }
          });
  }
}