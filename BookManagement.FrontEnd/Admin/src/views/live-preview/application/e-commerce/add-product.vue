<script setup>
import Layout from "@/layout/main-admin.vue";
import pageheader from "@/components/page-header.vue";
import { ShippingMethodApi } from "@/apis/shippingMethod.Api";
import { onMounted, ref } from "vue";
import { filterShippingMethodRequest } from "@/interfaces/requestModels/shippingMethod/filterShippingMethodRequest";
import { BookApi } from "@/apis/bookApi";
import { toast } from "vue3-toastify";
import "vue3-toastify/dist/index.css";
import { useRouter } from "vue-router";
import { TopicBookApi } from "@/apis/topicBookApi";
import { CategoryApi } from "@/apis/categoryApi";
const dataShippingMethods = ref([]);
const loading = ref(false);
const time = ref();
const router = useRouter();
const selectedFile = ref(null);
const topicBooks = ref([]);
const categories = ref([]);
const businessExecuteTopicBook = ref({
  name: "",
});
const businessExecuteCategory = ref({
  name: "",
});
const businessExecuteShippingMethod = ref(filterShippingMethodRequest);
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

const getAllTopicBooks = async () => {
  const result = await TopicBookApi.getAllTopicBooks(businessExecuteTopicBook.value);
  topicBooks.value = result.data.dataResponseTopicBooks;
};

const getAllCategories = async () => {
  const result = await CategoryApi.getAllCategories(businessExecuteCategory.value);
  categories.value = result.data.dataResponseCategories;
};

const createNewBook = async () => {
  loading.value = true;

  // Create FormData and append all fields
  const formData = new FormData();
  formData.append("name", businessExecuteBook.value.name);
  formData.append(
    "categoryId",
    businessExecuteBook.value.categoryId === undefined
      ? 6
      : businessExecuteBook.value.categoryId
  );
  formData.append(
    "topicBookId",
    businessExecuteBook.value.topicBookId === undefined
      ? 1
      : businessExecuteBook.value.topicBookId
  );
  formData.append("description", businessExecuteBook.value.description);
  formData.append("quantity", businessExecuteBook.value.quantity);
  formData.append("author", businessExecuteBook.value.author);
  formData.append("manufactureDate", businessExecuteBook.value.manufactureDate);
  formData.append("numberOfPages", businessExecuteBook.value.numberOfPages);
  formData.append("price", businessExecuteBook.value.price);

  // Append the selected file, if available
  if (selectedFile.value) {
    formData.append("imageUrl", selectedFile.value);
  }

  const result = await BookApi.createBook(formData);

  if (result.data.succeeded === true) {
    toast("Tạo thông tin sách thành công", {
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
  await getAllCategories();
  await getAllTopicBooks();
});
</script>

<template>
  <Layout>
    <pageheader title="Thêm mới sản phẩm" pageTitle="E-commerce" />
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
                required
              />
            </div>
            <div class="form-group">
              <label class="form-label">Chọn danh mục</label>
              <select
                class="form-select"
                v-model="businessExecuteBook.categoryId"
                required
              >
                <option
                  v-for="category in categories"
                  :key="category.id"
                  :value="category.id"
                >
                  {{ category.name }}
                </option>
              </select>
            </div>
            <div class="form-group">
              <label class="form-label">Chủ đề</label>
              <select
                class="form-select"
                v-model="businessExecuteBook.topicBookId"
                required
              >
                <option v-for="topic in topicBooks" :key="topic.id" :value="topic.id">
                  {{ topic.name }}
                </option>
              </select>
            </div>
            <div class="form-group mb-0">
              <label class="form-label">Mô tả sản phẩm</label>
              <textarea
                class="form-control"
                placeholder="Nhập mô tả sản phẩm"
                v-model="businessExecuteBook.description"
                required
              ></textarea>
            </div>
            <div class="form-group">
              <label class="form-label">Số lượng</label>
              <input
                type="text"
                class="form-control"
                placeholder="Nhập số lượng"
                v-model="businessExecuteBook.quantity"
                required
              />
            </div>
            <div class="form-group mb-0">
              <label class="form-label">Tác giả</label>
              <textarea
                class="form-control"
                placeholder="Nhập tên tác giả"
                v-model="businessExecuteBook.author"
                required
              ></textarea>
            </div>

            <div class="form-group mb-0 mt-2">
              <label for="demo-date-only" class="form-label">Ngày xuất bản</label>
              <input
                class="form-control"
                type="date"
                id="demo-date-only"
                v-model="businessExecuteBook.manufactureDate"
                required
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
              <input
                type="file"
                id="flupld"
                class="d-none"
                @change="handleFileUpload"
                required
              />
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
                required
              />
            </div>
            <div class="form-group">
              <label class="form-label">Gía</label>
              <input
                type="text"
                class="form-control"
                placeholder="Nhập gía"
                v-model="businessExecuteBook.price"
                required
              />
            </div>
          </BCardBody>
        </BCard>
      </BCol>
      <BCol sm="12">
        <BCard no-body>
          <BCardBody class="text-end btn-page">
            <button class="btn btn-primary mb-0" @click="createNewBook()">
              Lưu thông tin
            </button>
            <button class="btn btn-outline-secondary mb-0">Reset</button>
          </BCardBody>
        </BCard>
      </BCol>
    </BRow>
  </Layout>
</template>
