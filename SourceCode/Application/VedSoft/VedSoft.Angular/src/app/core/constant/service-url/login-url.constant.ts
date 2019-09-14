import { CONTROLLER_NAME } from './controller-name.constant';

export const LOGIN_SERVICE_URL = {
    AUTHENTICATE: CONTROLLER_NAME.LOGIN_CONTROLLER + "/Authenticate",
    LOGOUT: CONTROLLER_NAME.LOGIN_CONTROLLER + "/Logout",
    REFRESH_TOKEN: CONTROLLER_NAME.LOGIN_CONTROLLER + "/RefreshToken",
    UPDATE_PASSWORD: CONTROLLER_NAME.LOGIN_CONTROLLER + "/SetPassword",
    USER_DETAILS_BY_TOKEN: CONTROLLER_NAME.LOGIN_CONTROLLER + "/GetUserDetailsByToken",
}

 