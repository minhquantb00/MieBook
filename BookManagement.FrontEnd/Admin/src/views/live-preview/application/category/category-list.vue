<script setup>
import Layout from "@/layout/main-admin.vue";
import pageheader from "@/components/page-header.vue";
import { onMounted, ref } from "vue";
import { CategoryApi } from "@/apis/categoryApi";
import { filterCategoryRequest } from "@/interfaces/requestModels/category/filterCategoryRequest";
import { RouterLink, useRouter } from "vue-router";
const dataCategories = ref([]);
const businessExecute = ref(filterCategoryRequest);
const categoryIdToDelete = ref(null); // Lưu ID của sản phẩm cần xoá
const showDeleteModal = ref(false);
const getAllCategories = async () => {
  const result = await CategoryApi.getAllCategories(businessExecute.value);
  dataCategories.value = result.data.dataResponseCategories;
};
const router = useRouter();
const viewBook = (id) => {
  router.push({
    name: "update-category",
    params: { id },
  });
};
// Xử lý khi nhấn vào nút xóa
const confirmDelete = (id) => {
  categoryIdToDelete.value = id; // Lưu ID sản phẩm cần xóa
  showDeleteModal.value = true; // Hiển thị modal
};

// Xử lý xóa sản phẩm
const deleteProduct = async () => {
  if (categoryIdToDelete.value) {
    try {
      await CategoryApi.deleteCategory(categoryIdToDelete.value);
      // Sau khi xóa thành công, cập nhật lại danh sách sản phẩm
      await getAllCategories();
      showDeleteModal.value = false; // Ẩn modal
    } catch (error) {
      console.error(error);
      showDeleteModal.value = false; // Ẩn modal nếu có lỗi
    }
  }
};

onMounted(async () => {
  await getAllCategories();
});
</script>

<template>
  <Layout>
    <pageheader title="Category list" pageTitle="Category" />
    <BRow>
      <BCol class="col-sm-12">
        <BCard no-body class="table-card">
          <BCardBody>
            <div class="text-end p-sm-4 pb-sm-2">
              <RouterLink :to="{ path: '/add-category' }" class="btn btn-primary">
                <i class="ti ti-plus f-18"></i>
                Thêm danh mục
              </RouterLink>
            </div>
            <div class="table-responsive">
              <table class="table table-hover tbl-product" id="pc-dt-simple">
                <thead>
                  <tr>
                    <th class="text-left">STT</th>
                    <th class="text-left">Tên danh mục</th>
                    <th class="text-left">Action</th>
                  </tr>
                </thead>
                <tbody v-for="(item, index) in dataCategories" :key="item.id">
                  <tr>
                    <td>{{ index + 1 }}</td>
                    <td>
                      {{ item.name }}
                    </td>
                    <td class="text-center">
                      <div class="prod-action-links">
                        <ul class="list-inline me-auto mb-0">
                          <li
                            class="list-inline-item align-bottom"
                            data-bs-toggle="tooltip"
                            title="Edit"
                          >
                            <button
                              @click="viewBook(item.id)"
                              class="avtar avtar-xs btn-link-success btn-pc-default"
                            >
                              <i class="ti ti-edit-circle f-18"></i>
                            </button>
                          </li>
                          <li
                            class="list-inline-item align-bottom"
                            data-bs-toggle="tooltip"
                            title="Delete"
                          >
                            <BButton
                              href="#"
                              class="avtar avtar-xs btn-link-danger btn-pc-default"
                              @click="confirmDelete(item.id)"
                            >
                              <i class="ti ti-trash f-18"> </i>
                            </BButton>
                          </li>
                        </ul>
                      </div>
                    </td>
                  </tr>
                </tbody>
              </table>
            </div>
          </BCardBody>
        </BCard>
      </BCol>
    </BRow>
    <BModal
      v-model="showDeleteModal"
      title="Xác nhận xóa"
      @ok="deleteProduct"
      @cancel="showDeleteModal = false"
    >
      <p>Bạn có chắc chắn muốn xóa sản phẩm này không?</p>
    </BModal>
  </Layout>
</template>
