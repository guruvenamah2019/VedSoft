import { AddressModel } from './address.model';

export class CustomerBranchModel
{
    id?: number | null;
    code?: string;
    name?: string;
    contactNumber?: string;
    address?: string;
    otherInfo?: string;
    userId?: number;
    addressInfo?:AddressModel;
    primaryContactNumber?:string
}
