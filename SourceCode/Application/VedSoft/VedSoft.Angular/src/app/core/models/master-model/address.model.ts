export class AddressModel {
    //name ?: string | null;
    address1?: string;
    address2?: string;
    pincode?: string;
    city?: string;
    state?: string;
    country?: string;
    constructor() {
        //this.name="";
        this.address1 = "";
        this.address2 = "";
        this.pincode = "";
        this.city = "";
        this.state = "";
        this.country = "";
    }
}


export class ContactNumberModel {
    mobile?: string;
    mobile2?: string;
    landline?: string;
}
