<script>
import Layout from "@/layout/main.vue";
import pageheader from "@/components/page-header.vue";

export default {
  name: "CONTACT-US",
  components: {
    Layout,
    pageheader,
  },
};
</script>

<template>
  <Layout>
    <pageheader title="Contact-Us" pageTitle="Ui kit" />
    <BRow>
      <BCol class="col-sm-12">
        <div class="card">
          <div class="card-body">
            <iframe
              src="https://maps.app.goo.gl/jFvFGkbs8BUC7pwXA"
              allowfullscreen=""
              loading="lazy"
              referrerpolicy="no-referrer-when-downgrade"
              class="contact-map"
            ></iframe>
            <BRow class="row justify-content-center">
              <BCol class="col-11 col-sm-9 col-xl-8">
                <div class="card contact-card-form user-card">
                  <div class="card-body">
                    <div class="d-flex mb-4">
                      <div class="flex-grow-1 me-3">
                        <div class="d-flex align-items-center">
                          <div class="avtar bg-brand-color-1 text-white me-3">
                            <i class="ph-duotone ph-chats-teardrop f-26"></i>
                          </div>
                          <div>
                            <h4 class="f-w-500 mb-1">Liên hệ với chúng tôi</h4>
                            <p class="mb-0">Hãy cho phản hồi về phần đề của bạn</p>
                          </div>
                        </div>
                      </div>
                    </div>
                    <BRow class="row">
                      <BCol class="col-md-6">
                        <div class="form-group mb-3">
                          <label class="form-label">Họ và tên</label>
                          <input
                            type="text"
                            class="form-control"
                            placeholder="Nhập họ và tên"
                          />
                        </div>
                      </BCol>
                      <BCol class="col-md-6">
                        <div class="form-group mb-3">
                          <label class="form-label">Chủ đề</label>
                          <input
                            type="text"
                            class="form-control"
                            placeholder="Nhập chủ đề"
                          />
                        </div>
                      </BCol>
                      <BCol class="col-md-6">
                        <div class="form-group mb-3">
                          <label class="form-label">Địa chỉ email</label>
                          <input
                            type="email"
                            class="form-control"
                            placeholder="Địa chỉ email"
                          />
                        </div>
                      </BCol>
                      <BCol class="col-md-6">
                        <div class="form-group mb-3">
                          <label class="form-label">Số điện thoại liên hệ</label>
                          <input
                            type="text"
                            class="form-control"
                            placeholder="Nhập số điện thoại liên hệ"
                          />
                        </div>
                      </BCol>
                      <BCol class="col-12">
                        <div class="form-group mb-3">
                          <label class="form-label">Nội dung phản hồi</label>
                          <textarea
                            class="form-control"
                            rows="3"
                            placeholder="Nhập nội dung"
                          ></textarea>
                        </div>
                      </BCol>
                    </BRow>
                    <div class="d-grid mt-4">
                      <button type="button" class="btn btn-primary mx-sm-3 mx-md-5">
                        Gửi phản hồi
                      </button>
                    </div>
                    <div class="saprator my-3">
                      <span>hoặc</span>
                    </div>

                    <div class="text-center">
                      <ul class="list-inline mx-auto mt-3 mb-0">
                        <li class="list-inline-item">
                          <a
                            href="https://www.facebook.com/"
                            class="avtar avtar-s rounded-circle bg-facebook"
                            target="_blank"
                          >
                            <i class="fab fa-facebook-f text-white"></i>
                          </a>
                        </li>
                        <li class="list-inline-item">
                          <a
                            href="https://twitter.com/"
                            class="avtar avtar-s rounded-circle bg-twitter"
                            target="_blank"
                          >
                            <i class="fab fa-twitter text-white"></i>
                          </a>
                        </li>
                        <li class="list-inline-item">
                          <a
                            href="https://myaccount.google.com/"
                            class="avtar avtar-s rounded-circle bg-googleplus"
                            target="_blank"
                          >
                            <i class="fab fa-google text-white"></i>
                          </a>
                        </li>
                      </ul>
                    </div>
                  </div>
                </div>
              </BCol>
            </BRow>
          </div>
        </div>
      </BCol>
    </BRow>
  </Layout>
</template>
