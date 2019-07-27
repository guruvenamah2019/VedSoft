export class UserMasterModel {
  id?: number;
  userName?: string;
  firstName?: string;
  middleName?:string;
  lastName?: string;
  notificationEmailId?: string;
userDetailsId ?:string;

  constructor() {
    this.id = 1;
    this.userName = "Admin";

  }
}
