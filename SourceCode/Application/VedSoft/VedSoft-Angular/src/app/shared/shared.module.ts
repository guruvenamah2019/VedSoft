import { NgModule,  } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { ModalModule, BsModalService,BsDropdownModule  } from 'ngx-bootstrap';
import {  HttpClientModule, HttpClient } from '@angular/common/http';
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
       
    ],

})
export class SharedModule {
  constructor(public translate: TranslateService) {
    const browserLang = translate.getBrowserLang();
    translate.use(browserLang.match(/en|hi/) ? browserLang : 'en');
  }
}
