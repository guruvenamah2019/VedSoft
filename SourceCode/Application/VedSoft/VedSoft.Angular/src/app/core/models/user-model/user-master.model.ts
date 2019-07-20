export class UserMasterModel {
  ID?: number;
  Username?: string;
  FirstName?: string;
  LastName?: string;
  EmailId?: string;
  NotificationEmailId?: string;
  constructor() {
    this.ID = 1;
    this.Username = "Admin";

  }
}
