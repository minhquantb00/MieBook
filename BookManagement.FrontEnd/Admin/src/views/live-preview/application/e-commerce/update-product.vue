<script setup>
import Layout from "@/layout/main-admin.vue";
import pageheader from "@/components/page-header.vue";
import { ShippingMethodApi } from "@/apis/shippingMethod.Api";
import { onMounted, ref } from "vue";
import { filterShippingMethodRequest } from "@/interfaces/requestModels/shippingMethod/filterShippingMethodRequest";
import { BookApi } from "@/apis/bookApi";
import { toast } from "vue3-toastify";
import "vue3-toastify/dist/index.css";
import { useRouter, useRoute } from "vue-router";
const dataShippingMethods = ref([]);
const loading = ref(false);
const time = ref();
const route = useRoute();
const router = useRouter();
const selectedFile = ref(null);
const idBook = ref(route.params.id);
const book = ref({});
const businessExecuteShippingMethod = ref(filterShippingMethodRequest);
const getBookById = async () => {
  try {
    const result = await BookApi.getBookById(idBook.value);
    if (result?.data?.dataResponseBook) {
      book.value = result.data.dataResponseBook;
    } else {
      console.error("Không tìm thấy dữ liệu sách cho ID:", idBook.value);
    }
  } catch (error) {
    console.error("Lỗi khi lấy dữ liệu sách theo ID:", error);
  }
};
const getAllShippingMethods = async () => {
  const result = await ShippingMethodApi.getAllShippingMethods(
    businessExecuteShippingMethod.value
  );
  dataShippingMethods.value = result.data.dataResponseShippingMethods;
};
const businessExecuteBook = ref({});
const handleFileUpload = (event) => {
  selectedFile.value = event.target.files[0];
};
const updateBook = async () => {
  loading.value = true;

  // Create FormData and append all fields
  const formData = new FormData();

  // For 'name', append the value even if it's not changed (it will be empty if no new value provided)
  formData.append("id", idBook.value);
  formData.append("name", businessExecuteBook.value.name || book.value.name);

  // Check if the field is undefined and provide a default value if necessary
  formData.append(
    "categoryId",
    businessExecuteBook.value.categoryId !== undefined
      ? businessExecuteBook.value.categoryId
      : 6
  );

  formData.append(
    "topicBookId",
    businessExecuteBook.value.topicBookId !== undefined
      ? businessExecuteBook.value.topicBookId
      : 1
  );

  formData.append(
    "description",
    businessExecuteBook.value.description || book.value.description
  );
  formData.append("quantity", businessExecuteBook.value.quantity || book.value.quantity);
  formData.append("author", businessExecuteBook.value.author || book.value.author);
  formData.append(
    "manufactureDate",
    businessExecuteBook.value.manufactureDate || book.value.manufactureDate
  );
  formData.append(
    "numberOfPages",
    businessExecuteBook.value.numberOfPages || book.value.numberOfPages
  );
  formData.append("price", businessExecuteBook.value.price || book.value.price);
  formData.append("imageUrl", selectedFile.value || book.value.imageUrl);
  // Append the selected file, if available
  // if (selectedFile.value) {
  //   formData.append("imageUrl", selectedFile.value);
  // }

  const result = await BookApi.updateBook(formData);

  if (result.data.succeeded === true) {
    toast("Sửa thông tin sách thành công", {
      type: "success",
      transition: "flip",
      autoClose: 1500,
      theme: "dark",
      dangerouslyHTMLString: true,
    });
    time.value = setTimeout(() => {
      router.push("/product-list");
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
  await getAllShippingMethods();
  await getBookById();
});
</script>

<template>
  <Layout>
    <pageheader title="Sửa thông tin sản phẩm" pageTitle="E-commerce" />
    <BRow>
      <div class="col-xl-6">
        <div class="card">
          <div class="card-header">
            <h5>Thông tin sản phẩm</h5>
          </div>
          <div class="card-body">
            <div class="form-group">
              <label class="form-label">Tên sản phẩm</label>
              <input
                type="text"
                class="form-control"
                placeholder="Nhập tên sản phẩm"
                v-model="businessExecuteBook.name"
              />
            </div>
            <div class="form-group">
              <label class="form-label">Chọn danh mục</label>
              <select class="form-select" v-model="businessExecuteBook.categoryId">
                <option>Sneakers</option>
                <option>Category 1</option>
                <option>Category 2</option>
                <option>Category 3</option>
                <option>Category 4</option>
              </select>
            </div>
            <div class="form-group">
              <label class="form-label">Chủ đề</label>
              <select class="form-select" v-model="businessExecuteBook.topicBookId">
                <option>Giao hàng nhanh</option>
              </select>
            </div>
            <div class="form-group mb-0">
              <label class="form-label">Mô tả sản phẩm</label>
              <textarea
                class="form-control"
                placeholder="Nhập mô tả sản phẩm"
                v-model="businessExecuteBook.description"
              ></textarea>
            </div>
            <div class="form-group">
              <label class="form-label">Số lượng</label>
              <input
                type="text"
                class="form-control"
                placeholder="Nhập số lượng"
                v-model="businessExecuteBook.quantity"
              />
            </div>
            <div class="form-group mb-0">
              <label class="form-label">Tác giả</label>
              <textarea
                class="form-control"
                placeholder="Nhập tên tác giả"
                v-model="businessExecuteBook.author"
              ></textarea>
            </div>

            <div class="form-group mb-0 mt-2">
              <label for="demo-date-only" class="form-label">Ngày xuất bản</label>
              <input
                class="form-control"
                type="date"
                id="demo-date-only"
                v-model="businessExecuteBook.manufactureDate"
              />
            </div>
          </div>
        </div>
      </div>
      <BCol xl="6">
        <BCard no-body>
          <BCardHeader>
            <h5>Hình ảnh</h5>
          </BCardHeader>
          <BCardBody>
            <div class="form-group mb-0">
              <label class="btn btn-outline-secondary" for="flupld"
                ><i class="ti ti-upload me-2"></i> Click to Upload</label
              >
              <input type="file" id="flupld" class="d-none" @change="handleFileUpload" />
            </div>
          </BCardBody>
        </BCard>
        <BCard no-body>
          <BCardHeader>
            <h5>Vận chuyển và Giao hàng</h5>
          </BCardHeader>
          <BCardBody>
            <div class="form-group mb-0">
              <label class="form-label">Phương thức vận chuyển</label>
              <select class="form-select">
                <option>Không</option>
                <option
                  v-for="ship in dataShippingMethods"
                  :key="ship.id"
                  :value="ship.id"
                >
                  {{ ship.name }}
                </option>
              </select>
            </div>
            <div class="form-group">
              <label class="form-label">Số trang</label>
              <input
                type="text"
                class="form-control"
                placeholder="Nhập số trang"
                v-model="businessExecuteBook.numberOfPages"
              />
            </div>
            <div class="form-group">
              <label class="form-label">Gía</label>
              <input
                type="text"
                class="form-control"
                placeholder="Nhập gía"
                v-model="businessExecuteBook.price"
              />
            </div>
          </BCardBody>
        </BCard>
      </BCol>
      <BCol sm="12">
        <BCard no-body>
          <BCardBody class="text-end btn-page">
            <button class="btn btn-primary mb-0" @click="updateBook()">
              Lưu thông tin
            </button>
            <button class="btn btn-outline-secondary mb-0">Reset</button>
          </BCardBody>
        </BCard>
      </BCol>
    </BRow>
  </Layout>
</template>
