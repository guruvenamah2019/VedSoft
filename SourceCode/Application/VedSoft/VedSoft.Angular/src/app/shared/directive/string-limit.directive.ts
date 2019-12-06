import { Directive, Input } from '@angular/core'


@Directive({
    selector: '[limit-to]',
    host: {
        '(keypress)': '_onKeypress($event)',
    }
})
export class StringLimitToDirective {
    @Input('limit-to') limitTo:any;
    _onKeypress(e:any) {
        const limit = +this.limitTo;
		 if (e.target.value.length === limit && e.charCode != 0) e.preventDefault();
        //if (e.target.value.length === limit) e.preventDefault();
    }
}