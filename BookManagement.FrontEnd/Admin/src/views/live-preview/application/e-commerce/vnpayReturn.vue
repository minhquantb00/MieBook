<script setup>
import { ref, onMounted } from "vue";
import { useRoute } from "vue-router";

const route = useRoute();
const loading = ref(true);
const response = ref({});

// Lấy dữ liệu từ query string
const fetchVnPayResult = () => {
  const succeeded = route.query.succeeded === "true";
  const resultString = route.query.resultString || "";
  const errors = route.query.errors ? route.query.errors.split(",") : [];

  response.value = {
    succeeded,
    resultString,
    errors,
  };
  loading.value = false;
};

onMounted(() => {
  fetchVnPayResult();
});
</script>

<template>
  <div class="auth-main v1">
    <div class="auth-wrapper">
      <div class="auth-form">
        <div class="error-card">
          <div class="card-body">
            <div>
              <h1>VnPay Payment</h1>
              <div v-if="loading">Đang xử lý giao dịch...</div>
              <div v-else>
                <!-- Nếu giao dịch thành công -->
                <div v-if="response.succeeded" class="success">
                  <h2>Thành công</h2>
                  <p>{{ response.resultString }}</p>
                </div>

                <!-- Nếu giao dịch thất bại -->
                <div v-else class="error">
                  <h2>Thất bại</h2>
                  <p>{{ response.errors.join(", ") }}</p>
                </div>
              </div>
            </div>
            <div class="text-center">
              <router-link
                class="btn btn-primary d-inline-flex align-items-center mb-3"
                to="/dashboard"
                ><i class="ph-duotone ph-house me-2"></i> Back to Home</router-link
              >
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<style scoped>
.success {
  color: green;
}

.error {
  color: red;
}
</style>
