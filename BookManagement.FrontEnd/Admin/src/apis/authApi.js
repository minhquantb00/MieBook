import { AuthMessage } from "@/constants/enum";
import axiosIns from "@/plugin/axios";

const CONTROLLER_NAME = "User";
const errorList = {
  [AuthMessage.ErrorEmailNotActivated]: {
    error: { detail: AuthMessage.EmailNotActivated },
  },
  [AuthMessage.ErrorEmailNotFound]: {
    error: { detail: AuthMessage.LoginError },
  },
  [AuthMessage.ErrorPasswordInvalid]: {
    error: { detail: AuthMessage.LoginError },
  },
  [AuthMessage.ErrorEmailExist]: { error: { detail: AuthMessage.ExistUser } },
  [AuthMessage.ErrorAccountVerified]: {
    error: { detail: AuthMessage.AccountVerified },
  },
};

const register = async (params) => {
  try {
    const result = await axiosIns.post(`${CONTROLLER_NAME}/Register`, params, {
      headers: {
        "Content-Type": "multipart/form-data",
      },
    });
    return result;
  } catch (error) {
    if (error.response && error.response.data && error.response.data.detail) {
      return errorList[error.response.data.detail];
    } else {
      return { error: AuthMessage.LoginFail };
    }
  }
};


export const AuthApi = {
  register
}
