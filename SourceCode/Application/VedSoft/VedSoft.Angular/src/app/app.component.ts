import { Component } from '@angular/core';
import { BrowserInfoService } from './core/services';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {


  constructor(private browserInfo: BrowserInfoService, public translate: TranslateService) {


    browserInfo.getClinetIdAddress().subscribe(x => {
      console.log(JSON.stringify(x));
    });
  }

}
