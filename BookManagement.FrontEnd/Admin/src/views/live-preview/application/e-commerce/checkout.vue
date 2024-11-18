<script setup>
import Layout from "@/layout/main.vue";
import pageheader from "@/components/page-header.vue";
import { BCardBody } from "bootstrap-vue-next";
import { CartApi } from "@/apis/cartApi";
import { onMounted, ref, computed, watch } from "vue";
import { AddressUserApi } from "@/apis/addressUserApi";
import { toast } from "vue3-toastify";
import "vue3-toastify/dist/index.css";
import { BillApi } from "@/apis/billApi";
import { useRouter } from "vue-router";
import { CartItemApi } from "@/apis/cartItemApi";
const loading = ref(false);
const userInfo = JSON.parse(localStorage.getItem("userInfo"));
const userId = ref();
const cart = ref({});
const cartItemIdToDelete = ref(null);
const showDeleteModal = ref(false);
const dataCartItems = ref([]); // Danh sách sản phẩm trong giỏ
const dataAddressUser = ref([]);
const businessExecute = ref({
  address: "",
});
const router = useRouter();
const selectedBillDetails = computed(() => {
  return dataCartItems.value
    .filter((item) => item.selected) // Lọc các sản phẩm đã được chọn
    .map((item) => ({
      id: item.id,
      bookId: item.dataResponseBook.id, // Lấy bookId
      quantity: item.quantity, // Lấy số lượng
      unitPrice: item.dataResponseBook.price, // Lấy giá của sách
      note: "", // Có thể thêm ghi chú ở đây nếu cần
    }));
});
const selectAddress = (addressId) => {
  console.log("Địa chỉ ID đã chọn: ", addressId);
  businessExecuteBill.value.addressUserId = addressId; // Cập nhật địa chỉ đã chọn
};
const deleteCartItem = async () => {
  if (cartItemIdToDelete.value) {
    try {
      await CartItemApi.deleteCartItem(cartItemIdToDelete.value);
      // Sau khi xóa thành công, cập nhật lại danh sách sản phẩm
      userId.value = userInfo.Id;
      await getCartByUserId();
      showDeleteModal.value = false; // Ẩn modal
    } catch (error) {
      console.error(error);
      showDeleteModal.value = false; // Ẩn modal nếu có lỗi
    }
  }
};
const confirmDelete = (id) => {
  cartItemIdToDelete.value = id; // Lưu ID sản phẩm cần xóa
  showDeleteModal.value = true; // Hiển thị modal
};
// const businessExecuteBillDetail = ref([]);
const businessExecuteBill = ref({
  shippingMethodId: 2,
  addressUserId: null,
  paymentMethodId: 1,
  note: "",
  userVoucherId: null,
  createBillDetailUseCaseInputs: [],
});
watch(selectedBillDetails, (newDetails) => {
  businessExecuteBill.value.createBillDetailUseCaseInputs = newDetails;
});
const createBill = async () => {
  loading.value = true;
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
  const result = await BillApi.createBill(businessExecuteBill.value);
  if (selectedBillDetails.value.length === 0) {
    toast("Vui lòng chọn ít nhất một sản phẩm.", {
      type: "error",
      transition: "flip",
      autoClose: 1500,
      theme: "dark",
      dangerouslyHTMLString: true,
    });
    return;
  }

  if (result.data.succeeded === true) {
    toast("Tạo hóa đơn thành công", {
      type: "success",
      transition: "flip",
      autoClose: 1500,
      theme: "dark",
      dangerouslyHTMLString: true,
    });
    dataCartItems.value = dataCartItems.value.filter((item) => item.selected);
    dataCartItems.value.forEach(async (x) => {
      await CartItemApi.deleteCartItem(x.id);
    });
    selectAll.value = false;
    router.push("/checkout");
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
const selectAll = ref(false);

watch(selectAll, (value) => {
  dataCartItems.value.forEach((item) => {
    item.selected = value;
  });
});

watch(
  () => dataCartItems.value.map((item) => item.selected),
  (selectedStates) => {
    selectAll.value = selectedStates.every((isSelected) => isSelected);
  },
  { deep: true }
);

const getAllAddressUsers = async () => {
  const result = await AddressUserApi.getAddressUserByUserId(userId.value);
  dataAddressUser.value = result.data.dataResponseAddressUser;
  console.log(dataAddressUser.value);
};

const getCartByUserId = async () => {
  const result = await CartApi.getCartByUserId(userId.value);
  cart.value = result.data.dataResponseCart;
  dataCartItems.value = cart.value.dataResponseCartItems.map((item) => ({
    ...item,
    selected: false,
  }));
  await getAllAddressUsers();
};

const formatCurrency = (value) => {
  if (value === undefined || value === null) return "0";
  return value.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ".");
};

const cartTotalSelected = computed(() => {
  return dataCartItems.value
    .filter((item) => item.selected)
    .reduce((total, item) => {
      return total + item.dataResponseBook.price * item.quantity;
    }, 0);
});

const increaseValue = (item) => {
  item.quantity++;
  const book = item.dataResponseBook;
  if (item.quantity > book.quantity) {
    alert("Số lượng kho không đủ");
    item.quantity--;
    return;
  }
};

const decreaseValue = (item) => {
  if (item.quantity > 0) {
    item.quantity--;
  }
};

const getItemTotal = (item) => {
  return item.dataResponseBook.price * item.quantity;
};

onMounted(async () => {
  userId.value = userInfo.Id;
  await getCartByUserId();
});
</script>

<template>
  <Layout>
    <pageheader title="Checkout" pageTitle="E-commerce" />
    <BRow>
      <BCol sm="12">
        <BCardBody class="p-0">
          <BTabs
            class="mb-3"
            navClass="nav nav-tabs checkout-tabs mb-0"
            content-class="mt-3"
            pills
          >
            <BTab>
              <template #title>
                <div class="media align-items-center">
                  <div class="avtar avtar-s">
                    <i class="ti ti-shopping-cart"></i>
                  </div>
                  <div class="media-body ms-2">
                    <h5 class="mb-0">Giỏ hàng</h5>
                  </div>
                </div>
              </template>
              <BRow class="gy-4">
                <BCol xl="8">
                  <BCard no-body>
                    <BCardHeader>
                      <BRow class="align-items-center">
                        <BCol>
                          <div class="progress" style="height: 6px">
                            <div class="progress-bar bg-primary" style="width: 50%"></div>
                          </div>
                        </BCol>
                        <BCol class="col-auto">
                          <p class="mb-0 h6">Step 1</p>
                        </BCol>
                      </BRow>
                    </BCardHeader>
                    <BCardBody class="border-bottom">
                      <h5 class="mb-0">
                        Giỏ hàng
                        <span
                          class="ms-2 f-14 px-2 badge bg-light-secondary rounded-pill"
                          >{{ cart.quantity }}</span
                        >
                      </h5>
                    </BCardBody>
                    <BCardBody class="p-0 table-body">
                      <div class="table-responsive">
                        <table class="table mb-0" id="pc-dt-simple">
                          <thead>
                            <tr>
                              <th class="text-center">
                                <!-- Checkbox "Chọn tất cả" -->
                                <input
                                  class="form-check-input"
                                  type="checkbox"
                                  v-model="selectAll"
                                />
                                <label style="margin-left: 10px">All</label>
                              </th>
                              <th>Thông tin sản phẩm</th>
                              <th class="text-center">Giá</th>
                              <th class="text-center">Số lượng</th>
                              <th class="text-center">Tổng</th>
                              <th class="text-center"></th>
                            </tr>
                          </thead>
                          <tbody v-for="item in dataCartItems" :key="item.id">
                            <tr>
                              <td>
                                <div class="form-group">
                                  <div class="form-check">
                                    <input
                                      class="form-check-input"
                                      type="checkbox"
                                      value=""
                                      id="checkaddres"
                                      v-model="item.selected"
                                      checked
                                    />
                                  </div>
                                </div>
                              </td>
                              <td>
                                <div class="media align-items-center">
                                  <img
                                    :src="item.dataResponseBook.imageUrl"
                                    alt="image"
                                    class="bg-light wid-50 rounded"
                                  />
                                  <div class="media-body ms-3">
                                    <h5 class="mb-1">
                                      {{ item.dataResponseBook.name }}
                                    </h5>
                                  </div>
                                </div>
                              </td>
                              <td class="text-center">
                                <h5 class="mb-0">
                                  {{ formatCurrency(item.dataResponseBook.price) }} VND
                                </h5>
                              </td>
                              <td class="text-center">
                                <div
                                  class="btn-group btn-group-sm mb-2 border"
                                  role="group"
                                >
                                  <button
                                    type="button"
                                    @click="decreaseValue(item)"
                                    class="btn btn-link-secondary"
                                    :disabled="item.quantity === 0"
                                  >
                                    <i class="ti ti-minus"></i>
                                  </button>
                                  <input
                                    class="wid-35 text-center border-0 m-0 form-control rounded-0 shadow-none"
                                    type="text"
                                    id="number"
                                    v-model="item.quantity"
                                  />
                                  <button
                                    type="button"
                                    @click="increaseValue(item)"
                                    class="btn btn-link-secondary"
                                  >
                                    <i class="ti ti-plus"></i>
                                  </button>
                                </div>
                              </td>
                              <td class="text-end">
                                <h5 class="mb-0">
                                  {{ formatCurrency(getItemTotal(item)) }}
                                  VND
                                </h5>
                              </td>
                              <td class="text-end">
                                <BButton
                                  href="#"
                                  class="avtar avtar-s btn-link-danger btn-pc-default"
                                  @click="confirmDelete(item.id)"
                                >
                                  <i class="ti ti-trash f-18"></i>
                                </BButton>
                              </td>
                            </tr>
                          </tbody>
                        </table>
                      </div>
                    </BCardBody>
                  </BCard>
                  <div class="text-end">
                    <router-link
                      to="/product"
                      class="btn btn-link-secondary d-inline-flex align-items-center"
                      ><i class="ti ti-chevron-left me-2"></i> Back to
                      Shopping</router-link
                    >
                  </div>
                </BCol>
                <BCol xl="4">
                  <BCard no-body> </BCard>
                  <BCard no-body>
                    <BCardBody class="py-2">
                      <ul class="list-group list-group-flush">
                        <li class="list-group-item px-0">
                          <h5 class="mb-0">Tóm tắt đơn hàng</h5>
                        </li>
                        <li class="list-group-item px-0">
                          <div class="float-end">
                            <h5 class="mb-0">
                              {{ formatCurrency(cartTotalSelected) }} VND
                            </h5>
                          </div>
                          <span class="text-muted">Tổng cộng</span>
                        </li>
                        <li class="list-group-item px-0">
                          <div class="float-end">
                            <h5 class="mb-0">-</h5>
                          </div>
                          <span class="text-muted">Phương thức giao hàng</span>
                        </li>
                        <li class="list-group-item px-0">
                          <div class="float-end">
                            <h5 class="mb-0">-</h5>
                          </div>
                          <span class="text-muted">Voucher</span>
                        </li>
                      </ul>
                    </BCardBody>
                  </BCard>
                  <BCard no-body>
                    <BCardBody class="py-2">
                      <ul class="list-group list-group-flush">
                        <li class="list-group-item px-0">
                          <div class="float-end">
                            <h5 class="mb-0">
                              {{ formatCurrency(cartTotalSelected) }} VND
                            </h5>
                          </div>
                          <h5 class="mb-0 d-inline-block">Tổng tiền</h5>
                        </li>
                      </ul>
                    </BCardBody>
                  </BCard>
                  <BCard no-body> </BCard>
                  <!-- <div class="d-grid mb-3">
                    <button class="btn btn-primary">Xác nhận đặt hàng</button>
                  </div> -->
                </BCol>
              </BRow>
            </BTab>
            <BTab>
              <template #title>
                <!-- Your provided code snippet goes here -->
                <div class="media align-items-center">
                  <div class="avtar avtar-s">
                    <i class="ti ti-building-skyscraper"></i>
                  </div>
                  <div class="media-body ms-2">
                    <h5 class="mb-0">Thông tin giao hàng</h5>
                  </div>
                </div>
              </template>
              <BRow>
                <BCol xl="8">
                  <BCard no-body>
                    <BCardHeader>
                      <BRow class="align-items-center">
                        <BCol>
                          <div class="progress" style="height: 6px">
                            <div class="progress-bar bg-primary" style="width: 99%"></div>
                          </div>
                        </BCol>
                        <BCol class="col-auto">
                          <p class="mb-0 h6">Step 2</p>
                        </BCol>
                      </BRow>
                    </BCardHeader>
                    <div class="collapse multi-collapse show" id="multiCollapseExample1">
                      <BCardBody class="border-bottom">
                        <BRow class="align-items-center">
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
                                <BRow class="align-items-center justify-content-between">
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
                    <div class="collapse multi-collapse" id="multiCollapseExample2">
                      <BCardBody class="border-bottom">
                        <BRow class="align-items-center">
                          <BCol>
                            <h5 class="mb-0">Thêm địa chỉ giao hàng</h5>
                          </BCol>
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
                              <button class="btn btn-primary" @click="createAddressUser">
                                Lưu thông tin
                              </button>
                            </div>
                          </BCol>
                        </BRow>
                      </BCardBody>
                    </div>
                  </BCard>
                  <div class="d-flex justify-content-end mb-3">
                    <button class="btn btn-link-primary">
                      <i class="ti ti-arrow-narrow-left align-text-bottom me-2"></i>Back
                      to Cart
                    </button>
                  </div>
                </BCol>
                <BCol xl="4">
                  <BCard no-body>
                    <BCardHeader>
                      <h5>Tóm tắt đơn hàng</h5>
                    </BCardHeader>
                    <BCardBody class="p-0">
                      <ul class="list-group list-group-flush">
                        <li
                          class="list-group-item"
                          v-for="item in dataCartItems"
                          :key="item.id"
                        >
                          <div class="media align-items-start" v-if="item.selected">
                            <img
                              class="bg-light rounded img-fluid wid-60 flex-shrink-0"
                              :src="item.dataResponseBook.imageUrl"
                              alt="User image"
                            />
                            <div class="media-body mx-2">
                              <h5 class="mb-1">{{ item.dataResponseBook.name }}</h5>
                              <p class="text-muted text-sm mb-2"></p>
                              <h5 class="mb-1">
                                <b>{{ formatCurrency(item.dataResponseBook.price) }}VND</b
                                ><span
                                  class="mx-2 text-sm text-decoration-line-through text-muted f-w-400"
                                  >{{
                                    formatCurrency(item.dataResponseBook.price)
                                  }}VND</span
                                >
                              </h5>
                            </div>
                            <a
                              href="#"
                              class="avtar avtar-s btn-link-danger btn-pc-default flex-shrink-0"
                            >
                              <i class="ti ti-trash f-20"></i>
                            </a>
                          </div>
                        </li>
                        <li class="list-group-item">
                          <div class="float-end">
                            <h5 class="mb-0">
                              {{ formatCurrency(cartTotalSelected) }} VND
                            </h5>
                          </div>
                          <span class="text-muted">Tổng cộng</span>
                        </li>
                        <li class="list-group-item">
                          <div class="float-end">
                            <h5 class="mb-0">-</h5>
                          </div>
                          <span class="text-muted">Dự kiến giao hàng</span>
                        </li>
                        <li class="list-group-item">
                          <div class="float-end">
                            <h5 class="mb-0">-</h5>
                          </div>
                          <span class="text-muted">Voucher</span>
                        </li>
                      </ul>
                    </BCardBody>
                  </BCard>
                  <BCard no-body>
                    <BCardBody class="py-2">
                      <ul class="list-group list-group-flush">
                        <li class="list-group-item px-0">
                          <div class="float-end">
                            <h5 class="mb-0">
                              {{ formatCurrency(cartTotalSelected) }} VND
                            </h5>
                          </div>
                          <h5 class="mb-0 d-inline-block">Tổng</h5>
                        </li>
                      </ul>
                    </BCardBody>
                  </BCard>
                  <div class="d-grid mb-3">
                    <button class="btn btn-primary" @click="createBill">
                      Đi đến thanh toán
                    </button>
                  </div>
                </BCol>
              </BRow>
            </BTab>
          </BTabs>
        </BCardBody>
        <!-- </BCard> -->
      </BCol>
    </BRow>
    <BModal
      v-model="showDeleteModal"
      title="Xác nhận xóa"
      @ok="deleteCartItem"
      @cancel="showDeleteModal = false"
    >
      <p>Bạn có chắc chắn muốn xóa sản phẩm này khỏi giỏ hàng không?</p>
    </BModal>
  </Layout>
</template>
