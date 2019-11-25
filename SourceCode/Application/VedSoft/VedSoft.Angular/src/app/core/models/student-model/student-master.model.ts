import { UserMasterModel } from '../user-model';

export class StudentModel {
  public id?: number
  public user?: UserMasterModel
  public fatherUser?: UserMasterModel
  public motherUser?: UserMasterModel
  public guardianUser?: UserMasterModel
  public branchId?: number
  public isEnrolled?: number
  public actionUserId?: number//It will have the user Id ...who is going to perform the operation on it...not the actual user id

  constructor() {
    //super();

  }
}
