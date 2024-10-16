<script setup>
import Rightbar from "@/components/right-bar.vue";
import { RouterLink, useRouter } from "vue-router";
import { AuthApi } from "@/apis/authApi";
import { toast } from "vue3-toastify";
import "vue3-toastify/dist/index.css";
import { ref } from "vue";
import { loginRequest } from "@/interfaces/requestModels/user/loginRequest";
import LocalStorageKey from "@/constants/LocalStorageKey";


const loading = ref(false);
const businessExecute = ref(loginRequest);
const time = ref();
const router = useRouter();
const rememberMe = ref(false);


const login = async () => {
  loading.value = true;
  const result = await AuthApi.login(businessExecute.value);
  const decode = parseJwt(result.data.accessToken);
  if (rememberMe.value) {
    localStorage.setItem(LocalStorageKey.ACCESS_TOKEN, result.data.accessToken);
    localStorage.setItem(LocalStorageKey.REFRESH_TOKEN, result.data.refreshToken);
    localStorage.setItem(LocalStorageKey.USER_INFO, JSON.stringify(decode));
  } else {
    sessionStorage.setItem(
      LocalStorageKey.ACCESS_TOKEN,
      result.data.accessToken
    );
    sessionStorage.setItem(LocalStorageKey.REFRESH_TOKEN, result.data.refreshToken);
    sessionStorage.setItem(LocalStorageKey.USER_INFO, JSON.stringify(decode));
  }
  if (result.data.succeeded === true) {
    toast("Đăng nhập thành công", {
      type: "success",
      transition: "flip",
      "autoClose": 1500,
      theme: "dark",
      dangerouslyHTMLString: true,
    });
    time.value = setTimeout(() => {
      router.push("/dashboard");
    }, 1500);
  } else {
    toast(result.data.error[0], {
      type: "error",
      transition: "flip",
      theme: "dark",
      "autoClose": 1500,
      dangerouslyHTMLString: true,
    });
  }

  loading.value = false;
};

const parseJwt = (token) => {
  var base64Url = token.split(".")[1];
  var base64 = base64Url.replace(/-/g, "+").replace(/_/g, "/");
  var jsonPayload = decodeURIComponent(
    window
      .atob(base64)
      .split("")
      .map(function (c) {
        return "%" + ("00" + c.charCodeAt(0).toString(16)).slice(-2);
      })
      .join("")
  );

  return JSON.parse(jsonPayload);
};
</script>

<template>
    <div class="auth-main v1">
        <div class="auth-wrapper">
            <div class="auth-form">
                <div class="card my-5">
                    <div class="card-body">
                        <div class="text-center">
                            <img src="@/assets/images/authentication/img-auth-login.png" alt="images"
                                class="img-fluid mb-3">
                            <h4 class="f-w-500 mb-1"></h4>
                            <p class="mb-3">Bạn chưa có tài khoản?<RouterLink href="#" :to="{name: 'register-v1'}"
                                    class="link-primary ms-1">Đăng ký</RouterLink></p>
                        </div>
                        <div class="form-group mb-3">
                            <input type="email" class="form-control" id="floatingInput" placeholder="Email" v-model="businessExecute.email">
                        </div>
                        <div class="form-group mb-3">
                            <input type="password" class="form-control" id="floatingInput1" placeholder="Password" v-model="businessExecute.password">
                        </div>
                        <div class="d-flex mt-1 justify-content-between align-items-center">
                            <div class="form-check">
                                <input class="form-check-input input-primary" type="checkbox" id="customCheckc1" checked="">
                                <label class="form-check-label text-muted" for="customCheckc1">Nhớ mật khẩu</label>
                            </div>
                            <RouterLink href="#" :to="{path: '/forgot-password-v1'}">
                                <h6 class="f-w-400 mb-0">Quên mật khẩu?</h6>
                            </RouterLink>
                        </div>
                        <div class="d-grid mt-4">
                            <button type="button" class="btn btn-primary" @click="login">Đăng nhập</button>
                        </div>
                        <div class="saprator my-3">
                            <span>Hoặc</span>
                        </div>
                        <div class="text-center">
                            <ul class="list-inline mx-auto mt-3 mb-0">
                                <li class="list-inline-item">
                                    <a href="https://www.facebook.com/" class="avtar avtar-s rounded-circle bg-facebook"
                                        target="_blank">
                                        <i class="fab fa-facebook-f text-white"></i>
                                    </a>
                                </li>
                                <li class="list-inline-item">
                                    <a href="https://twitter.com/" class="avtar avtar-s rounded-circle bg-twitter"
                                        target="_blank">
                                        <i class="fab fa-twitter text-white"></i>
                                    </a>
                                </li>
                                <li class="list-inline-item">
                                    <a href="https://myaccount.google.com/"
                                        class="avtar avtar-s rounded-circle bg-googleplus" target="_blank">
                                        <i class="fab fa-google text-white"></i>
                                    </a>
                                </li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>

            <div class="auth-sidefooter">
                <img src="@/assets/images/logo-dark.svg" class="img-brand img-fluid" alt="images">
                <hr class="mb-3 mt-4">
                <BRow class="row">
                    <BCol class="col my-1">
                        <p class="m-0">Light Able ♥ crafted by Team <a href="#" target="_blank">
                                themes</a></p>
                    </BCol>
                    <Bcol class="col-auto my-1">
                        <ul class="list-inline footer-link mb-0">
                            <li class="list-inline-item"><router-link to="/dashboard">Home</router-link></li>
                            <li class="list-inline-item"><a href="#"
                                    target="_blank">Documentation</a></li>
                            <li class="list-inline-item"><a href="#"
                                    target="_blank">Support</a></li>
                        </ul>
                    </Bcol>
                </BRow>
            </div>
        </div>
    </div>
    <Rightbar />
</template>
