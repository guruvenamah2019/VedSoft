import { NgModule,  } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { ModalModule, BsModalService,BsDropdownModule  } from 'ngx-bootstrap';
import { BaseService, UserService, AuthService } from '../core/services';
import { HTTP_INTERCEPTORS, HttpClientModule, HttpClient } from '@angular/common/http';
import { TokenInterceptor } from '../core/interceptor';
import { AuthGuard, AdminGuard } from '../core/guards';
import { fakeBackendProvider } from '../core/interceptor/fake-backend';
import { TranslateModule, TranslateLoader, TranslateService } from '@ngx-translate/core';
import { createTranslateLoader } from './loader/translate.loader';

@NgModule({
    declarations: [
        
    ],
  imports: [
    ReactiveFormsModule,
    HttpClientModule,
    CommonModule,
    ModalModule.forRoot(),
    BsDropdownModule.forRoot(),
    TranslateModule.forRoot({
        loader: {
          provide: TranslateLoader,
          useFactory: createTranslateLoader,
          deps: [HttpClient]
        }
      })
    ],
    exports:[
        ReactiveFormsModule,
        CommonModule,
        ModalModule,
        BsDropdownModule,
        TranslateModule

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

})
export class SharedModule {
    constructor(public translate: TranslateService) {
        const browserLang = translate.getBrowserLang();
        translate.use(browserLang.match(/en|hi/) ? browserLang : 'en');
    }
}
