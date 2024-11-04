<script setup>
import Layout from "@/layout/main.vue";
import pageheader from "@/components/page-header.vue";
import { Swiper, SwiperSlide } from "swiper/vue";
import { Autoplay, A11y } from "swiper/modules";
import { HeartIcon } from "@zhuowenli/vue-feather-icons";
import { BookApi } from "@/apis/bookApi";
import { useRoute } from "vue-router";
import { onMounted, ref } from "vue";

const modules = [Autoplay, A11y];
const router = useRoute();
const idBook = router.params.id;
const book = ref({});
const getBookById = async () => {
  const result = await BookApi.getBookById(idBook);
  book.value = result.data.dataResponseBook;
};

onMounted(async () => {
  console.log(router);
  await getBookById();
});
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
                          <img src="" class="d-block w-100" alt="Product images" />
                        </swiper-slide>
                        <swiper-slide class="carousel-item">
                          <img
                            :src="book.imageUrl"
                            class="d-block w-100"
                            alt="Product images"
                          />
                        </swiper-slide>
                        <swiper-slide class="carousel-item">
                          <img
                            :src="book.imageUrl"
                            class="d-block w-100"
                            alt="Product images"
                          />
                        </swiper-slide>
                        <swiper-slide class="carousel-item">
                          <img
                            :src="book.imageUrl"
                            class="d-block w-100"
                            alt="Product images"
                          />
                        </swiper-slide>
                        <swiper-slide class="carousel-item">
                          <img
                            :src="book.imageUrl"
                            class="d-block w-100"
                            alt="Product images"
                          />
                        </swiper-slide>
                        <swiper-slide class="carousel-item">
                          <img
                            :src="book.imageUrl"
                            class="d-block w-100"
                            alt="Product images"
                          />
                        </swiper-slide>
                        <swiper-slide class="carousel-item">
                          <img
                            :src="book.imageUrl"
                            class="d-block w-100"
                            alt="Product images"
                          />
                        </swiper-slide>
                        <swiper-slide class="carousel-item">
                          <img
                            :src="book.imageUrl"
                            class="d-block w-100"
                            alt="Product images"
                          />
                        </swiper-slide>
                      </div>
                    </swiper>
                    <ol
                      class="list-inline carousel-indicators position-relative product-carousel-indicators my-sm-3 mx-0"
                    >
                      <li
                        data-bs-target="#carouselExampleCaptions"
                        data-bs-slide-to="0"
                        class="list-inline-item w-25 h-auto active"
                      >
                        <img
                          :src="book.imageUrl"
                          class="d-block wid-50 rounded"
                          alt="Product images"
                        />
                      </li>
                      <li
                        data-bs-target="#carouselExampleCaptions"
                        data-bs-slide-to="1"
                        class="list-inline-item w-25 h-auto"
                      >
                        <img
                          :src="book.imageUrl"
                          class="d-block wid-50 rounded"
                          alt="Product images"
                        />
                      </li>
                      <li
                        data-bs-target="#carouselExampleCaptions"
                        data-bs-slide-to="2"
                        class="list-inline-item w-25 h-auto"
                      >
                        <img
                          :src="book.imageUrl"
                          class="d-block wid-50 rounded"
                          alt="Product images"
                        />
                      </li>
                      <li
                        data-bs-target="#carouselExampleCaptions"
                        data-bs-slide-to="3"
                        class="list-inline-item w-25 h-auto"
                      >
                        <img
                          :src="book.imageUrl"
                          class="d-block wid-50 rounded"
                          alt="Product images"
                        />
                      </li>
                      <li
                        data-bs-target="#carouselExampleCaptions"
                        data-bs-slide-to="4"
                        class="list-inline-item w-25 h-auto"
                      >
                        <img
                          :src="book.imageUrl"
                          class="d-block wid-50 rounded"
                          alt="Product images"
                        />
                      </li>
                      <li
                        data-bs-target="#carouselExampleCaptions"
                        data-bs-slide-to="5"
                        class="list-inline-item w-25 h-auto"
                      >
                        <img
                          :src="book.imageUrl"
                          class="d-block wid-50 rounded"
                          alt="Product images"
                        />
                      </li>
                      <li
                        data-bs-target="#carouselExampleCaptions"
                        data-bs-slide-to="6"
                        class="list-inline-item w-25 h-auto"
                      >
                        <img
                          :src="book.imageUrl"
                          class="d-block wid-50 rounded"
                          alt="Product images"
                        />
                      </li>
                      <li
                        data-bs-target="#carouselExampleCaptions"
                        data-bs-slide-to="7"
                        class="list-inline-item w-25 h-auto"
                      >
                        <img
                          :src="book.imageUrl"
                          class="d-block wid-50 rounded"
                          alt="Product images"
                        />
                      </li>
                    </ol>
                  </div>
                </div>
              </BCol>
              <BCol md="6">
                <span class="badge bg-success f-14">{{ book.status }}</span>
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
                    <span class="text-danger">*: {{ book.quantity }}</span></BCol
                  >
                  <BCol class="col-lg-6 col-md-12 col-sm-12">
                    <div class="btn-group btn-group-sm mb-2 border" role="group">
                      <button
                        type="button"
                        id="decrease"
                        onclick="decreaseValue('number')"
                        class="btn btn-link-secondary"
                      >
                        <i class="ti ti-minus"></i>
                      </button>
                      <input
                        class="wid-35 text-center border-0 m-0 form-control rounded-0 shadow-none"
                        type="text"
                        id="number"
                        value="0"
                      />
                      <button
                        type="button"
                        id="increase"
                        onclick="increaseValue('number')"
                        class="btn btn-link-secondary"
                      >
                        <i class="ti ti-plus"></i>
                      </button>
                    </div>
                  </BCol>
                </BRow>
                <h3 class="mb-4">
                  <b>{{ book.price }} VND</b
                  ><span class="mx-2 f-16 text-muted f-w-400 text-decoration-line-through"
                    >{{ book.priceAfterDiscount }} VND</span
                  >
                </h3>
                <BRow>
                  <BCol Cols="6">
                    <div class="d-grid">
                      <button type="button" class="btn btn-primary">Mua ngay</button>
                    </div>
                  </BCol>
                  <BCol Cols="6">
                    <div class="d-grid">
                      <button type="button" class="btn btn-outline-secondary">
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
                        <td class="text-muted py-1">
                          Số trang : {{ book.numberOfPages }}
                        </td>
                        <td class="py-1"></td>
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
                    Lorem Ipsum is simply dummy text of the printing and typesetting
                    industry. Lorem Ipsum has been the industry's standard dummy text ever
                    since the 1500s,
                    <strong class="text-body"
                      >“When an unknown printer took a galley of type and scrambled it to
                      make a type specimen book.”</strong
                    >
                    It has survived not only five centuries, but also the leap into
                    electronic typesetting, remaining essentially unchanged. It was
                    popularized in the 1960s with the release of Lestrade sheets
                    containing Lorem Ipsum passages, and more recently with desktop
                    publishing software like PageMaker including versions of Lorem Ipsum.
                  </p>
                  <p class="text-muted mb-0">
                    It was popularized in the 1960s with the release of Learjet sheets
                    containing Lorem Ipsum passages, and more recently with desktop
                    publishing software like PageMaker including versions of Lorem Ipsum.
                  </p>
                </div>
              </BTab>
              <BTab>
                <template #title>
                  <div>
                    Reviews
                    <span class="badge bg-light-primary rounded-pill px-2 ms-2">275</span>
                  </div>
                </template>
                <div class="card">
                  <div class="card-body">
                    <BRow class="justify-content-between align-items-center">
                      <BCol class="col-xxl-4 col-xl-5">
                        <h2 class="mb-3">
                          <b>3.5<small class="text-muted f-18">/5</small></b>
                        </h2>
                        <p class="mb-2 text-muted">275 lượt reviews</p>
                        <div class="star mb-3 f-20">
                          <i class="fas fa-star text-warning"></i>
                          <i class="fas fa-star text-warning"></i>
                          <i class="fas fa-star text-warning"></i>
                          <i class="fas fa-star-half-alt text-warning"></i>
                          <i class="far fa-star text-muted"></i>
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
                                    style="width: 30%"
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
                                    style="width: 60%"
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
                                    style="width: 75%"
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
                                    style="width: 40%"
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
                                    style="width: 55%"
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
                        <h6 class="mb-1">Minh Quân</h6>
                        <p class="text-muted text-sm mb-1">2 hour ago</p>
                        <div class="star">
                          <i class="fas fa-star text-warning"></i>
                          <i class="fas fa-star text-warning"></i>
                          <i class="fas fa-star text-warning"></i>
                          <i class="fas fa-star-half-alt text-warning"></i>
                          <i class="far fa-star text-muted"></i>
                        </div>
                        <p class="mb-0 text-muted mt-1">
                          Lorem Ipsum is simply dummy text of the printing and typesetting
                          industry. Lorem Ipsum has been the industry's standard dummy
                          text ever since the 1500.
                        </p>
                      </div>
                    </div>
                  </BCardBody>
                </BCard>
                <BCard no-body>
                  <BCardBody>
                    <div class="media align-items-start">
                      <div class="chat-avtar">
                        <img
                          class="img-radius img-fluid wid-40"
                          src="@/assets/images/user/avatar-2.jpg"
                          alt="User image"
                        />
                        <div class="bg-success chat-badge"></div>
                      </div>
                      <div class="media-body ms-3">
                        <h6 class="mb-1">Phương Đông</h6>
                        <p class="text-muted text-sm mb-1">2 hour ago</p>
                        <div class="star">
                          <i class="fas fa-star text-warning"></i>
                          <i class="fas fa-star text-warning"></i>
                          <i class="fas fa-star-half-alt text-warning"></i>
                          <i class="far fa-star text-muted"></i>
                          <i class="far fa-star text-muted"></i>
                        </div>
                        <p class="mb-2 text-muted mt-1">
                          Lorem Ipsum is simply dummy text of the printing and typesetting
                          industry. Lorem Ipsum has been the industry's standard dummy
                          text ever since the 1500.
                        </p>
                        <a href="#" class="link-primary mb-1"
                          >https://phoenixcoded.net/</a
                        >
                      </div>
                    </div>
                  </BCardBody>
                </BCard>
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
            <BRow class="gy-3">
              <BCol xl="4" class="col-sm-6 col-xxl-3 col-xl-4">
                <BCard no-body class="product-card mb-0">
                  <div class="card-img-top">
                    <router-link to="/product-details">
                      <img
                        src="https://th.bing.com/th/id/OIP.2eZsIlbHCRqQwdT-mlOkAQHaE7?w=270&h=180&c=7&r=0&o=5&dpr=1.3&pid=1.7"
                        alt="image"
                        class="img-prod img-fluid"
                      />
                    </router-link>
                    <BCardBody class="card-body position-absolute end-0 top-0">
                      <div class="form-check prod-likes">
                        <input type="checkbox" class="form-check-input" />
                        <HeartIcon class="prod-likes-icon"></HeartIcon>
                      </div>
                    </BCardBody>
                    <BCardBody class="position-absolute start-0 top-0">
                      <span class="badge bg-danger badge-prod-card">30%</span>
                    </BCardBody>
                  </div>
                  <BCardBody>
                    <router-link to="/product-details">
                      <p class="prod-content mb-0 text-muted">Apple watch -4</p>
                    </router-link>
                    <div
                      class="d-flex align-items-center justify-content-between mt-2 mb-3 flex-wrap"
                    >
                      <h4 class="mb-0 text-truncate">
                        <b>$299.00</b>
                        <span
                          class="text-sm text-muted f-w-400 text-decoration-line-through"
                          >$399.00</span
                        >
                      </h4>
                      <div class="d-inline-flex align-items-center">
                        <i class="ph-duotone ph-star text-warning me-1"></i>
                        4.5 <small class="text-muted">/ 5</small>
                      </div>
                    </div>
                    <div class="d-flex">
                      <div class="flex-shrink-0">
                        <a
                          href="#"
                          class="avtar avtar-s btn-link-secondary btn-prod-card"
                        >
                          <i class="ph-duotone ph-eye f-18"></i>
                        </a>
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
              <BCol xl="4" class="col-sm-6 col-xxl-3 col-xl-4">
                <div class="card product-card mb-0">
                  <div class="card-img-top">
                    <router-link to="/product-details">
                      <img
                        src="https://th.bing.com/th/id/OIP.2eZsIlbHCRqQwdT-mlOkAQHaE7?w=270&h=180&c=7&r=0&o=5&dpr=1.3&pid=1.7"
                        alt="image"
                        class="img-prod img-fluid"
                      />
                    </router-link>
                    <div class="card-body position-absolute end-0 top-0">
                      <div class="form-check prod-likes">
                        <input type="checkbox" class="form-check-input" />
                        <HeartIcon class="prod-likes-icon"></HeartIcon>
                      </div>
                    </div>
                  </div>
                  <BCardBody>
                    <router-link to="/product-details">
                      <p class="prod-content mb-0 text-muted">Apple watch -4</p>
                    </router-link>
                    <div
                      class="d-flex align-items-center justify-content-between mt-2 mb-3 flex-wrap"
                    >
                      <h4 class="mb-0 text-truncate">
                        <b>$299.00</b>
                        <span
                          class="text-sm text-muted f-w-400 text-decoration-line-through"
                          >$399.00</span
                        >
                      </h4>
                      <div class="d-inline-flex align-items-center">
                        <i class="ph-duotone ph-star text-warning me-1"></i>
                        4.5 <small class="text-muted">/ 5</small>
                      </div>
                    </div>
                    <div class="d-flex">
                      <div class="flex-shrink-0">
                        <a
                          href="#"
                          class="avtar avtar-s btn-link-secondary btn-prod-card"
                        >
                          <i class="ph-duotone ph-eye f-18"></i>
                        </a>
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
                </div>
              </BCol>
              <BCol xl="4" class="col-sm-6 col-xxl-3 col-xl-4">
                <BCard no-body class="product-card mb-0">
                  <div class="card-img-top">
                    <router-link to="/product-details">
                      <img
                        src="https://th.bing.com/th/id/OIP.2eZsIlbHCRqQwdT-mlOkAQHaE7?w=270&h=180&c=7&r=0&o=5&dpr=1.3&pid=1.7"
                        alt="image"
                        class="img-prod img-fluid"
                      />
                    </router-link>
                    <BCardBody class="position-absolute end-0 top-0">
                      <div class="form-check prod-likes">
                        <input type="checkbox" class="form-check-input" />
                        <HeartIcon class="prod-likes-icon"></HeartIcon>
                      </div>
                    </BCardBody>
                    <BCardBody class="position-absolute start-0 top-0">
                      <span class="badge bg-danger badge-prod-card">30%</span>
                    </BCardBody>
                  </div>
                  <BCardBody>
                    <router-link to="/product-details">
                      <p class="prod-content mb-0 text-muted">Apple watch -4</p>
                    </router-link>
                    <div
                      class="d-flex align-items-center justify-content-between mt-2 mb-3 flex-wrap"
                    >
                      <h4 class="mb-0 text-truncate">
                        <b>$299.00</b>
                        <span
                          class="text-sm text-muted f-w-400 text-decoration-line-through"
                          >$399.00</span
                        >
                      </h4>
                      <div class="d-inline-flex align-items-center">
                        <i class="ph-duotone ph-star text-warning me-1"></i>
                        4.5 <small class="text-muted">/ 5</small>
                      </div>
                    </div>
                    <div class="d-flex">
                      <div class="flex-shrink-0">
                        <a
                          href="#"
                          class="avtar avtar-s btn-link-secondary btn-prod-card"
                        >
                          <i class="ph-duotone ph-eye f-18"></i>
                        </a>
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
              <BCol xl="4" class="col-sm-6 col-xxl-3 col-xl-4">
                <BCard no-body class="product-card mb-0">
                  <div class="card-img-top">
                    <router-link to="/product-details">
                      <img
                        src="https://th.bing.com/th/id/OIP.2eZsIlbHCRqQwdT-mlOkAQHaE7?w=270&h=180&c=7&r=0&o=5&dpr=1.3&pid=1.7"
                        alt="image"
                        class="img-prod img-fluid"
                      />
                    </router-link>
                    <BCardBody class="position-absolute end-0 top-0">
                      <div class="form-check prod-likes">
                        <input type="checkbox" class="form-check-input" />
                        <HeartIcon class="prod-likes-icon"></HeartIcon>
                      </div>
                    </BCardBody>
                  </div>
                  <BCardBody>
                    <router-link to="/product-details">
                      <p class="prod-content mb-0 text-muted">Apple watch -4</p>
                    </router-link>
                    <div
                      class="d-flex align-items-center justify-content-between mt-2 mb-3 flex-wrap"
                    >
                      <h4 class="mb-0 text-truncate">
                        <b>$299.00</b>
                        <span
                          class="text-sm text-muted f-w-400 text-decoration-line-through"
                          >$399.00</span
                        >
                      </h4>
                      <div class="d-inline-flex align-items-center">
                        <i class="ph-duotone ph-star text-warning me-1"></i>
                        4.5 <small class="text-muted">/ 5</small>
                      </div>
                    </div>
                    <div class="d-flex">
                      <div class="flex-shrink-0">
                        <a
                          href="#"
                          class="avtar avtar-s btn-link-secondary btn-prod-card"
                        >
                          <i class="ph-duotone ph-eye f-18"></i>
                        </a>
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
          </BCardBody>
        </BCard>
      </div>
    </BRow>
  </Layout>
</template>
