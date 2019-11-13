import { UserMasterModel } from '../user-model';

export class StudentModel {
  public  Id ?:number
  public  User?:UserMasterModel
  public  FatherUser ?:UserMasterModel
  public  MotherUser ?:UserMasterModel
  public  GuardianUser ?:UserMasterModel
  public  IsEnrolled ?:number
  public  ActionUserId?:number//It will have the user Id ...who is going to perform the operation on it...not the actual user id

  constructor() {
    //super();

  }
}
