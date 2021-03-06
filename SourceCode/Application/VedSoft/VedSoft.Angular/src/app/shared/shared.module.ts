import { NgModule, } from '@angular/core';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { ModalModule, BsModalService, BsDropdownModule } from 'ngx-bootstrap';
import { HttpClientModule, HttpClient } from '@angular/common/http';
import { TranslateModule, TranslateLoader, TranslateService } from '@ngx-translate/core';
import { createTranslateLoader } from './loader/translate.loader';
import { FooterComponent, HeaderComponent, SidebarComponent, Error404Component,Error401Component, Error500Component, AddressComponent, CustomerHeaderComponent, BranchNavigationComponent, BranchSidebarComponent } from "./components/index"
import { MatButtonModule,
  MatFormFieldModule,
  MatInputModule,
  MatRippleModule, MatMenuModule, MatTabsModule, MatSelectModule, MatIconModule, MatStepperModule,
  MatCardModule, MatDatepickerModule,MatNativeDateModule , MAT_DATE_LOCALE, MatListModule
} from "@angular/material"
import { ToastrModule } from 'ngx-toastr';
import { NumericDirective } from "./directive/numeric.directive"


@NgModule({
  declarations: [
    FooterComponent, HeaderComponent, SidebarComponent,
    Error404Component,
    Error500Component,
    AddressComponent,
    Error401Component,
    CustomerHeaderComponent,
    BranchNavigationComponent,
    BranchSidebarComponent,
    NumericDirective,
    
  ],
  imports: [
    FormsModule,
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
    RouterModule,
    MatButtonModule,
    MatFormFieldModule,
    MatInputModule,
    MatRippleModule,
    MatMenuModule,
    MatTabsModule,
    MatSelectModule,
    MatIconModule,
    MatStepperModule,
    MatCardModule,
    MatDatepickerModule,
    MatNativeDateModule ,
    MatListModule,

    
  ],
  exports: [
    FormsModule,
    ReactiveFormsModule,
    CommonModule,
    ModalModule,
    BsDropdownModule,
    TranslateModule,
    FooterComponent, HeaderComponent, SidebarComponent,
    MatButtonModule,
    MatFormFieldModule,
    MatInputModule,
    MatRippleModule,
    MatMenuModule,
    Error404Component,
    Error500Component,
    MatTabsModule,
    AddressComponent,
    MatSelectModule,
    MatIconModule,
    MatStepperModule,
    MatCardModule,
    MatDatepickerModule,
    MatListModule,
    BranchSidebarComponent,
    NumericDirective,
  ],
  providers: [
    MatNativeDateModule,
    {provide: MAT_DATE_LOCALE, useValue: 'en-IN'},
  ],

})
export class SharedModule {
  constructor(public translate: TranslateService) {
    const browserLang = translate.getBrowserLang();
    translate.use(browserLang.match(/en|hi/) ? browserLang : 'en');
  }
}
