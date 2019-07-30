export enum LoginStatusEnum
    {
        Success=1,
        InvalidCredentials=2,
        PasswordExpired=3,
        LoginAttemptExceeded=4,
        TemproryPassword=5,
        InActive = 6,
        InvalidRefreshToken=7,
        AccontLocked = 8
    }

    export class CommonConstants
    {
       public static readonly userLoginAttemptsCountExceeded: number=5;
       public static readonly activeStatus: number=1;
       public static readonly inActiveStatus: number=0;
       public static readonly success: number=1;
       public static readonly userLoginDetailsIdClaim: string="UserLoginDetailsIdClaim";
       public static readonly accountLockedTimeInMiutes: number=30;
       public static readonly duplicateRecord: number=-1;
       public static readonly invalidRecord: number=-2;
    }