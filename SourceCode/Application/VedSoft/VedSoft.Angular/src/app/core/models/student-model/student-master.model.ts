import { UserBaseModel, UserAdditionalDetailsModel } from '../user-model';


export class ParentModel {
  firstName?: string;
  middleName?: string;
  lastName?: string;
  notificationId?: string;
  primaryContact?: string;
  qualification?: string;
  annualIncome?: number;
}

export class GuardianBaseModel extends UserBaseModel {
  public details?: UserAdditionalDetailsModel;
}


export class StudentBaseModel extends UserBaseModel {
  studentId?:number;
  father?: ParentModel;
  mother?: ParentModel;
  details?: UserAdditionalDetailsModel;
}

export class StudentAdmissionModel {
  customerId?: number;
  branchId?: number;
  createdBy?: number;
  createdDate?: string;
  rollNo?: number;
  academicInstituteId?: number;
  isEnrolled?: number;
  studentDetails?: StudentBaseModel;
  guardianDetails?: GuardianBaseModel;
}

export class StudentCourseModel {
  id?: number;
  studentId?: number;
  branchCourseId?: number;
  courseFee?: number;
  discountAllowed?: number;
  discountedFeeAmount?: number;
  actionUserId?: number;
}

export class StudentViewModel extends UserBaseModel {
  studentId?: number;
  userId?: number;
  branchId?: number;
  branchName?: string;
}