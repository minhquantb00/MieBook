<script setup>
import Layout from "@/layout/main-admin.vue";
import pageheader from "@/components/page-header.vue";
import { AuthApi } from "@/apis/authApi";
import { ref, onMounted } from "vue";

const dataUsers = ref([]);
const businessExecute = ref({
  keyWord: "",
});
const getAllUsers = async () => {
  const result = await AuthApi.getAllUsers(businessExecute.value);
  dataUsers.value = result.data.dataResponseUser;
};
onMounted(async () => {
  await getAllUsers();
});
</script>

<template>
  <Layout>
    <pageheader title="User List" pageTitle="Users" />
    <BRow>
      <div class="col-sm-12">
        <div class="card table-card user-profile-list">
          <div class="card-body">
            <div class="table-responsive">
              <table class="table table-hover" id="pc-dt-simple">
                <thead>
                  <tr>
                    <th>STT</th>
                    <th>Họ và tên</th>
                    <th>Email</th>
                    <th>Số điện thoại</th>
                    <th>Giới tính</th>
                    <th>Point</th>
                    <th>Trạng thái</th>
                  </tr>
                </thead>
                <tbody v-for="(item, index) in dataUsers" :key="item.id">
                  <tr>
                    <td>{{ index + 1 }}</td>
                    <td>
                      <div class="d-inline-block align-middle">
                        <img
                          src="@/assets/images/user/avatar-1.jpg"
                          alt="user image"
                          class="img-radius align-top m-r-15"
                          style="width: 40px"
                        />
                        <div class="d-inline-block">
                          <h6 class="m-b-0">{{ item.fullName }}</h6>
                          <p class="m-b-0 text-primary">{{ item.nickName }}</p>
                        </div>
                      </div>
                    </td>
                    <td>{{ item.email }}</td>
                    <td>{{ item.phoneNumber }}</td>
                    <td>{{ item.gender }}</td>
                    <td>{{ item.point }}</td>
                    <td>
                      <span class="badge bg-light-success">Active</span>
                      <!-- <div class="overlay-edit">
                        <ul class="list-inline mb-0">
                          <li class="list-inline-item m-0">
                            <a href="#" class="avtar avtar-s btn btn-primary"
                              ><i class="ti ti-pencil f-18"></i
                            ></a>
                          </li>
                          <li class="list-inline-item m-0">
                            <a href="#" class="avtar avtar-s btn bg-white btn-link-danger"
                              ><i class="ti ti-trash f-18"></i
                            ></a>
                          </li>
                        </ul>
                      </div> -->
                    </td>
                  </tr>
                </tbody>
              </table>
            </div>
          </div>
        </div>
      </div>
    </BRow>
  </Layout>
</template>
