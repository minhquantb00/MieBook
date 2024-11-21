<script setup>
import Layout from "@/layout/main-admin.vue";
import pageheader from "@/components/page-header.vue";
import { VoucherApi } from "@/apis/voucherApi";
import { ref, onMounted } from "vue";

const dataVouchers = ref([]);
const businessExecute = ref({
  name: "",
});

const getAllVouchers = async () => {
  const result = await VoucherApi.getAllVouchers(businessExecute.value);
  dataVouchers.value = result.data.dataResponseVouchers;
};

onMounted(async () => {
  await getAllVouchers();
});
</script>

<template>
  <Layout>
    <pageheader title="User Card" pageTitle="Users" />
    <BRow>
      <div class="text-end p-sm-4 pb-sm-2 mb-4">
        <RouterLink :to="{ path: '/add-voucher' }" class="btn btn-primary">
          <i class="ti ti-plus f-18"></i> Thêm voucher
        </RouterLink>
      </div>
      <BCol class="col-md-6 col-xl-4" v-for="item in dataVouchers" :key="item.id">
        <div class="card user-card">
          <div class="card-body">
            <!-- Replace your HTML code with Vue data binding -->
            <div class="user-cover-bg">
              <img
                src="@/assets/images/application/img-user-cover-5.jpg"
                alt="image"
                class="img-fluid"
              />
            </div>
            <BRow class="g-3 my-2 text-center">
              <BCol class="col-6">
                <h5 class="mb-0">{{ item.code }}</h5>
                <small class="text-muted">Code</small>
              </BCol>
              <BCol class="col-6 border border-top-0 border-bottom-0">
                <h5 class="mb-0">{{ item.name }}</h5>
                <small class="text-muted">Name</small>
              </BCol>
            </BRow>
            <div class="saprator my-2">
              <span>Phần trăm giảm giá</span>
            </div>
            <div class="d-flex align-items-center">
              <div class="flex-grow-1 me-2">
                <div class="progress" style="height: 8px">
                  <div
                    class="progress-bar bg-danger"
                    :style="{ width: item.discountPercent * 100 + '%' }"
                  ></div>
                </div>
              </div>
              <div class="flex-shrink-0">
                <h6 class="mb-0">{{ item.discountPercent * 100 }}%</h6>
              </div>
            </div>
          </div>
        </div>
      </BCol>
    </BRow>
  </Layout>
</template>
