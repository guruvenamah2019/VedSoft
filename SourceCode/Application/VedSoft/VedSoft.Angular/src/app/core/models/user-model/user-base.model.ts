export class UserBaseModel  {
    id?: number;
  username?: string;
  firstName?: string;
  lastName?: string;
    emailID?: string;
    notificationEmailID?: string;
    password?: string;
    token?: string
    constructor() {
        this.id = 1;
        this.username = "Admin";

    }
}
