export class LoginRequestModel {
  Username?: string;
  Password?: string;
  LoginSourceInfo?: string//Browser, IP etc in JSON format
  constructor() {
    this.Username = "";
    this.Password = "";
    this.LoginSourceInfo = ""

  }
}
