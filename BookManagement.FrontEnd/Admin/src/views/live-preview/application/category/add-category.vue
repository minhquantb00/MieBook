<script setup>
import Layout from "@/layout/main-admin.vue";
import pageheader from "@/components/page-header.vue";
import { ref } from "vue";
import { CategoryApi } from "@/apis/categoryApi";
import { toast } from "vue3-toastify";
import "vue3-toastify/dist/index.css";
import { useRouter } from "vue-router";
const loading = ref(false);
const time = ref();
const router = useRouter();
const createCategoryRequest = ref({
  name: "",
});
const createNewCategory = async () => {
  loading.value = true;

  const result = await CategoryApi.createCategory(createCategoryRequest.value);

  if (result.data.succeeded === true) {
    toast("Tạo thông tin danh mục thành công", {
      type: "success",
      transition: "flip",
      autoClose: 1500,
      theme: "dark",
      dangerouslyHTMLString: true,
    });
    time.value = setTimeout(() => {
      router.push("/category-list");
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
    <pageheader title="Thêm mới danh mục" pageTitle="category" />
    <BRow>
      <div class="col-xl-12">
        <div class="card">
          <div class="card-header">
            <h5>Thông tin danh mục</h5>
          </div>
          <div class="card-body">
            <div class="form-group">
              <label class="form-label">Tên danh mục</label>
              <input
                type="text"
                class="form-control"
                placeholder="Nhập tên sản phẩm"
                v-model="createCategoryRequest.name"
              />
            </div>
          </div>
        </div>
      </div>
      <BCol sm="12">
        <BCard no-body>
          <BCardBody class="text-end btn-page">
            <button class="btn btn-primary mb-0" @click="createNewCategory()">
              Lưu thông tin
            </button>
            <button class="btn btn-outline-secondary mb-0">Reset</button>
          </BCardBody>
        </BCard>
      </BCol>
    </BRow>
  </Layout>
</template>
