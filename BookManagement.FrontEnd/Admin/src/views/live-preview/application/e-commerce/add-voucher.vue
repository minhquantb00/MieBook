<script setup>
import Layout from "@/layout/main-admin.vue";
import pageheader from "@/components/page-header.vue";
import { ref } from "vue";
import { VoucherApi } from "@/apis/voucherApi";
import { toast } from "vue3-toastify";
import "vue3-toastify/dist/index.css";
import { useRouter } from "vue-router";
const loading = ref(false);
const time = ref();
const router = useRouter();
const createVoucherRequest = ref({
  name: "",
  discountPercent: 0.0,
});
const createNewVoucher = async () => {
  loading.value = true;

  const result = await VoucherApi.createVoucher(createVoucherRequest.value);

  if (result.data.succeeded === true) {
    toast("Tạo thông tin voucher thành công", {
      type: "success",
      transition: "flip",
      autoClose: 1500,
      theme: "dark",
      dangerouslyHTMLString: true,
    });
    time.value = setTimeout(() => {
      router.push("/user-card");
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
  <Layout>
    <pageheader title="Thêm mới voucher" pageTitle="category" />
    <BRow>
      <div class="col-xl-12">
        <div class="card">
          <div class="card-header">
            <h5>Thông tin Voucher</h5>
          </div>
          <div class="card-body">
            <div class="form-group">
              <label class="form-label">Tên voucher</label>
              <input
                type="text"
                class="form-control"
                placeholder="Nhập tên voucher"
                v-model="createVoucherRequest.name"
              />
            </div>
          </div>
          <div class="card-body">
            <div class="form-group">
              <label class="form-label">Phần trăm giảm giá</label>
              <input
                type="text"
                class="form-control"
                placeholder="Nhập phần trăm giảm giá"
                v-model="createVoucherRequest.discountPercent"
              />
            </div>
          </div>
        </div>
      </div>
      <BCol sm="12">
        <BCard no-body>
          <BCardBody class="text-end btn-page">
            <button class="btn btn-primary mb-0" @click="createNewVoucher()">
              Lưu thông tin
            </button>
            <button class="btn btn-outline-secondary mb-0">Reset</button>
          </BCardBody>
        </BCard>
      </BCol>
    </BRow>
  </Layout>
</template>
