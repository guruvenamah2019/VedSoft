export class UserMasterModel {
  id?: number;
  username?: string;
  firstName?: string;
  middleName?:string;
  lastName?: string;
  notificationEmailId?: string;
userDetailsId ?:string;

  constructor() {
    this.id = 1;
    this.username = "Admin";

  }
}
