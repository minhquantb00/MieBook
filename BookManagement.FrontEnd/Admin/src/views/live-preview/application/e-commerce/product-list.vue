<script setup>
import Layout from "@/layout/main-admin.vue";
import pageheader from "@/components/page-header.vue";
import { onMounted, ref } from "vue";
import { BookApi } from "@/apis/bookApi";
import { filterProductRequest } from "@/interfaces/requestModels/book/filterProductRequest";

const dataProducts = ref([]);
const businessExecute = ref(filterProductRequest);
const getAllBooks = async () => {
  const result = await BookApi.getAllBooks(businessExecute.value);
  dataProducts.value = result.data.dataResponseBooks;
};
const formatCurrency = (value) => {
  if (value === undefined || value === null) return "0";
  return value.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ".");
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
              <a href="@/application/ecom_product-add.html" class="btn btn-primary">
                <i class="ti ti-plus f-18"></i> Add Product
              </a>
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
                    <th class="text-center">Brand</th>
                    <th class="text-center">Status</th>
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
                      <i
                        class="ph-duotone ph-check-circle text-success f-24"
                        data-bs-toggle="tooltip"
                        data-bs-title="success"
                      ></i>
                    </td>
                    <td class="text-center">
                      <img
                        src="@/assets/images/application/img-prod-brand-1.png"
                        alt="user-image"
                        class="wid-40"
                      />
                      <div class="prod-action-links">
                        <ul class="list-inline me-auto mb-0">
                          <li
                            class="list-inline-item align-bottom"
                            data-bs-toggle="tooltip"
                            title="View"
                          >
                            <a
                              href="#"
                              class="avtar avtar-xs btn-link-secondary btn-pc-default"
                            >
                              <i class="ti ti-eye f-18"></i>
                            </a>
                          </li>
                          <li
                            class="list-inline-item align-bottom"
                            data-bs-toggle="tooltip"
                            title="Edit"
                          >
                            <a
                              href="@/application/ecom_product-add.html"
                              class="avtar avtar-xs btn-link-success btn-pc-default"
                            >
                              <i class="ti ti-edit-circle f-18"></i>
                            </a>
                          </li>
                          <li
                            class="list-inline-item align-bottom"
                            data-bs-toggle="tooltip"
                            title="Delete"
                          >
                            <a
                              href="#"
                              class="avtar avtar-xs btn-link-danger btn-pc-default"
                            >
                              <i class="ti ti-trash f-18"></i>
                            </a>
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
  </Layout>
</template>
