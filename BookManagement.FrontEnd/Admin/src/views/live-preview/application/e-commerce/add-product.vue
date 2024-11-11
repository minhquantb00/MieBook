<script>
import Layout from "@/layout/main.vue";
import pageheader from "@/components/page-header.vue";

export default {
  name: "ADD-PRODUCT",
  components: {
    Layout,
    pageheader,
  },
};
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
              <input type="text" class="form-control" placeholder="Nhập tên sản phẩm" />
            </div>
            <div class="form-group">
              <label class="form-label">Chọn danh mục</label>
              <select class="form-select">
                <option>Sneakers</option>
                <option>Category 1</option>
                <option>Category 2</option>
                <option>Category 3</option>
                <option>Category 4</option>
              </select>
            </div>
            <div class="form-group">
              <label class="form-label">Chủ đề</label>
              <select class="form-select">
                <option>Nike</option>
                <option>Category 1</option>
                <option>Category 2</option>
                <option>Category 3</option>
                <option>Category 4</option>
              </select>
            </div>
            <div class="form-group mb-0">
              <label class="form-label">Mô tả sản phẩm</label>
              <textarea class="form-control" placeholder="Nhập mô tả sản phẩm"></textarea>
            </div>
            <div class="form-group">
              <label class="form-label">Số lượng</label>
              <input type="text" class="form-control" placeholder="Nhập số lượng" />
            </div>
            <div class="form-group mb-0">
              <label class="form-label">Tác giả</label>
              <textarea class="form-control" placeholder="Nhập tên tác giả"></textarea>
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
              <input type="file" id="flupld" class="d-none" />
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
                <option>12.00</option>
                <option>Category 1</option>
                <option>Category 2</option>
                <option>Category 3</option>
                <option>Category 4</option>
              </select>
            </div>
          </BCardBody>
        </BCard>
      </BCol>
      <BCol sm="12">
        <BCard no-body>
          <BCardBody class="text-end btn-page">
            <button class="btn btn-primary mb-0">Lưu thông tin</button>
            <button class="btn btn-outline-secondary mb-0">Reset</button>
          </BCardBody>
        </BCard>
      </BCol>
    </BRow>
  </Layout>
</template>
