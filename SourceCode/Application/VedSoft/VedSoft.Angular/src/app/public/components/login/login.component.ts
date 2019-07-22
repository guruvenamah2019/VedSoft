
import { Component, OnInit, EventEmitter, Output, Input } from '@angular/core'
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthenticationService, BrowserInfoService } from "../../../core/services/index";
import { first } from 'rxjs/operators';
import { EncryptionService } from 'src/app/encryption/service/encryption.service';
import { LoginRequestModel } from 'src/app/core/models/user-model';
import { LoginStatusEnum } from 'src/app/core/enums/login-status.enum';

@Component({
  templateUrl: 'login.component.html',
})


export class LoginComponent {
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

    let pwd: string = this.encryptService.EncryptionSHA1(this.f.password.value);

    let loginInput: LoginRequestModel = {
      Username: this.f.username.value,
      Password: pwd,
      LoginSourceInfo: JSON.stringify(this.browserService.clinetInfo)
    };

    this.loading = true;
    this.authService.login(loginInput)
      .subscribe(
        data => {
          this.loading = false;
          if (data != null && data.ResponseData != null) {
            if (data.ResponseData.LoginResponseDetails.LoginStatus == LoginStatusEnum.Success) {
              this.router.navigate(["/admin/dashboard"]);
            }
            else {
              this.error = "User name and password do not match";
            }
          }
        },
        error => {
          this.error = error;
          this.loading = false;
        });
  }

}
