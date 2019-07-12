import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { UserService, BaseService, AuthService } from './core/services/index';
import { AuthGuard, AdminGuard } from './core/guards/index';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { TokenInterceptor } from './core/interceptor/index';
import { fakeBackendProvider } from '../app/core/interceptor/fake-backend';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [
    BaseService,
    UserService,
    //{ provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    //{ provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: TokenInterceptor, multi: true },
    AuthGuard,
    AdminGuard,
    AuthService,
    fakeBackendProvider

  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
