import { NgModule, } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { ModalModule, BsModalService, BsDropdownModule } from 'ngx-bootstrap';
import { HttpClientModule, HttpClient } from '@angular/common/http';
import { TranslateModule, TranslateLoader, TranslateService } from '@ngx-translate/core';
import { createTranslateLoader } from './loader/translate.loader';
import { FooterComponent, HeaderComponent, SidebarComponent } from "./components/index"

@NgModule({
  declarations: [
    FooterComponent, HeaderComponent, SidebarComponent
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
    }),
    RouterModule
  ],
  exports: [
    ReactiveFormsModule,
    CommonModule,
    ModalModule,
    BsDropdownModule,
    TranslateModule,
    FooterComponent, HeaderComponent, SidebarComponent

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
