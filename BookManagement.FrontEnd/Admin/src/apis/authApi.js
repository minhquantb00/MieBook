import { AuthMessage } from "@/constants/enum";
import axiosIns from "@/plugin/axios";
import axios from "axios";

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

const login = async (params) => {
  try {
      const result = await axios.post(`https://localhost:7027/api/${CONTROLLER_NAME}/Login`, params);
      return result;
  } catch (error) {
      if (error.response && error.response.data && error.response.data.detail) {
          return errorList[error.response.data.detail];
      } else {
          return { error: AuthMessage.LoginFail };
      }
  }
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

const forgotPassword = async (params) => {
  try {
    const result = await axios.post(`https://localhost:7027/api/${CONTROLLER_NAME}/ForgotPassword`, params);
    return result;
  } catch (error) {
    if (error.response && error.response.data && error.response.data.detail) {
      return errorList[error.response.data.detail];
    } else {
      return { error: AuthMessage.LoginFail };
    }
  }
};

const confirmCreateNewPassword = async (params) => {
  try {
    const result = await axios.post(`https://localhost:7027/api/${CONTROLLER_NAME}/ConfirmCreateNewPassword`, params);
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
  register,
  login,
  forgotPassword,
  confirmCreateNewPassword
}
