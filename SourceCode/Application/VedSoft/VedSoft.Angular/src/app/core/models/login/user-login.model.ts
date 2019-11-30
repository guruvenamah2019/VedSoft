export class UserLoginModel {
  id?: number;
  userName?: string;
  rollNumber?: number;
  firstName?: string;
  middleName?: string;
  lastName?: string;
  userTypeId?: number;
  notificationEmailId?: string;
  contactNumber?: string;
  address?: string;
  password?: string;
  lastLoginDate?: string | null;
  passwordExpiryDate?: string | null;
  lockAttempts?: number | null;
  temproryPassword?: number | null;
  active?: number | null;
  userDetailsId?: number;
  passwordValidationCode?: string;
  actionUserId?: number;
  requestedPageSize?: number;
  requestedLanguageId?: number;
  imageName?: string;


  constructor() {
    this.id = 0;
    this.userName = "";

  }
}
