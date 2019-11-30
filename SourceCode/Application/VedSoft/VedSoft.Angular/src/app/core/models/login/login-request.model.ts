export class LoginRequestModel {
  username?: string;
  password?: string;
  loginSourceInfo?: string//Browser, IP etc in JSON format
  constructor() {
    this.username = "";
    this.password = "";
    this.loginSourceInfo = ""

  }
}
