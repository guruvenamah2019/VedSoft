import { Injectable } from "@angular/core";
@Injectable()
export class SortByService {
    
    constructor() {
        

    }
   

     public sortProperties(obj: any[], sortedBy?: string, isNumericSort?: boolean, reverse?: boolean):any {
        //sortedBy = sortedBy || 1; // by default first key
        isNumericSort = isNumericSort || false; // by default text sort
        reverse = reverse || false; // by default no reverse

        var reversed = (reverse) ? -1 : 1;
         if (sortedBy) {
             var sortable = [];
             for (var key in obj) {
                 if (obj.hasOwnProperty(key)) {
                     sortable.push([key, obj[key]]);
                 }
             }

             if (isNumericSort)
                 sortable.sort(function (a, b) {
                     return reversed * (a[1][sortedBy] - b[1][sortedBy]);
                 });
             else
                 sortable.sort(function (a, b) {
                     var x = a[1][sortedBy].toLowerCase(),
                         y = b[1][sortedBy].toLowerCase();
                     return x < y ? reversed * -1 : x > y ? reversed : 0;
                 });

             var newObject: any[] = [];
             for (var i = 0; i < sortable.length; i++) {
                 var key: string = sortable[i][0];
                 var value = sortable[i][1];
                 newObject.push(value);
             }

             return newObject; // array in format [ [ key1, val1 ], [ key2, val2 ], ... ]
         }
         else {
             var sortable: any[] = obj;
             if (isNumericSort)
                 sortable.sort(function (a, b) {
                     return reversed * (a - b);
                 });
             else
                 sortable.sort(function (a, b) {
                     var x = a.toLowerCase(),
                         y = b.toLowerCase();
                     return x < y ? reversed * -1 : x > y ? reversed : 0;
                 });
             return sortable;
         }
    }
}
