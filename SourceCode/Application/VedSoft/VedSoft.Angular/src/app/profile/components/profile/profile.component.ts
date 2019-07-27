
import { Component, OnInit, EventEmitter, Output, Input } from '@angular/core'
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { AuthenticationService, BrowserInfoService } from "../../../core/services/index";
import { first } from 'rxjs/operators';
import { EncryptionService } from 'src/app/encryption/service/encryption.service';
import { LoginRequestModel, UserMasterModel } from 'src/app/core/models/user-model';
import { LoginStatusEnum } from 'src/app/core/enums/login-status.enum';
import { ValidationService } from 'src/app/core/services/validation.service';

@Component({
  templateUrl: 'profile.component.html',
})


export class ProfileComponent {
  userProfileForm: FormGroup;
  loading = false;
  submitted = false;
  returnUrl: string;
  error = '';
  myProfile: UserMasterModel = this.authService.loggedUser;
  constructor(private authService: AuthenticationService, private router: Router, private formBuilder: FormBuilder,
    private route: ActivatedRoute, private encryptService: EncryptionService, private browserService: BrowserInfoService
  ) {
    console.log("LoginComponent" + JSON.stringify(browserService.clinetInfo));
  }

  ngOnInit() {
    this.userProfileForm = this.formBuilder.group({
      firstName: new FormControl(this.myProfile.firstName, [Validators.required]),
      middleName: new FormControl(this.myProfile.middleName, []),
      lastName: new FormControl(this.myProfile.lastName, [Validators.required]),
      email: new FormControl(this.myProfile.notificationEmailId, [Validators.required, ValidationService.emailValidator]),
      userName: new FormControl({ value: this.myProfile.userName, disabled: true }, [Validators.required]),
    });

    // get return url from route parameters or default to '/'
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
  }

  // convenience getter for easy access to form fields
  get f() { return this.userProfileForm.controls; }

  onSubmit() {
    this.submitted = true;
    this.error = "";
    // stop here if form is invalid
    if (this.userProfileForm.invalid) {
      return;
    }

    let pwd: string = this.f.password.value;/// this.encryptService.EncryptionSHA1(this.f.password.value);



    this.loading = true;

  }

}
