<script setup>
import Rightbar from "@/components/right-bar.vue"
import { RouterLink, useRouter } from "vue-router";
import { forgotPasswordRequest } from "@/interfaces/requestModels/user/forgotPasswordRequest";
import { AuthApi } from "@/apis/authApi";
import { toast } from "vue3-toastify";
import "vue3-toastify/dist/index.css";
import {ref} from 'vue';

const loading = ref(false);
const businessExecute = ref(forgotPasswordRequest);
const time = ref();
const router = useRouter();

const forgotPassword = async () => {
  loading.value = false;
  const result = await AuthApi.forgotPassword(businessExecute.value);
  console.log(result);
  if (result.data.succeeded === true) {
    toast("Mã xác nhận đã được gửi về email của bạn", {
      type: "success",
      transition: "flip",
      autoClose: 1500,
      theme: "dark",
      dangerouslyHTMLString: true,
    });
    time.value = setTimeout(() => {
      router.push("/reset-password-v1");
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
}

</script>

<template>
    <div class="auth-main v1">
        <div class="auth-wrapper">
            <div class="auth-form">
                <div class="card my-5">
                    <div class="card-body">
                        <div class="text-center">
                            <img src="@/assets/images/authentication/img-auth-fporgot-password.png" alt="images"
                                class="img-fluid mb-3">
                            <h4 class="f-w-500 mb-1">Forgot Password</h4>
                            <p class="mb-3">Back to <RouterLink href="#" :to="{path: '/login-v1'}" class="link-primary ms-1">Log in</RouterLink>
                            </p>
                        </div>
                        <div class="form-group mb-3">
                            <label class="form-label">Email Address</label>
                            <input type="email" class="form-control" id="floatingInput" placeholder="Email Address" v-model="businessExecute.email">
                        </div>
                        <div class="d-grid mt-3">
                            <button type="button" class="btn btn-primary" @click="forgotPassword">Send reset email</button>
                        </div>
                    </div>
                </div>
            </div>

            <div class="auth-sidefooter">
                <hr class="mb-3 mt-4">
                <BRow class="row">
                    <BCol class="col my-1">
                        <p class="m-0">MieBook</p>
                    </BCol>
                    <BCol class="col-auto my-1">
                        <ul class="list-inline footer-link mb-0">
                            <li class="list-inline-item"><router-link to="/dashboard">Home</router-link></li>
                            <li class="list-inline-item"><a href="#"
                                    target="_blank">Documentation</a></li>
                            <li class="list-inline-item"><a href="#"
                                    target="_blank">Contact</a></li>
                        </ul>
                    </BCol>
                </BRow>
            </div>
        </div>
    </div>
    <Rightbar />
</template>
