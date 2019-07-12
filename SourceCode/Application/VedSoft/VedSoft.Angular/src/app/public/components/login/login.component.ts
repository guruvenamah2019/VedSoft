
import { Component, OnInit, EventEmitter, Output, Input } from '@angular/core'
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from "../../../core/services/auth.service";
import { first } from 'rxjs/operators';

@Component({
  templateUrl: 'login.component.html',
})


export class LoginComponent {
  loginForm: FormGroup;
  loading = false;
  submitted = false;
  returnUrl: string;
  error = '';
  constructor(private authService: AuthService, private router: Router, private formBuilder: FormBuilder,
    private route: ActivatedRoute,
  ) {
    console.log("LoginComponent")
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

    this.loading = true;
    this.authService.login({
      username: this.f.username.value,
      password: this.f.password.value
    })
      .pipe(first())
      .subscribe(
        data => {
          this.loading = false;
          this.router.navigate(["/admin/dashboard"]);
        },
        error => {
          this.error = error;
          this.loading = false;
        });
  }

}
