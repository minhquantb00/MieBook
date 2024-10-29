<script setup>
import Layout from "@/layout/main.vue";
import pageheader from "@/components/page-header.vue";
import { onMounted, ref } from "vue";
import { BookApi } from "@/apis/bookApi";
import { useRouter } from "vue-router";
import { filterProductRequest } from "@/interfaces/requestModels/book/filterProductRequest";

const userInfo = JSON.parse(localStorage.getItem("userInfo"));
const router = useRouter();
const backItem = () => {
  if (userInfo) {
    // setTimeout(() => {
    //   localStorage.removeItem("accessToken");
    //   localStorage.removeItem("refreshToken");
    //   localStorage.removeItem("userInfo");
    //   location.reload();
    // }, 10800000);
  }
};
const dataProducts = ref([]);
const businessExecute = ref(filterProductRequest);
const getAllBooks = async () => {
  const result = await BookApi.getAllBooks(businessExecute.value);
  dataProducts.value = result.data.dataResponseBooks;
};
const viewBook = (id) => {
  console.log("id" + id);
  router.push({
    name: "product-details",
    params: { id },
  });
};
onMounted(async () => {
  await getAllBooks();
  backItem();
});
</script>

<template>
  <Layout>
    <pageheader title="Home" page-title="UI" />
    <div class="d-flex mb-4">
      <div>
        <img
          width="100%"
          src="https://cdn0.fahasa.com/media/magentothem/banner7/TrangCTthang10_Mainbanner_15_10_APP_840x320.png"
          alt="img"
          class="img-fluid img-bg"
        />
      </div>
      <div>
        <img
          width="100%"
          src="https://cdn0.fahasa.com/media/magentothem/banner7/TrangCTthang10_Mainbanner_15_10_APP_840x320.png"
          alt="img"
          class="img-fluid img-bg"
        />
      </div>
      <div>
        <img
          width="100%"
          src="https://cdn0.fahasa.com/media/magentothem/banner7/TrangCTthang10_Mainbanner_15_10_APP_840x320.png"
          alt="img"
          class="img-fluid img-bg"
        />
      </div>
    </div>
    <BRow>
      <div class="col-md-12 col-xxl-4">
        <div class="card statistics-card-1">
          <div class="card-body">
            <img
              src="@/assets/images/widget/img-status-2.svg"
              alt="img"
              class="img-fluid img-bg"
            />
            <div class="d-flex align-items-center">
              <div class="avtar bg-brand-color-1 text-white me-3">
                <i class="ph-duotone ph-currency-dollar f-26"></i>
              </div>
              <div>
                <p class="text-muted mb-0">Tổng doanh thu/ tháng</p>
                <div class="d-flex align-items-end">
                  <h2 class="mb-0 f-w-500">
                    <span class="text-muted">$</span> 134.6
                    <small class="text-muted">k</small>
                  </h2>
                  <span class="badge bg-light-success ms-2"
                    ><i class="ti ti-chevrons-up"></i> 55%</span
                  >
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
      <div class="col-md-6 col-xxl-4">
        <div class="card statistics-card-1">
          <div class="card-body">
            <img
              src="@/assets/images/widget/img-status-1.svg"
              alt="img"
              class="img-fluid img-bg"
            />
            <div class="d-flex align-items-center">
              <div class="avtar bg-brand-color-2 text-white me-3">
                <i class="ph-duotone ph-scales f-26"></i>
              </div>
              <div>
                <p class="text-muted mb-0">Số lượng hoàn trả</p>
                <div class="d-flex align-items-end">
                  <h2 class="mb-0 f-w-500">8.57<small class="text-muted">%</small></h2>
                  <span class="badge bg-light-danger ms-2"
                    ><i class="ti ti-chevrons-down"></i> 3.6%</span
                  >
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
      <div class="col-md-6 col-xxl-4">
        <div class="card statistics-card-1">
          <div class="card-body">
            <img
              src="@/assets/images/widget/img-status-3.svg"
              alt="img"
              class="img-fluid img-bg"
            />
            <div class="d-flex align-items-center">
              <div class="avtar bg-brand-color-3 text-white me-3">
                <i class="ph-duotone ph-users-four f-26"></i>
              </div>
              <div>
                <p class="text-muted mb-0">Số khách đã mua</p>
                <div class="d-flex align-items-end">
                  <h2 class="mb-0 f-w-500">278</h2>
                  <span class="badge bg-light-success ms-2"
                    ><i class="ti ti-chevrons-up"></i> 7%</span
                  >
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </BRow>
    <BRow>
      <div class="col-sm-12">
        <div class="ecom-wrapper">
          <div
            class="offcanvas-xxl offcanvas-start ecom-offcanvas"
            tabindex="-1"
            id="offcanvas_mail_filter"
          >
            <div class="offcanvas-body p-0 sticky-xxl-top">
              <div id="ecom-filter" class="show collapse collapse-horizontal">
                <BCollapse id="collapse-3" visible>
                  <div class="ecom-filter">
                    <div class="card">
                      <div
                        class="card-header d-flex align-items-center justify-content-between"
                      >
                        <h5>Filter</h5>
                        <a
                          href="#"
                          class="avtar avtar-s btn-link-danger btn-pc-default"
                          data-bs-dismiss="offcanvas"
                          data-bs-target="#offcanvas_mail_filter"
                        >
                          <i class="ti ti-x f-20"></i>
                        </a>
                      </div>
                      <div class="scroll-block">
                        <simplebar data-simplebar style="height: 620px">
                          <div class="card-body">
                            <ul class="list-group list-group-flush">
                              <li class="list-group-item border-0 px-0 py-2">
                                <a
                                  v-b-toggle.filtercollapse1
                                  variant="primary"
                                  class="border-0 px-0 text-start w-100 pb-0"
                                >
                                  <div class="float-end">
                                    <i class="ti ti-chevron-down"></i>
                                  </div>
                                  Chủ đề
                                </a>
                                <BCollapse visible id="filtercollapse1">
                                  <div>
                                    <div class="form-check my-2">
                                      <input
                                        class="form-check-input"
                                        type="checkbox"
                                        id="genderfilter1"
                                        value="option1"
                                      />
                                      <label class="form-check-label" for="genderfilter1"
                                        >Kinh doanh</label
                                      >
                                    </div>
                                    <div class="form-check my-2">
                                      <input
                                        class="form-check-input"
                                        type="checkbox"
                                        id="genderfilter2"
                                        value="option2"
                                      />
                                      <label class="form-check-label" for="genderfilter2"
                                        >Self help</label
                                      >
                                    </div>
                                    <div class="form-check my-2">
                                      <input
                                        class="form-check-input"
                                        type="checkbox"
                                        id="genderfilter3"
                                        value="option3"
                                      />
                                      <label class="form-check-label" for="genderfilter3"
                                        >Giải trí</label
                                      >
                                    </div>
                                  </div>
                                </BCollapse>
                              </li>
                              <li class="list-group-item border-0 px-0 py-2">
                                <a
                                  v-b-toggle.filtercollapse2
                                  variant="primary"
                                  class="border-0 px-0 text-start w-100 pb-0"
                                >
                                  <div class="float-end">
                                    <i class="ti ti-chevron-down"></i>
                                  </div>
                                  Danh mục
                                </a>
                                <BCollapse visible id="filtercollapse2">
                                  <div>
                                    <div class="form-check my-2">
                                      <input
                                        class="form-check-input"
                                        type="checkbox"
                                        id="categoryfilter1"
                                        value="option1"
                                      />
                                      <label
                                        class="form-check-label"
                                        for="categoryfilter1"
                                        >All</label
                                      >
                                    </div>
                                    <div class="form-check my-2">
                                      <input
                                        class="form-check-input"
                                        type="checkbox"
                                        id="categoryfilter2"
                                        value="option2"
                                      />
                                      <label
                                        class="form-check-label"
                                        for="categoryfilter2"
                                        >Văn học</label
                                      >
                                    </div>
                                    <div class="form-check my-2">
                                      <input
                                        class="form-check-input"
                                        type="checkbox"
                                        id="categoryfilter3"
                                        value="option3"
                                      />
                                      <label
                                        class="form-check-label"
                                        for="categoryfilter3"
                                        >Khoa học viễn tưởng</label
                                      >
                                    </div>
                                    <div class="form-check my-2">
                                      <input
                                        class="form-check-input"
                                        type="checkbox"
                                        id="categoryfilter4"
                                        value="option1"
                                      />
                                      <label
                                        class="form-check-label"
                                        for="categoryfilter4"
                                        >Kinh doanh</label
                                      >
                                    </div>
                                    <div class="form-check my-2">
                                      <input
                                        class="form-check-input"
                                        type="checkbox"
                                        id="categoryfilter5"
                                        value="option2"
                                      />
                                      <label
                                        class="form-check-label"
                                        for="categoryfilter5"
                                        >Du lịch</label
                                      >
                                    </div>
                                    <div class="form-check my-2">
                                      <input
                                        class="form-check-input"
                                        type="checkbox"
                                        id="categoryfilter6"
                                        value="option3"
                                      />
                                      <label
                                        class="form-check-label"
                                        for="categoryfilter6"
                                        >Ẩm thực</label
                                      >
                                    </div>
                                  </div>
                                </BCollapse>
                              </li>

                              <li class="list-group-item border-0 px-0 py-2">
                                <a
                                  v-b-toggle.filtercollapse4
                                  variant="primary"
                                  class="border-0 px-0 text-start w-100 pb-0"
                                >
                                  <div class="float-end">
                                    <i class="ti ti-chevron-down"></i>
                                  </div>
                                  Khoảng giá
                                </a>
                                <BCollapse visible id="filtercollapse4">
                                  <BRow>
                                    <BCol class="col-6">
                                      <div class="form-check my-2">
                                        <input
                                          class="form-check-input"
                                          type="radio"
                                          name="price"
                                          id="pricefilter1"
                                          value="option1"
                                        />
                                        <label class="form-check-label" for="pricefilter1"
                                          >Below $10</label
                                        >
                                      </div>
                                      <div class="form-check my-2">
                                        <input
                                          class="form-check-input"
                                          type="radio"
                                          name="price"
                                          id="pricefilter2"
                                          value="option2"
                                        />
                                        <label class="form-check-label" for="pricefilter2"
                                          >$50 - $100</label
                                        >
                                      </div>
                                      <div class="form-check my-2">
                                        <input
                                          class="form-check-input"
                                          type="radio"
                                          name="price"
                                          id="pricefilter3"
                                          value="option3"
                                        />
                                        <label class="form-check-label" for="pricefilter3"
                                          >$150 - $200</label
                                        >
                                      </div>
                                    </BCol>
                                    <BCol class="col-6">
                                      <div class="form-check my-2">
                                        <input
                                          class="form-check-input"
                                          type="radio"
                                          name="price"
                                          id="pricefilter4"
                                          value="option1"
                                        />
                                        <label class="form-check-label" for="pricefilter4"
                                          >$10 - $50</label
                                        >
                                      </div>
                                      <div class="form-check my-2">
                                        <input
                                          class="form-check-input"
                                          type="radio"
                                          name="price"
                                          id="pricefilter5"
                                          value="option2"
                                        />
                                        <label class="form-check-label" for="pricefilter5"
                                          >$100 - $150</label
                                        >
                                      </div>
                                      <div class="form-check my-2">
                                        <input
                                          class="form-check-input"
                                          type="radio"
                                          name="price"
                                          id="pricefilter6"
                                          value="option3"
                                        />
                                        <label class="form-check-label" for="pricefilter6"
                                          >Over $200</label
                                        >
                                      </div>
                                    </BCol>
                                  </BRow>
                                </BCollapse>
                              </li>
                            </ul>
                          </div>
                        </simplebar>
                      </div>
                    </div>
                  </div>
                </BCollapse>
              </div>
            </div>
          </div>
          <div class="ecom-content" style="width: 100%">
            <div class="d-sm-flex align-items-center mb-4">
              <ul class="list-inline me-auto my-1">
                <li class="list-inline-item">
                  <form class="form-search">
                    <i class="ph-duotone ph-magnifying-glass icon-search"></i>
                    <input type="search" class="form-control" placeholder="Tìm kiếm" />
                  </form>
                </li>
              </ul>
              <ul class="list-inline ms-auto my-1">
                <li class="list-inline-item align-bottom">
                  <BButton variant="link-secondary" v-b-toggle.collapse-3 class="m-1">
                    <i class="ti ti-filter f-16"></i>Filter</BButton
                  >
                </li>
              </ul>
            </div>
            <BRow>
              <BCol v-for="item in dataProducts" :key="item.id" class="col-sm-6 col-xl-4">
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
                        <b>{{ item.price }} VND</b>
                        <span
                          class="text-sm text-muted f-w-400 text-decoration-line-through"
                        >
                          {{ item.priceAfterDiscount }} VND
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
                          <button class="btn btn-link-secondary btn-prod-card">
                            Thêm vào giỏ
                          </button>
                        </div>
                      </div>
                    </div>
                  </BCardBody>
                </BCard>
              </BCol>
            </BRow>
          </div>
        </div>
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
