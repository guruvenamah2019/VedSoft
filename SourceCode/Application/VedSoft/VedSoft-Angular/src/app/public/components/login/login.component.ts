
import { Component, OnInit, EventEmitter, Output, Input } from '@angular/core'
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthenticationService, BrowserInfoService } from "../../../core/services/index";
import { first } from 'rxjs/operators';
import { EncryptionService } from 'src/app/encryption/service/encryption.service';
import { LoginRequestModel } from 'src/app/core/models/user-model';

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
      .pipe(first())
      .subscribe(
        data => {
          this.loading = false;
          if (data) {
            this.router.navigate(["/admin/dashboard"]);
          }
        },
        error => {
          this.error = error;
          this.loading = false;
        });
  }

}
