
import { Component, OnInit, EventEmitter, Output, Input } from '@angular/core'
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthenticationService, BrowserInfoService } from "../../../core/services/index";
import { first } from 'rxjs/operators';
import { EncryptionService } from 'src/app/encryption/service/encryption.service';
import { LoginRequestModel } from 'src/app/core/models/user-model';
import { LoginStatusEnum } from 'src/app/core/enums/login-status.enum';

@Component({
  templateUrl: 'profile.component.html',
})


export class ProfileComponent {
  loginForm: FormGroup;
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
    this.loginForm = this.formBuilder.group({
      username: ['', Validators.required],
      password: ['', Validators.required]
    });

    // get return url from route parameters or default to '/'
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
  }

  // convenience getter for easy access to form fields
  get f() { return this.loginForm.controls; }

  onSubmit() {
    this.submitted = true;
    this.error = "";
    // stop here if form is invalid
    if (this.loginForm.invalid) {
      return;
    }

    let pwd: string = this.f.password.value;/// this.encryptService.EncryptionSHA1(this.f.password.value);

    let loginInput: LoginRequestModel = {
      username: this.f.username.value,
      password: pwd,
      loginSourceInfo: JSON.stringify(this.browserService.clinetInfo)
    };

    this.loading = true;
    this.authService.login(loginInput)
      .subscribe(
        data => {
          this.loading = false;
          if (data != null && data.responseData != null) {
            if (data.responseData.loginResponseDetails.loginStatus == LoginStatusEnum.Success) {
              this.router.navigate(["/admin/dashboard"]);
            }
            else if (data.responseData.loginResponseDetails.loginStatus == LoginStatusEnum.InActive) {
              this.error = "User name is inactive";
            }
            else if (data.responseData.loginResponseDetails.loginStatus == LoginStatusEnum.InvalidCredentials) {
              this.error = "User name and password do not match";
            }
            else if (data.responseData.loginResponseDetails.loginStatus == LoginStatusEnum.LoginAttemptExceeded) {
              this.error = "Your account has been locked";
            }
            else if (data.responseData.loginResponseDetails.loginStatus == LoginStatusEnum.PasswordExpired) {
              this.error = "Your password has been expired";
            }
            else if (data.responseData.loginResponseDetails.loginStatus == LoginStatusEnum.TemproryPassword) {
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
