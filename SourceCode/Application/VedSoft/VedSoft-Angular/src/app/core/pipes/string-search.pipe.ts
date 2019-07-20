import { Pipe, PipeTransform, Injectable } from '@angular/core';

@Pipe({
    name: 'search',
    pure: false
})
@Injectable()
export class SearchPipe implements PipeTransform {
    transform(value: string[], name: string, caseInsensitive: boolean): any {
        var values: any[] = value;
        if (name !== undefined) {
            // filter users, users which match and return true will be kept, false will be filtered out
            values = value.filter((item) => {
                if (caseInsensitive) {
                    return (item.toLowerCase().indexOf(name.toLowerCase()) !== -1);
                } else {
                    return (item.indexOf(name) !== -1);
                }
            });
        }
        return values;
    }
}