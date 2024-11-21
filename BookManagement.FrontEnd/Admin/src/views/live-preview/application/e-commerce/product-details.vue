<script setup>
import Layout from "@/layout/main.vue";
import pageheader from "@/components/page-header.vue";
import { Swiper, SwiperSlide } from "swiper/vue";
import { Autoplay, A11y } from "swiper/modules";
import { BookApi } from "@/apis/bookApi";
import { useRoute, useRouter } from "vue-router";
import { onMounted, ref, watch } from "vue";
import { AddressUserApi } from "@/apis/addressUserApi";
import { toast } from "vue3-toastify";
import "vue3-toastify/dist/index.css";
import { BillApi } from "@/apis/billApi";
import { CartApi } from "@/apis/cartApi";
import { CartItemApi } from "@/apis/cartItemApi";
import { VnPayApi } from "@/apis/vnpayApi";
import { BookReviewApi } from "@/apis/bookReviewApi";
const modules = [Autoplay, A11y];
const loading = ref(false);
const userInfo = JSON.parse(localStorage.getItem("userInfo"));
const userId = ref();
const route = useRoute();
const selectedFile = ref(null);
const time = ref();
const idBook = ref(route.params.id);
const businessExecuteVnPay = ref({
  billId: null,
});
const businessExecuteBookReview = ref({
  bookId: null,
  content: "",
  imageUrl: null,
  numberOfStars: 0,
});
const router = useRouter();
const book = ref({});
const dataBookReview = ref([]);
const dataBooks = ref([]);
const modalShow13 = ref(false);
const dataAddressUser = ref([]);
const businessExecute = ref({
  address: "",
});
const cart = ref({});
const businessExecuteCartItem = ref({
  cartId: null,
  bookId: null,
});

const businessExecuteBill = ref({
  shippingMethodId: 2,
  addressUserId: null,
  paymentMethodId: 1,
  note: "",
  userVoucherId: null,
  createBillDetailUseCaseInputs: [],
});

const businessExecuteBillDetail = ref({
  bookId: null,
  quantity: 0,
  unitPrice: 0,
  note: "",
});
const selectAddress = (addressId) => {
  console.log("Địa chỉ ID đã chọn: ", addressId);
  businessExecuteBill.value.addressUserId = addressId; // Cập nhật địa chỉ đã chọn
};

const createNewBookReview = async () => {
  loading.value = true;

  // Create FormData and append all fields
  const formData = new FormData();
  formData.append("name", businessExecuteBookReview.value.content);
  formData.append("bookId", book.value.id);
  formData.append("content", businessExecuteBookReview.value.content);
  formData.append("numberOfStars", businessExecuteBookReview.value.numberOfStars);

  // Append the selected file, if available
  if (selectedFile.value) {
    formData.append("imageUrl", selectedFile.value);
  }

  const result = await BookReviewApi.createBookReview(formData);

  if (result.data.succeeded === true) {
    toast("Tạo thông tin review sách thành công", {
      type: "success",
      transition: "flip",
      autoClose: 1500,
      theme: "dark",
      dangerouslyHTMLString: true,
    });
    time.value = setTimeout(() => {
      router.push({
        name: "product-details",
        params: { id: book.value.id },
      });
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
const getBookById = async () => {
  try {
    const result = await BookApi.getBookById(idBook.value);
    if (result?.data?.dataResponseBook) {
      book.value = result.data.dataResponseBook;
      dataBookReview.value = book.value.dataResponseBookReviews || [];
    } else {
      console.error("Không tìm thấy dữ liệu sách cho ID:", idBook.value);
      dataBookReview.value = [];
    }
  } catch (error) {
    console.error("Lỗi khi lấy dữ liệu sách theo ID:", error);
    dataBookReview.value = [];
  }
};
const createAddressUser = async () => {
  loading.value = true;
  const result = await AddressUserApi.createAddressUser(businessExecute.value);

  if (result.data.succeeded === true) {
    toast("Thêm địa chỉ thành công", {
      type: "success",
      transition: "flip",
      autoClose: 1500,
      theme: "dark",
      dangerouslyHTMLString: true,
    });
    await getAllAddressUsers();
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
const increaseValue = (item) => {
  item.quantity++;
  if (item.quantity > book.value.quantity) {
    alert("Số lượng kho không đủ");
    item.quantity--;
    return;
  }
};

const displayModalDelivery = async () => {
  const msg = document.querySelector(".varyingcontentModal");
  (modalShow13.value = !modalShow13.value), (msg.innerText = "Thông tin giao hàng");
  await getAllAddressUsers();
};
const decreaseValue = (item) => {
  if (item.quantity > 0) {
    item.quantity--;
  }
};

const getAllBooks = async () => {
  const result = await BookApi.getAllBooks({
    keyword: "",
    priceFrom: null,
    priceTo: null,
    categoryId: book.value.categoryId,
    topicBookId: null,
  });
  dataBooks.value = result.data.dataResponseBooks;
};
const getAllAddressUsers = async () => {
  const result = await AddressUserApi.getAddressUserByUserId(userId.value);
  dataAddressUser.value = result.data.dataResponseAddressUser;
  console.log(dataAddressUser.value);
};
const handleFileUpload = (event) => {
  selectedFile.value = event.target.files[0];
};
const viewBook = (id) => {
  router.push({
    name: "product-details",
    params: { id },
  });
};

const formatCurrency = (value) => {
  if (value === undefined || value === null) return "0";
  return value.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ".");
};

const formatDate = (date) => {
  const d = new Date(date);
  const day = String(d.getDate()).padStart(2, "0");
  const month = String(d.getMonth() + 1).padStart(2, "0");
  const year = d.getFullYear();

  return `${day}/${month}/${year}`;
};
const selectStar = (star) => {
  businessExecuteBookReview.value.numberOfStars = star;
};
const createBill = async () => {
  loading.value = true;
  if (!userInfo) {
    toast("Bạn cần phải đăng nhập trước", {
      type: "error",
      transition: "flip",
      theme: "dark",
      autoClose: 1500,
      dangerouslyHTMLString: true,
    });
    router.push("/login-v1");
    return;
  }
  if (
    businessExecuteBill.value.addressUserId == null ||
    businessExecuteBill.value.addressUserId == undefined
  ) {
    toast("Vui lòng chọn địa chỉ", {
      type: "error",
      transition: "flip",
      autoClose: 1500,
      theme: "dark",
      dangerouslyHTMLString: true,
    });
    return;
  }
  businessExecuteBillDetail.value.bookId = book.value.id;
  businessExecuteBillDetail.value.unitPrice = book.value.price;
  businessExecuteBill.value.createBillDetailUseCaseInputs.push(
    businessExecuteBillDetail.value
  );
  const result = await BillApi.createBill(businessExecuteBill.value);

  if (result.data.succeeded === true) {
    toast("Tạo hóa đơn thành công", {
      type: "success",
      transition: "flip",
      autoClose: 1500,
      theme: "dark",
      dangerouslyHTMLString: true,
    });
    const bill = result.data.dataResponseBill;
    if (bill.billStatus == "DaThanhToan") {
      toast("Hóa đơn đã được thanh toán trước đó", {
        type: "error",
        transition: "flip",
        theme: "dark",
        autoClose: 1500,
        dangerouslyHTMLString: true,
      });
    }
    businessExecuteVnPay.value.billId = bill.id;
    const dataUrl = await VnPayApi.createVnPayUrl(businessExecuteVnPay.value);
    const url = dataUrl.data.url;

    if (dataUrl && url) {
      window.location.href = url;
    } else {
      alert("Không nhận được link thanh toán. Vui lòng thử lại.");
    }
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

const getCartByUserId = async () => {
  if (userInfo) {
    const result = await CartApi.getCartByUserId(userInfo.Id);
    cart.value = result.data.dataResponseCart;
  }
};

const createCartItem = async (bookId) => {
  loading.value = true;
  if (!userInfo) {
    toast("Bạn cần phải đăng nhập trước", {
      type: "error",
      transition: "flip",
      theme: "dark",
      autoClose: 1500,
      dangerouslyHTMLString: true,
    });
    router.push("/login-v1");
    return;
  }
  businessExecuteCartItem.value.bookId = bookId;
  const result = await CartItemApi.createCartItem(businessExecuteCartItem.value);

  if (result.data.succeeded === true) {
    toast("Thêm vào giỏ hàng thành công", {
      type: "success",
      transition: "flip",
      autoClose: 1500,
      theme: "dark",
      dangerouslyHTMLString: true,
    });
    time.value = setTimeout(() => {
      router.push("/home");
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
  await getBookById();
  await getAllBooks();
  userId.value = userInfo.Id;
  await getCartByUserId();
  if (cart.value.id !== undefined) {
    businessExecuteCartItem.value.cartId = cart.value.id;
  }
});

// Lắng nghe sự thay đổi của route.params.id để cập nhật sách và đánh giá mới
watch(
  () => route.params.id,
  async (newId) => {
    idBook.value = newId;
    await getBookById();
  }
);
</script>

<template>
  <Layout>
    <pageheader title="Products" pageTitle="E-commerce" />
    <BRow>
      <div class="col-sm-12">
        <BCard no-body>
          <BCardBody>
            <BRow>
              <BCol md="6">
                <div class="sticky-md-top product-sticky">
                  <div
                    id="carouselExampleCaptions"
                    class="carousel slide ecomm-prod-slider"
                    data-bs-ride="carousel"
                  >
                    <swiper
                      :pagination="true"
                      :modules="modules"
                      class="mySwiper"
                      slides-per-view="1"
                      :space-between="20"
                      :centered-slides="true"
                      :autoplay="{ running: true }"
                      :loop="true"
                    >
                      <div class="carousel-inner bg-light rounded position-relative">
                        <BCardBody class="position-absolute end-0 top-0">
                          <div class="form-check prod-likes">
                            <input type="checkbox" class="form-check-input" />
                            <i data-feather="heart" class="prod-likes-icon"></i>
                          </div>
                        </BCardBody>
                        <BCardBody class="position-absolute bottom-0 end-0">
                          <ul class="list-inline ms-auto mb-0 prod-likes">
                            <li class="list-inline-item m-0">
                              <a
                                href="#"
                                class="avtar avtar-xs text-white text-hover-primary"
                              >
                                <i class="ti ti-zoom-in f-18"></i>
                              </a>
                            </li>
                            <li class="list-inline-item m-0">
                              <a
                                href="#"
                                class="avtar avtar-xs text-white text-hover-primary"
                              >
                                <i class="ti ti-zoom-out f-18"></i>
                              </a>
                            </li>
                            <li class="list-inline-item m-0">
                              <a
                                href="#"
                                class="avtar avtar-xs text-white text-hover-primary"
                              >
                                <i class="ti ti-rotate-clockwise f-18"></i>
                              </a>
                            </li>
                          </ul>
                        </BCardBody>

                        <swiper-slide class="carousel-item active">
                          <img
                            :src="book.imageUrl"
                            class="d-block w-100"
                            alt="Product images"
                            style="object-fit: cover"
                          />
                        </swiper-slide>
                      </div>
                    </swiper>
                  </div>
                </div>
              </BCol>
              <BCol md="6">
                <span v-if="book.status === 'Đang bán'" class="badge bg-success f-14">{{
                  book.status
                }}</span>
                <span v-else class="badge bg-error f-14">{{ book.status }}</span>
                <h5 class="my-3">{{ book.name }}</h5>
                <div class="star f-18 mb-3">
                  <i class="fas fa-star text-warning"></i>
                  <i class="fas fa-star text-warning"></i>
                  <i class="fas fa-star text-warning"></i>
                  <i class="fas fa-star-half-alt text-warning"></i>
                  <i class="far fa-star text-muted"></i>
                  <span class="text-sm text-muted">(4.0)</span>
                </div>
                <h5 class="mt-4 mb-sm-3 mb-2 f-w-500">Mô tả</h5>
                <div>{{ book.description }}</div>
                <BRow class="form-group">
                  <BCol lg="3" sm="12" class="col-form-label"
                    >Tác giả <span class="text-danger">*: {{ book.author }}</span></BCol
                  >
                </BRow>
                <BRow class="form-group">
                  <BCol class="col-form-label col-lg-3 col-sm-12"
                    >Số lượng
                    <span class="text-danger"
                      >*: {{ book.quantity === null ? 0 : book.quantity }}</span
                    ></BCol
                  >
                  <BCol class="col-lg-6 col-md-12 col-sm-12">
                    <div class="btn-group btn-group-sm mb-2 border" role="group">
                      <button
                        type="button"
                        id="decrease"
                        @click="decreaseValue(businessExecuteBillDetail)"
                        class="btn btn-link-secondary"
                      >
                        <i class="ti ti-minus"></i>
                      </button>
                      <input
                        class="wid-35 text-center border-0 m-0 form-control rounded-0 shadow-none"
                        type="text"
                        id="number"
                        v-model="businessExecuteBillDetail.quantity"
                      />
                      <button
                        type="button"
                        id="increase"
                        @click="increaseValue(businessExecuteBillDetail)"
                        class="btn btn-link-secondary"
                      >
                        <i class="ti ti-plus"></i>
                      </button>
                    </div>
                  </BCol>
                </BRow>
                <h3 class="mb-4">
                  <b>{{ formatCurrency(book.price) }} VND</b
                  ><span class="mx-2 f-16 text-muted f-w-400 text-decoration-line-through"
                    >{{ formatCurrency(book.priceAfterDiscount) }} VND</span
                  >
                </h3>
                <BRow>
                  <BCol Cols="6">
                    <div class="d-grid">
                      <button
                        type="button"
                        class="btn btn-primary"
                        @click="displayModalDelivery()"
                      >
                        Mua ngay
                      </button>
                      <BModal
                        v-model="modalShow13"
                        hide-footer
                        title="Grids in Modals"
                        class="v-modal-custom"
                        title-class="varyingcontentModal"
                      >
                        <div class="modal-body p-0 pb-4">
                          <form>
                            <div
                              class="collapse multi-collapse show"
                              id="multiCollapseExample1"
                            >
                              <BCardBody class="border-bottom">
                                <BRow class="align-items-center mb-4">
                                  <BCol>
                                    <h5 class="mb-0">Thông tin giao hàng</h5>
                                  </BCol>
                                  <BCol class="col-auto">
                                    <button
                                      class="btn btn-primary"
                                      type="button"
                                      data-bs-toggle="collapse"
                                      data-bs-target=".multi-collapse"
                                      aria-expanded="false"
                                      aria-controls="multiCollapseExample1 multiCollapseExample2"
                                    >
                                      Thêm địa chỉ giao hàng
                                    </button>
                                  </BCol>
                                </BRow>
                              </BCardBody>
                              <BCardBody>
                                <div
                                  class="address-check-block"
                                  v-for="item in dataAddressUser"
                                  :key="item.id"
                                >
                                  <div class="address-check border rounded p-3">
                                    <div class="form-check">
                                      <input
                                        type="radio"
                                        name="radio1"
                                        class="form-check-input input-primary"
                                        :id="'address-check-' + item.id"
                                        :value="item.id"
                                        v-model="businessExecuteBill.addressUserId"
                                      />
                                      <label
                                        class="form-check-label d-block"
                                        :for="'address-check-' + item.id"
                                      >
                                        <span class="h6 mb-0 d-block">{{
                                          userInfo.FullName
                                        }}</span>
                                        <span class="text-muted address-details"
                                          >Địa chỉ: {{ item.address }}</span
                                        >
                                        <BRow
                                          class="align-items-center justify-content-between"
                                        >
                                          <BCol Cols="6">
                                            <span class="text-muted mb-0">{{
                                              userInfo.PhoneNumber
                                            }}</span>
                                          </BCol>
                                          <BCol Cols="6" class="text-end">
                                            <span
                                              class="address-btns d-flex align-items-center justify-content-end gap-2"
                                            >
                                              <a
                                                href="#"
                                                class="avtar avtar-s btn-link-danger btn-pc-default"
                                              >
                                                <i class="ti ti-trash f-20"></i>
                                              </a>
                                              <span
                                                class="btn btn-sm btn-outline-primary"
                                                @click="selectAddress(item.id)"
                                                >Giao đến địa chỉ này</span
                                              >
                                            </span>
                                          </BCol>
                                        </BRow>
                                      </label>
                                    </div>
                                  </div>
                                </div>
                              </BCardBody>
                            </div>
                            <div
                              class="collapse multi-collapse"
                              id="multiCollapseExample2"
                            >
                              <BCardBody class="border-bottom">
                                <BRow class="align-items-center">
                                  <BCol class="col-auto"> </BCol>
                                </BRow>
                              </BCardBody>
                              <BCardBody>
                                <BRow>
                                  <BCol Cols="12">
                                    <BRow class="form-group align-items-center g-2">
                                      <label class="col-lg-4 col-form-label py-0"
                                        >Địa chỉ :<small class="text-muted d-block"
                                          >Nhập địa chỉ</small
                                        ></label
                                      >
                                      <div class="col-lg-8">
                                        <input
                                          type="text"
                                          class="form-control"
                                          v-model="businessExecute.address"
                                        />
                                      </div>
                                    </BRow>
                                    <BRow class="form-group align-items-center g-2">
                                      <label class="col-lg-4 col-form-label py-0"
                                        >Số điện thoại:<small class="text-muted d-block"
                                          >Nhập số điện thoại</small
                                        ></label
                                      >
                                      <div class="col-lg-8">
                                        <input type="text" class="form-control" />
                                      </div>
                                    </BRow>
                                    <div class="text-end btn-page mb-0 mt-4">
                                      <button
                                        class="btn btn-outline-secondary"
                                        type="button"
                                        data-bs-toggle="collapse"
                                        data-bs-target=".multi-collapse"
                                        aria-expanded="false"
                                        aria-controls="multiCollapseExample1 multiCollapseExample2"
                                      >
                                        Thoát
                                      </button>
                                      <button
                                        class="btn btn-primary"
                                        @click="createAddressUser"
                                      >
                                        Lưu thông tin
                                      </button>
                                    </div>
                                  </BCol>
                                </BRow>
                              </BCardBody>
                            </div>
                          </form>
                        </div>
                        <div class="modal-footer pb-0">
                          <BButton variant="secondary" @click="modalShow13 = false"
                            >Thoát</BButton
                          >
                          <BButton variant="primary" @click="createBill"
                            >Thanh toán ngay</BButton
                          >
                        </div>
                      </BModal>
                      <div class="pc-modal-content">
                        <pre style="display: none"></pre>
                        <BLink class="md-pc-modal-copy copy"
                          ><i class="ph-duotone ph-copy"></i
                        ></BLink>
                        <BLink class="pc-collapse"
                          ><i class="ph-duotone ph-code"></i
                        ></BLink>
                      </div>
                    </div>
                  </BCol>
                  <BCol Cols="6">
                    <div class="d-grid">
                      <button
                        type="button"
                        class="btn btn-outline-secondary"
                        @click="createCartItem(book.id)"
                      >
                        Thêm vào giỏ
                      </button>
                    </div>
                  </BCol>
                </BRow>
              </BCol>
            </BRow>
          </BCardBody>
        </BCard>
        <BCard no-body>
          <BCardBody>
            <BTabs class="tab-content" nav-class="profile-tabs mb-0">
              <BTab title="Thông tin" active>
                <div class="table-responsive">
                  <table class="table table-borderless mb-0">
                    <tbody>
                      <tr>
                        <td class="text-muted py-1">Tác giả : {{ book.author }}</td>

                        <td class="py-1"></td>
                      </tr>
                      <tr>
                        <td class="text-muted py-1">
                          Tên thể loại : {{ book.categoryName }}
                        </td>
                      </tr>

                      <tr>
                        <td class="text-muted py-1">
                          Tên danh mục : {{ book.topicBookName }}
                        </td>
                      </tr>

                      <tr>
                        <td class="text-muted py-1">
                          Ngày xuất bản : {{ formatDate(book.manufactureDate) }}
                        </td>
                      </tr>

                      <tr>
                        <td class="text-muted py-1">
                          Số trang : {{ book.numberOfPages }}
                        </td>
                      </tr>
                    </tbody>
                  </table>
                </div>
              </BTab>
              <BTab
                title="Overview"
                class="tab-pane"
                id="ecomtab-3"
                role="tabpanel"
                aria-labelledby="ecomtab-tab-3"
              >
                <div class="table-responsive">
                  <p class="text-muted">
                    {{ book.description }}
                  </p>
                </div>
              </BTab>
              <BTab>
                <template #title>
                  <div>
                    Reviews
                    <span class="badge bg-light-primary rounded-pill px-2 ms-2">{{
                      book.reviewQuantity
                    }}</span>
                  </div>
                </template>
                <div class="card">
                  <div class="card-body">
                    <BRow class="justify-content-between align-items-center">
                      <BCol class="col-xxl-4 col-xl-5">
                        <h2 class="mb-3">
                          <b
                            >{{ book.averageRating
                            }}<small class="text-muted f-18">/5</small></b
                          >
                        </h2>
                        <p class="mb-2 text-muted">
                          {{ book.reviewQuantity }} lượt reviews
                        </p>
                        <div class="star mb-3 f-20">
                          <div v-if="book.averageRating === 0">
                            <i class="far fa-star text-muted"></i>
                            <i class="far fa-star text-muted"></i>
                            <i class="far fa-star text-muted"></i>
                            <i class="far fa-star text-muted"></i>
                            <i class="far fa-star text-muted"></i>
                          </div>
                          <i
                            v-for="star in Array.from({ length: book.averageRating })"
                            :key="star"
                            class="fas fa-star text-warning"
                          ></i>
                        </div>
                      </BCol>
                      <BCol xl="5" class="col-xxl-4 col-xl-5">
                        <div class="d-flex align-items-center">
                          <div class="w-100">
                            <BRow class="align-items-center my-2">
                              <BCol>
                                <div class="progress" style="height: 4px">
                                  <div
                                    class="progress-bar bg-warning"
                                    :style="{ width: book.percentOf5Star + '%' }"
                                  ></div>
                                </div>
                              </BCol>
                              <BCol class="col-auto">
                                <p class="mb-0 text-muted">5 Stars</p>
                              </BCol>
                            </BRow>
                            <BRow class="align-items-center my-2">
                              <BCol>
                                <div class="progress" style="height: 4px">
                                  <div
                                    class="progress-bar bg-warning"
                                    :style="{ width: book.percentOf4Star + '%' }"
                                  ></div>
                                </div>
                              </BCol>
                              <BCol class="col-auto">
                                <p class="mb-0 text-muted">4 Stars</p>
                              </BCol>
                            </BRow>
                            <BRow class="align-items-center my-2">
                              <BCol class="col">
                                <div class="progress" style="height: 4px">
                                  <div
                                    class="progress-bar bg-warning"
                                    :style="{ width: book.percentOf3Star + '%' }"
                                  ></div>
                                </div>
                              </BCol>
                              <BCol class="col-auto">
                                <p class="mb-0 text-muted">3 Stars</p>
                              </BCol>
                            </BRow>
                            <BRow class="align-items-center my-2">
                              <BCol>
                                <div class="progress" style="height: 4px">
                                  <div
                                    class="progress-bar bg-warning"
                                    :style="{ width: book.percentOf2Star + '%' }"
                                  ></div>
                                </div>
                              </BCol>
                              <BCol class="col-auto">
                                <p class="mb-0 text-muted">2 Stars</p>
                              </BCol>
                            </BRow>
                            <BRow class="align-items-center">
                              <BCol class="col">
                                <div class="progress" style="height: 4px">
                                  <div
                                    class="progress-bar bg-warning"
                                    :style="{ width: book.percentOf1Star + '%' }"
                                  ></div>
                                </div>
                              </BCol>
                              <BCol class="col-auto">
                                <p class="mb-0 text-muted">1 Stars</p>
                              </BCol>
                            </BRow>
                          </div>
                        </div>
                      </BCol>
                    </BRow>
                  </div>
                </div>
                <div v-for="item in dataBookReview" :key="item.id">
                  <BCard no-body>
                    <BCardBody>
                      <div class="media align-items-start">
                        <div class="chat-avtar">
                          <img
                            class="img-radius img-fluid wid-40"
                            src="@/assets/images/user/avatar-1.jpg"
                            alt="User image"
                          />
                          <div class="bg-success chat-badge"></div>
                        </div>
                        <div class="media-body ms-3">
                          <h6 class="mb-1">{{ item.fullName }}</h6>
                          <p class="text-muted text-sm mb-1">
                            {{ formatDate(item.reviewTime) }}
                          </p>
                          <div class="star">
                            <i
                              v-for="star in Array.from({ length: item.numberOfStars })"
                              :key="star"
                              class="fas fa-star text-warning"
                            ></i>
                          </div>
                          <p class="mb-0 text-muted mt-1">
                            {{ item.content }}
                          </p>
                        </div>
                      </div>
                    </BCardBody>
                  </BCard>
                </div>
                <div>
                  <BCard>
                    <BCardBody no-body>
                      <div class="star-rating d-flex mb-2">
                        <i
                          v-for="star in 5"
                          :key="star"
                          class="fa-star"
                          :class="{
                            'fas text-warning':
                              star <= businessExecuteBookReview.numberOfStars,
                            'far text-muted':
                              star > businessExecuteBookReview.numberOfStars,
                          }"
                          @click="selectStar(star)"
                          style="cursor: pointer; font-size: 20px"
                        ></i>
                      </div>
                      <div class="media align-items-center mt-3">
                        <img
                          class="img-radius d-none d-sm-inline-flex me-3 wid-40 rounded-circle"
                          src="@/assets/images/user/avatar-1.jpg"
                          alt="User image"
                        />

                        <div class="media-body me-3">
                          <div class="input-comment">
                            <input
                              type="email"
                              class="form-control"
                              placeholder="Viết bình luận..."
                              v-model="businessExecuteBookReview.content"
                            />
                            <ul class="list-inline start-0 mb-0">
                              <li class="list-inline-item border-end pe-2 me-2">
                                <a href="#" class="avtar avtar-xs btn-link-warning">
                                  <i class="ti ti-mood-smile f-18"></i>
                                </a>
                              </li>
                            </ul>
                            <ul class="list-inline end-0 mb-0">
                              <li class="list-inline-item">
                                <a href="#" class="avtar avtar-xs btn-link-secondary">
                                  <label class="btn" for="flupld"
                                    ><i class="ti ti-paperclip f-18"></i
                                  ></label>
                                  <input
                                    type="file"
                                    id="flupld"
                                    class="d-none"
                                    @change="handleFileUpload"
                                  />
                                </a>
                              </li>
                            </ul>
                          </div>
                        </div>
                        <button
                          class="avtar avtar-s btn btn-primary"
                          @click="createNewBookReview"
                        >
                          <i class="ti ti-send f-18"></i>
                        </button>
                      </div>
                    </BCardBody>
                  </BCard>
                </div>
                <div class="text-center mt-3">
                  <button class="btn btn-link-primary">View more comments</button>
                </div>
              </BTab>
            </BTabs>
          </BCardBody>
        </BCard>
        <BCard no-body>
          <BCardHeader>
            <h5>Thể loại tương tự</h5>
          </BCardHeader>
          <BCardBody>
            <BRow>
              <BCol v-for="item in dataBooks" :key="item.id" class="col-sm-4 col-xl-3">
                <BCard no-body class="product-card">
                  <div class="card-img-top">
                    <div class="image-container">
                      <img :src="item.imageUrl" alt="image" class="img-prod img-fluid" />
                    </div>
                    <BCardBody class="position-absolute end-0 top-0">
                      <div class="form-check prod-likes">
                        <input type="checkbox" class="form-check-input" />
                        <i data-feather="heart" class="prod-likes-icon"></i>
                      </div>
                    </BCardBody>
                  </div>
                  <BCardBody>
                    <div>
                      <p class="prod-content mb-0 text-muted">{{ item.name }}</p>
                    </div>
                    <div
                      class="d-flex align-items-center justify-content-between mt-2 mb-3 flex-wrap gap-1"
                    >
                      <h4
                        class="mb-0 text-truncate"
                        style="display: flex; flex-direction: column"
                      >
                        <b>{{ formatCurrency(book.price) }} VND</b>
                        <span
                          class="text-sm text-muted f-w-400 text-decoration-line-through"
                        >
                          {{ formatCurrency(book.priceAfterDiscount) }} VND
                        </span>
                      </h4>
                      <div class="d-inline-flex align-items-center">
                        <i class="ph-duotone ph-star text-warning me-1"></i>
                        {{ item.averageRating }} <small class="text-muted">/ 5</small>
                      </div>
                    </div>
                    <div class="d-flex">
                      <div class="flex-shrink-0">
                        <button
                          class="avtar avtar-s btn-link-secondary btn-prod-card"
                          @click="viewBook(item.id)"
                        >
                          <i class="ph-duotone ph-eye f-18"></i>
                        </button>
                      </div>
                      <div class="flex-grow-1 ms-3">
                        <div class="d-grid">
                          <button
                            class="btn btn-link-secondary btn-prod-card"
                            @click="createCartItem(book.id)"
                          >
                            Thêm vào giỏ
                          </button>
                        </div>
                      </div>
                    </div>
                  </BCardBody>
                </BCard>
              </BCol>
            </BRow>
          </BCardBody>
        </BCard>
      </div>
    </BRow>
  </Layout>
</template>
<style scoped>
.image-container {
  width: 100%;
  padding-top: 75%; /* 4:3 aspect ratio (adjust as needed) */
  position: relative;
  overflow: hidden;
}

.img-prod {
  position: absolute;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  object-fit: cover;
}
</style>
