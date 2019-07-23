import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { UserService, BaseService, AuthenticationService, BrowserInfoService } from './core/services/index';
import { AuthGuard, AdminGuard } from './core/guards/index';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { TokenInterceptor } from './core/interceptor/index';
import { fakeBackendProvider } from '../app/core/interceptor/fake-backend';
import { SharedModule } from './shared/shared.module';
import { DeviceDetectorModule } from 'ngx-device-detector';
import { TranslateService } from '@ngx-translate/core';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    SharedModule,
    //HttpClientModule,
    AppRoutingModule,
    DeviceDetectorModule.forRoot(),
    //HttpClientModule
  ],
  providers: [
    BaseService,
    UserService,

    //{ provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    //{ provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: TokenInterceptor, multi: true },

    AuthGuard,
    AdminGuard,
    AuthenticationService,
    fakeBackendProvider,
    BrowserInfoService

  ],
  bootstrap: [AppComponent]
})
export class AppModule {
  constructor(public translate: TranslateService) {
    ///const browserLang = translate.getBrowserLang();
    //translate.use(browserLang.match(/en|hi/) ? browserLang : 'en');
  }
}
