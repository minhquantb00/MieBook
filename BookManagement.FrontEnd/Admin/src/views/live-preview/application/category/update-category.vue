<script setup>
import Layout from "@/layout/main-admin.vue";
import pageheader from "@/components/page-header.vue";
import { onMounted, ref } from "vue";
import { CategoryApi } from "@/apis/categoryApi";
import { toast } from "vue3-toastify";
import "vue3-toastify/dist/index.css";
import { useRouter, useRoute } from "vue-router";
const loading = ref(false);
const time = ref();
const route = useRoute();
const router = useRouter();
const idCategory = ref(route.params.id);
const category = ref({});
const updateCategoryRequest = ref({
  id: null,
  name: "",
});
const getCategoryById = async () => {
  try {
    const result = await CategoryApi.getCategoryById(idCategory.value);
    if (result?.data?.dataResponseCategory) {
      category.value = result.data.dataResponseCategory;
    } else {
      console.error("Không tìm thấy dữ liệu danh mục cho ID:", idCategory.value);
    }
  } catch (error) {
    console.error("Lỗi khi lấy dữ liệu danh mục theo ID:", error);
  }
};
const updateCategory = async () => {
  loading.value = true;
  updateCategoryRequest.value.id = idCategory.value;
  const result = await CategoryApi.updateCategory(updateCategoryRequest.value);

  if (result.data.succeeded === true) {
    toast("Sửa thông tin danh mục thành công", {
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

onMounted(async () => {
  await getCategoryById();
});
</script>

<template>
  <Layout>
    <pageheader title="Sửa thông tin danh mục" pageTitle="category" />
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
                placeholder="Nhập tên danh mục"
                v-model="updateCategoryRequest.name"
              />
            </div>
          </div>
        </div>
      </div>
      <BCol sm="12">
        <BCard no-body>
          <BCardBody class="text-end btn-page">
            <button class="btn btn-primary mb-0" @click="updateCategory()">
              Lưu thông tin
            </button>
            <button class="btn btn-outline-secondary mb-0">Reset</button>
          </BCardBody>
        </BCard>
      </BCol>
    </BRow>
  </Layout>
</template>
