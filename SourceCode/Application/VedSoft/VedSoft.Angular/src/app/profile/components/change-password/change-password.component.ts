
import { Component, OnInit, EventEmitter, Output, Input } from '@angular/core'
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators, AbstractControl } from '@angular/forms';
import { AuthenticationService, BrowserInfoService } from "../../../core/services/index";
import { EncryptionService } from 'src/app/encryption/service/encryption.service';
import { LoginRequestModel } from 'src/app/core/models/login';
import { PasswordStrengthEnum } from "src/app/core/enums/index";
import { PasswordStrengthCheck, SetPasswordRequestModel } from "src/app/core/models/login/index"
import { LoginStatusEnum } from 'src/app/core/enums/login-status.enum';
import { PasswordStrengthConst } from 'src/app/core/constant/password-strength.const';
import { TranslateService } from '@ngx-translate/core';
import { ToastrService } from 'ngx-toastr';

@Component({
  templateUrl: 'change-password.component.html',
  styleUrls: ['change-password.component.scss']
})


export class ChangePasswordComponent {
  passwordForm: FormGroup;
  loading = false;
  submitted = false;
  returnUrl: string;
  error = '';
  PwdStrengthPower: PasswordStrengthCheck = new PasswordStrengthCheck();
  constructor(private authService: AuthenticationService, private router: Router, private formBuilder: FormBuilder,
    private route: ActivatedRoute, private encryptService: EncryptionService, 
    private translate: TranslateService,
    private toastr: ToastrService
  ) {
  }

  ngOnInit() {
    this.passwordForm = this.formBuilder.group({
      newPassword: ['', Validators.required],
      confirmPassword: ['', Validators.required],
      password: ['', Validators.required]
    }, { validator: this.checkPasswords });

    // get return url from route parameters or default to '/'
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
  }

  // convenience getter for easy access to form fields
  get f() { return this.passwordForm.controls; }

  checkPasswords(group: FormGroup) { // here we have the 'passwords' group
    let pass = group.controls.newPassword.value;
    let confirmPass = group.controls.confirmPassword.value;

    return pass === confirmPass ? null : group.controls.confirmPassword.setErrors({ MatchPassword: true })

  }

  onSubmit() {
    this.submitted = true;
    this.error = "";
    // stop here if form is invalid
    if (this.passwordForm.invalid) {
      return;
    }

    let loginInput: SetPasswordRequestModel = {
      oldPassword: this.f.password.value,
      newPassword: this.f.newPassword.value,
      userId: this.authService.loggedUser.id,
      loginUserId:this.authService.loggedUser.id
    };

    if (this.passwordValidation(loginInput)) {

      let oldPwd: string = this.encryptService.EncryptionSHA1(this.f.password.value);
      let newPwd: string = this.encryptService.EncryptionSHA1(this.f.newPassword.value);

      this.loading = true;
      this.authService.changePassword(loginInput)
        .subscribe(
          data => {
            this.loading = false;
            if (data != null && data.responseData != null) {
              if (data.responseData.statusId == LoginStatusEnum.Success) {

                this.toastr.success("Password has been change successfully",);
              }
              else if (data.responseData.statusId == LoginStatusEnum.InvalidCredentials) {
                this.toastr.error("Old Password not matched");
              }
              else
              {
                this.toastr.error("Error occured");
              }
            }

          },
          error => {
            this.error = error;
            this.loading = false;
          });
    }
  }

  passwordValidation(input: SetPasswordRequestModel): boolean {
    var oldPwd = input.oldPassword.trim();
    var password = input.newPassword.trim();
    var strength = this.checkStrength(password);
    if (strength > PasswordStrengthEnum.Weak) {
      if (oldPwd == password) {
        this.error = this.translate.instant('PWD_SAME');
        return false;
      }
      return true;
    }
    else if (strength == PasswordStrengthEnum.Weak) {
      this.error = this.translate.instant('PWD_WEAK');
    }
    else {
      this.error = this.translate.instant('PWD_TOO_SHORT');
      return false;
    }

  }

  checkStrength(password: string): number {

    //initial strength
    var strength = 0;

    //if the password length is less than 10, return message.
    if (password.length < PasswordStrengthConst.vMinimumPasswordLength) {
      return strength;
    }
    else {
      strength += 1;//if length is 10 characters or more, increase strength value
    }

    //length is ok, lets continue.



    if (password.match(/([a-z].*[A-Z])|([A-Z].*[a-z])/) && password.match(/([a-zA-Z])/) && password.match(/([0-9])/) && password.match(/([!,@,#,$,%,^,&,*,_])/))
      strength += 1;

    //////if password contains both lower and uppercase characters, increase strength value
    ////if (password.match(/([a-z].*[A-Z])|([A-Z].*[a-z])/)) strength += 1

    //////if it has numbers and characters, increase strength value
    ////if (password.match(/([a-zA-Z])/) && password.match(/([0-9])/)) strength += 1

    //////if it has one special character, increase strength value
    ////if (password.match(/([!,@,#,$,%,^,&,*,_])/)) strength += 1

    /////if password strength good then need to check the strong password combination
    if (strength != PasswordStrengthEnum.Good)
      return strength;

    if (password.length > PasswordStrengthConst.vMinimumPasswordLength)
      strength += 1;
    //if it has two special characters, increase strength value
    if (password.match(/(.*[!,%,&,@,#,$,^,*,?,_,~].*[!,%,&,@,#,$,^,*,?,_,~])/)) strength += 1;

    //now we have calculated strength value, we can return messages
    return strength;


  }

  passwordStrength(): void {
    //var lblMessageText = lblMessage + "Text";
    //var divlblStrength = "div" + lblMessage;
    var password = this.f.newPassword.value;
    if (password != '') {
      var strength = this.checkStrength(password);
      if (strength < PasswordStrengthEnum.Weak) {
        this.PwdStrengthPower = {
          className: 'short',
          text: this.translate.instant('v_TooShort'), //PasswordStrengthInfo.vToShort,
          isShow: true
        }
      } ////if value is less than 2
      else if (strength == PasswordStrengthEnum.Weak) {
        this.PwdStrengthPower = {
          className: 'weak',
          text: this.translate.instant('v_Weak'),// PasswordStrengthInfo.vWeak,
          isShow: true
        }
      }
      else if (strength == PasswordStrengthEnum.Good) {
        this.PwdStrengthPower = {
          className: 'good',
          text: this.translate.instant('v_Good'), //PasswordStrengthInfo.vGood,
          isShow: true
        }
      }
      else {
        this.PwdStrengthPower = {
          className: 'strong',
          text: this.translate.instant('v_Strong'),// PasswordStrengthInfo.vStrong,
          isShow: true
        }
      }
    }
    else {
      this.PwdStrengthPower = {
        className: '',
        text: '',
        isShow: false
      }
    }
  }


}
