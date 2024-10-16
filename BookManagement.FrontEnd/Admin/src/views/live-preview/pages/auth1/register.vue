<script setup>
import Rightbar from "@/components/right-bar.vue";
import { RouterLink, useRouter } from "vue-router";
import { AuthApi } from "@/apis/authApi";
import { toast } from "vue3-toastify";
import "vue3-toastify/dist/index.css";
import { ref } from "vue";
import { registerRequest } from "@/interfaces/requestModels/user/registerRequest";

const loading = ref(false);
const businessExecute = ref(registerRequest);
const time = ref();
const router = useRouter();
const isPasswordVisible = ref(false);
const register = async () => {
  loading.value = false;
  const result = await AuthApi.register(businessExecute.value);
  console.log(result);
  if(businessExecute.value.confirmPassword !== businessExecute.value.password){
    toast("Mật khẩu không trùng khớp", {
      type: "error",
      transition: "flip",
      theme: "dark",
      autoClose: 1500,
      dangerouslyHTMLString: true,
    });
  }
  if (result.data.succeeded === true) {
    toast("Đăng ký tài khoản thành công", {
      type: "success",
      transition: "flip",
      autoClose: 1500,
      theme: "dark",
      dangerouslyHTMLString: true,
    });
    time.value = setTimeout(() => {
      router.push("/login-v1");
    }, 1500);
  } else {
    toast(result.data.error[0], {
      type: "error",
      transition: "flip",
      theme: "dark",
      autoClose: 1500,
      dangerouslyHTMLString: true,
    });
  }
  loading.value = false;
};
</script>

<template>
  <div class="auth-main v1">
    <div class="auth-wrapper">
      <div class="auth-form">
        <div class="card my-5">
          <div class="card-body">
            <div class="text-center">
              <img
                src="@/assets/images/authentication/img-auth-register.png"
                alt="images"
                class="img-fluid mb-3"
              />
              <h4 class="f-w-500 mb-1">Đăng nhập với email</h4>
              <p class="mb-3">
                Bạn đã có tài khoản?
                <RouterLink
                  href="#"
                  :to="{ name: 'login-v1' }"
                  class="link-primary"
                  >Đăng nhập</RouterLink
                >
              </p>
            </div>
            <div class="form-group mb-3">
              <label class="form-label">Họ và tên</label>
              <input
                v-model="businessExecute.fullName"
                type="text"
                class="form-control"
                :loading="loading"
                :rules="[requiredValidator]"
              />
            </div>
            <div class="form-group mb-3">
              <label class="form-label">Giới tính</label>
              <select class="form-select" id="exampleFormControlSelect1" v-model="businessExecute.gender">
                <option>Vui lòng chọn</option>
                <option>Nam</option>
                <option>Nữ</option>
              </select>
            </div>
            <!-- <div class="form-group mb-3">
              <label for="demo-date-only" class="form-label">Ngày sinh</label>
              <input class="form-control" type="date" id="demo-date-only" />
            </div> -->
            <div class="form-group mb-3">
              <label class="form-label">Email</label>
              <input
                v-model="businessExecute.email"
                type="email"
                class="form-control"
                :loading="loading"
                :rules="[requiredValidator, emailValidator]"
              />
            </div>
            <div class="form-group mb-3">
              <label class="form-label">Số điện thoại</label>
              <input
                v-model="businessExecute.phoneNumber"
                type="text"
                class="form-control"
                :loading="loading"
                :rules="[requiredValidator]"
              />
            </div>
            <div class="form-group mb-3">
              <label class="form-label">Mật khẩu</label>
              <input
                class="form-control"
                v-model="businessExecute.password"
                :loading="loading"
                :rules="[requiredValidator]"
                :type="isPasswordVisible ? 'text' : 'password'"
                :append-inner-icon="
                  isPasswordVisible ? 'tabler-eye-off' : 'tabler-eye'
                "
                @click:append-inner="isPasswordVisible = !isPasswordVisible"
              />
            </div>
            <div class="form-group mb-3">
              <label class="form-label">Xác nhận mật khẩu</label>
              <input type="password" class="form-control" :rules="[requiredValidator]" v-model="businessExecute.confirmPassword" />
            </div>
            <div class="d-flex mt-1 justify-content-between">
              <div class="form-check">
                <input
                  class="form-check-input input-primary"
                  type="checkbox"
                  id="customCheckc1"
                  checked=""
                />
                <label class="form-check-label text-muted" for="customCheckc1"
                  >Tôi đồng ý với các chính sách & điều khoản</label
                >
              </div>
            </div>
            <div class="d-grid mt-4">
              <button type="button" class="btn btn-primary" @click="register">Đăng ký</button>
            </div>
            <div class="saprator my-3">
              <span>Hoặc</span>
            </div>
            <div class="text-center">
              <ul class="list-inline mx-auto mt-3 mb-0">
                <li class="list-inline-item">
                  <a
                    href="https://www.facebook.com/"
                    class="avtar avtar-s rounded-circle bg-facebook"
                    target="_blank"
                  >
                    <i class="fab fa-facebook-f text-white"></i>
                  </a>
                </li>
                <li class="list-inline-item">
                  <a
                    href="https://twitter.com/"
                    class="avtar avtar-s rounded-circle bg-twitter"
                    target="_blank"
                  >
                    <i class="fab fa-twitter text-white"></i>
                  </a>
                </li>
                <li class="list-inline-item">
                  <a
                    href="https://myaccount.google.com/"
                    class="avtar avtar-s rounded-circle bg-googleplus"
                    target="_blank"
                  >
                    <i class="fab fa-google text-white"></i>
                  </a>
                </li>
              </ul>
            </div>
          </div>
        </div>
      </div>

      <div class="auth-sidefooter">
        <hr class="mb-3 mt-4" />
        <BRow class="row">
          <BCol class="col my-1">
            <p class="m-0">MieBook</p>
          </BCol>
          <BCol class="col-auto my-1">
            <ul class="list-inline footer-link mb-0">
              <li class="list-inline-item">
                <router-link to="/dashboard">Home</router-link>
              </li>
              <li class="list-inline-item">
                <a href="#" target="_blank">Documentation</a>
              </li>
              <li class="list-inline-item">
                <a href="#" target="_blank">Contact</a>
              </li>
            </ul>
          </BCol>
        </BRow>
      </div>
    </div>
  </div>
  <Rightbar />
</template>
