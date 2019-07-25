
import { Component, OnInit, EventEmitter, Output, Input } from '@angular/core'
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthenticationService, BrowserInfoService } from "../../../core/services/index";
import { first } from 'rxjs/operators';
import { EncryptionService } from 'src/app/encryption/service/encryption.service';
import { LoginRequestModel, SetPasswordRequestModel } from 'src/app/core/models/user-model';
import { LoginStatusEnum } from 'src/app/core/enums/login-status.enum';

@Component({
  templateUrl: 'change-password.component.html',
})


export class ChangePasswordComponent {
  passwordForm: FormGroup;
  loading = false;
  submitted = false;
  returnUrl: string;
  error = '';
  constructor(private authService: AuthenticationService, private router: Router, private formBuilder: FormBuilder,
    private route: ActivatedRoute, private encryptService: EncryptionService, private browserService: BrowserInfoService
  ) {
    console.log("LoginComponent" + JSON.stringify(browserService.clinetInfo));
  }

  ngOnInit() {
    this.passwordForm = this.formBuilder.group({
      newPassword: ['', Validators.required],
      confirmPassword: ['', Validators.required],
      password: ['', Validators.required]
    },  {validator: this.checkPasswords });

    // get return url from route parameters or default to '/'
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
  }

  // convenience getter for easy access to form fields
  get f() { return this.passwordForm.controls; }

  checkPasswords(group: FormGroup) { // here we have the 'passwords' group
  let pass = group.controls.newPassword.value;
  let confirmPass = group.controls.confirmPassword.value;

  return pass === confirmPass ? null : { notSame: true }     
}

  onSubmit() {
    this.submitted = true;
    this.error = "";
    // stop here if form is invalid
    if (this.passwordForm.invalid) {
      return;
    }

    let oldPwd: string = this.encryptService.EncryptionSHA1(this.f.password.value);
    let newPwd: string = this.encryptService.EncryptionSHA1(this.f.newPassword.value);

    let loginInput: SetPasswordRequestModel = {
      oldPassword: this.f.password.value,
      newPassword: this.f.newPassword.value,
    };

    this.loading = true;
    this.authService.changePassword(loginInput)
      .subscribe(
        data => {
          this.loading = false;
          if (data != null && data.responseData != null) {
            if (data.responseData.ResultValue == LoginStatusEnum.TemproryPassword) {
              this.error = "You are using temporory password";
            }
            else
              this.error = "User name and password do not match";
          }
          
        },
        error => {
          this.error = error;
          this.loading = false;
        });
  }

}
