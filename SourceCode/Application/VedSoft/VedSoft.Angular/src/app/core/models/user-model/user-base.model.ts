import { AddressModel, ContactNumberModel } from "../master-model"
export class UserBaseModel {
   public loginId?: string;
   public password?: string;
   public firstName?: string;
   public middleName?: string;
   public lastName?: string;
   public notificationId?: string;
   public primaryContact?: string;
   public dateOfBirth?: string;
   public sex?: string;
   public imageName?: string;
}

export class UserAdditionalDetailsModel {
    qualification?: string;
    annualIncome?: number;
    occupation?: string;
    address?: AddressModel;
    contactNumber?: ContactNumberModel;
}