<script setup>
import Layout from "@/layout/main-admin.vue";
import pageheader from "@/components/page-header.vue";
import { onMounted, ref } from "vue";
import { BookApi } from "@/apis/bookApi";
import { filterProductRequest } from "@/interfaces/requestModels/book/filterProductRequest";
import { useRouter } from "vue-router";
const dataProducts = ref([]);
const businessExecute = ref(filterProductRequest);
const productIdToDelete = ref(null); // Lưu ID của sản phẩm cần xoá
const showDeleteModal = ref(false);
const getAllBooks = async () => {
  const result = await BookApi.getAllBooks(businessExecute.value);
  dataProducts.value = result.data.dataResponseBooks;
};
const router = useRouter();
const formatCurrency = (value) => {
  if (value === undefined || value === null) return "0";
  return value.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ".");
};
const viewBook = (id) => {
  router.push({
    name: "update-product",
    params: { id },
  });
};
// Xử lý khi nhấn vào nút xóa
const confirmDelete = (id) => {
  productIdToDelete.value = id; // Lưu ID sản phẩm cần xóa
  showDeleteModal.value = true; // Hiển thị modal
};

// Xử lý xóa sản phẩm
const deleteProduct = async () => {
  if (productIdToDelete.value) {
    try {
      await BookApi.deleteBook(productIdToDelete.value);
      // Sau khi xóa thành công, cập nhật lại danh sách sản phẩm
      await getAllBooks();
      showDeleteModal.value = false; // Ẩn modal
    } catch (error) {
      console.error(error);
      showDeleteModal.value = false; // Ẩn modal nếu có lỗi
    }
  }
};

onMounted(async () => {
  await getAllBooks();
  console.log(dataProducts.value);
});
</script>

<template>
  <Layout>
    <pageheader title="Products list" pageTitle="E-commerce" />
    <BRow>
      <BCol class="col-sm-12">
        <BCard no-body class="table-card">
          <BCardBody>
            <div class="text-end p-sm-4 pb-sm-2">
              <RouterLink :to="{ path: '/add-product' }" class="btn btn-primary">
                <i class="ti ti-plus f-18"></i> Add Product
              </RouterLink>
            </div>
            <div class="table-responsive">
              <table class="table table-hover tbl-product" id="pc-dt-simple">
                <thead>
                  <tr>
                    <th class="text-end">STT</th>
                    <th>Tên sách</th>
                    <th>Tác giả</th>
                    <th class="text-end">Gía bán</th>
                    <th class="text-end">Số lượng</th>
                    <th class="text-center">Danh mục</th>
                    <th class="text-center">Trạng thái</th>
                  </tr>
                </thead>
                <tbody v-for="item in dataProducts" :key="item.id">
                  <tr>
                    <td class="text-end">1</td>
                    <td>
                      <BRow class="d-flex">
                        <BCol class="col-auto pe-5">
                          <img
                            :src="item.imageUrl"
                            alt="user-image"
                            class="wid-40 rounded"
                          />
                        </BCol>
                        <BCol>
                          <h6 class="mb-1">
                            {{ item.name }}
                          </h6>
                        </BCol>
                      </BRow>
                    </td>
                    <td>{{ item.author }}</td>
                    <td class="text-end">{{ formatCurrency(item.price) }} VND</td>
                    <td class="text-end">{{ item.quantity }}</td>
                    <td class="text-center">
                      {{ item.categoryName }}
                    </td>
                    <td class="text-center">
                      {{ item.status }}
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
