<script setup>
import simplebar from "simplebar-vue";
import { computed, onMounted, ref } from "vue";
import { useStore } from "vuex";
import { AuthApi } from "@/apis/authApi";
import { useRouter } from "vue-router";

const store = useStore();
const currentMode = ref("light");
const dataUser = ref({});
const router = useRouter();
const userInfo = JSON.parse(localStorage.getItem("userInfo"));
const listRole = ref([]);
const getUserById = async () => {
  const result = userInfo !== null ? await AuthApi.getUserById(userInfo.Id) : {};
  dataUser.value =
    result.data !== null && result.data !== undefined ? result.data.dataResponseUser : {};
};

const logOut = () => {
  localStorage.removeItem("accessToken");
  localStorage.removeItem("refreshToken");
  localStorage.removeItem("userInfo");
  router.push("/login-v1");
};

const toggleSidebar = () => {
  store.commit("toggleSidebar");
};

const toggleMobileSidebar = () => {
  store.commit("toggleMobileSidebar");
};

const changeMode = (mode) => {
  currentMode.value = mode;
  document.body.setAttribute("data-pc-theme", mode === "dark" ? "dark" : "light");
  document.body.classList.toggle("mode-auto", mode === "auto");
};

const isTokenExpired = computed(() => {
  if (!userInfo || !userInfo.ExpiredTime) {
    return true; // Token không tồn tại hoặc không có ExpiredTime thì xem như đã hết hạn
  }

  const expiredTime = new Date(userInfo.ExpiredTime);
  const currentTime = new Date();

  return currentTime > expiredTime;
});

onMounted(() => {
  if (userInfo) {
    listRole.value = userInfo.Permission;
    console.log(userInfo.ExpiredTime);
  }
  if (isTokenExpired.value) {
    localStorage.removeItem("accessToken");
    localStorage.removeItem("refreshToken");
    localStorage.removeItem("userInfo");
  }
  console.log(isTokenExpired.value);
  getUserById();
});
</script>

<template>
  <div class="header-wrapper">
    <div class="me-auto pc-mob-drp">
      <ul class="list-unstyled">
        <li class="pc-h-item pc-sidebar-collapse">
          <a href="#" class="pc-head-link ms-0" id="sidebar-hide" @click="toggleSidebar">
            <i class="ti ti-menu-2"></i>
          </a>
        </li>
        <li class="pc-h-item pc-sidebar-popup">
          <a
            href="#"
            class="pc-head-link ms-0"
            id="mobile-collapse"
            @click="toggleMobileSidebar"
          >
            <i class="ti ti-menu-2"></i>
          </a>
        </li>
        <li class="dropdown pc-h-item d-inline-flex d-md-none">
          <a
            class="pc-head-link dropdown-toggle arrow-none m-0"
            data-bs-toggle="dropdown"
            href="#"
            role="button"
            aria-haspopup="false"
            aria-expanded="false"
          >
            <i class="ph-duotone ph-magnifying-glass"></i>
          </a>
          <div class="dropdown-menu pc-h-dropdown drp-search">
            <form class="px-3">
              <div class="form-group mb-0 d-flex align-items-center">
                <input
                  type="search"
                  class="form-control border-0 shadow-none"
                  placeholder="Search here. . ."
                />
                <button class="btn btn-light-secondary btn-search">
                  <kbd>ctrl+k</kbd>
                </button>
              </div>
            </form>
          </div>
        </li>
        <li class="pc-h-item d-none d-md-inline-flex">
          <form class="form-search">
            <i class="ph-duotone ph-magnifying-glass icon-search"></i>
            <input type="search" class="form-control" placeholder="Search. . ." />
            <button class="btn btn-light-secondary btn-search" style="padding: 0">
              <kbd>ctrl+k</kbd>
            </button>
          </form>
        </li>
      </ul>
    </div>
    <div class="ms-auto">
      <ul class="list-unstyled">
        <BDropdown
          variant="link-secondary"
          class="card-header-dropdown pb-0 pt-2"
          toggle-class="text-reset dropdown-btn arrow-none"
          menu-class="dropdown-menu-end"
          aria-haspopup="true"
          :offset="{ alignmentAxis: -150, crossAxis: 0, mainAxis: 20 }"
        >
          <template #button-content
            ><span class="text-muted"
              ><i
                :class="
                  currentMode === 'dark'
                    ? 'ph-duotone ph-moon'
                    : currentMode === 'light'
                    ? 'ph-duotone ph-sun-dim'
                    : 'ph-duotone ph-cpu'
                "
              ></i
            ></span>
          </template>
          <a href="#!" class="dropdown-item" @click="changeMode('dark')">
            <i class="ph-duotone ph-moon"></i>
            <span>Dark</span>
          </a>
          <a href="#!" class="dropdown-item" @click="changeMode('light')">
            <i class="ph-duotone ph-sun-dim"></i>
            <span>Light</span>
          </a>
          <a href="#!" class="dropdown-item" @click="changeMode('auto')">
            <i class="ph-duotone ph-cpu"></i>
            <span>Default</span>
          </a>
        </BDropdown>

        <BDropdown
          variant="link-secondary"
          auto-close="outside"
          class="card-header-dropdown pb-0 pt-2"
          toggle-class="text-reset dropdown-btn arrow-none"
          menu-class="dropdown-menu-end"
          aria-haspopup="true"
          :offset="{ alignmentAxis: -140, crossAxis: 0, mainAxis: 20 }"
        >
          <template #button-content
            ><span class="text-muted"><i class="ph-duotone ph-diamonds-four"></i></span>
          </template>
          <a href="#!" class="dropdown-item">
            <i class="ph-duotone ph-user"></i>
            <span>Tài khoản</span>
          </a>
          <RouterLink
            href="#!"
            class="dropdown-item"
            v-if="listRole && listRole.includes('User')"
            :to="{ path: '/home' }"
          >
            <i class="ph-duotone ph-user"></i>
            <span>Trang người dùng</span>
          </RouterLink>
          <a href="#!" class="dropdown-item">
            <i class="ph-duotone ph-power"></i>
            <span>Đăng xuất</span>
          </a>
        </BDropdown>
        <BDropdown
          v-model="show"
          variant="link-secondary"
          auto-close="outside"
          class="card-header-dropdown pb-0 pt-3"
          toggle-class="text-reset dropdown-btn arrow-none me-0"
          menu-class="dropdown-menu-end dropdown-notification pc-h-dropdown"
          aria-haspopup="true"
          :offset="{ alignmentAxis: -145, crossAxis: 0, mainAxis: 20 }"
        >
          <template #button-content
            ><span class="text-muted"
              ><i class="ph-duotone ph-bell"></i>
              <span
                class="position-absolute topbar-badge translate-middle badge rounded-pill bg-success"
                ><span class="notification-badge">4</span
                ><span class="visually-hidden">unread messages </span>
              </span>
            </span>
          </template>
          <BDropdownHeader class="align-items-center justify-content-between">
            <BRow class="align-items-center justify-content-between">
              <BCol xl="8" sm="6">
                <h5 class="m-0">Thông báo</h5>
              </BCol>
              <BCol xl="4" sm="6">
                <ul class="list-inline ms-auto mb-0">
                  <li class="list-inline-item">
                    <router-link to="/mail" class="avtar avtar-s btn-link-hover-primary">
                      <i class="ti ti-link f-18"></i>
                    </router-link>
                  </li>
                </ul>
              </BCol>
            </BRow>
          </BDropdownHeader>
          <simplebar data-simplebar style="max-height: 500px">
            <div
              class="dropdown-body text-wrap header-notification-scroll position-relative"
              style="max-height: calc(100vh - 235px)"
            >
              <ul class="list-group list-group-flush">
                <li class="list-group-item">
                  <p class="text-span">Today</p>
                  <div class="d-flex">
                    <div class="flex-shrink-0">
                      <img
                        src="@/assets/images/user/avatar-2.jpg"
                        alt="user-image"
                        class="user-avtar avtar avtar-s"
                      />
                    </div>
                    <div class="flex-grow-1 ms-3">
                      <div class="d-flex">
                        <div class="flex-grow-1 me-3 position-relative">
                          <h6 class="mb-0 text-truncate">
                            Keefe Bond added new tags to 💪 Design system
                          </h6>
                        </div>
                        <div class="flex-shrink-0">
                          <span class="text-sm">2 min ago</span>
                        </div>
                      </div>
                      <p class="position-relative mt-1 mb-2">
                        <br /><span class="text-truncate"
                          >Lorem Ipsum has been the industry's standard dummy text ever
                          since the 1500s.</span
                        >
                      </p>
                      <span class="badge bg-light-primary border border-primary me-1 mt-1"
                        >web design</span
                      >
                      <span class="badge bg-light-warning border border-warning me-1 mt-1"
                        >Dashobard</span
                      >
                      <span class="badge bg-light-success border border-success me-1 mt-1"
                        >Design System</span
                      >
                    </div>
                  </div>
                </li>
                <li class="list-group-item">
                  <div class="d-flex">
                    <div class="flex-shrink-0">
                      <div class="avtar avtar-s bg-light-primary">
                        <i class="ph-duotone ph-chats-teardrop f-18"></i>
                      </div>
                    </div>
                    <div class="flex-grow-1 ms-3">
                      <div class="d-flex">
                        <div class="flex-grow-1 me-3 position-relative">
                          <h6 class="mb-0 text-truncate">Message</h6>
                        </div>
                        <div class="flex-shrink-0">
                          <span class="text-sm text-muted">1 hour ago</span>
                        </div>
                      </div>
                      <p class="position-relative text-muted mt-1 mb-2">
                        <br /><span class="text-truncate"
                          >Lorem Ipsum has been the industry's standard dummy text ever
                          since the 1500s.</span
                        >
                      </p>
                    </div>
                  </div>
                </li>
                <li class="list-group-item">
                  <p class="text-span">Yesterday</p>
                  <div class="d-flex">
                    <div class="flex-shrink-0">
                      <div class="avtar avtar-s bg-light-danger">
                        <i class="ph-duotone ph-user f-18"></i>
                      </div>
                    </div>
                    <div class="flex-grow-1 ms-3">
                      <div class="d-flex">
                        <div class="flex-grow-1 me-3 position-relative">
                          <h5 class="mb-0 text-truncate">Challenge invitation</h5>
                        </div>
                        <div class="flex-shrink-0">
                          <span class="text-sm text-muted">12 hour ago</span>
                        </div>
                      </div>
                      <p class="position-relative text-muted mt-1 mb-2">
                        <br /><span class="text-truncate"
                          ><strong> Jonny aber </strong> invites to join the
                          challenge</span
                        >
                      </p>
                      <button class="btn btn-sm rounded-pill btn-outline-secondary me-2">
                        Decline
                      </button>
                      <button class="btn btn-sm rounded-pill btn-primary">Accept</button>
                    </div>
                  </div>
                </li>
                <li class="list-group-item">
                  <div class="d-flex">
                    <div class="flex-shrink-0">
                      <div class="avtar avtar-s bg-light-info">
                        <i class="ph-duotone ph-notebook f-18"></i>
                      </div>
                    </div>
                    <div class="flex-grow-1 ms-3">
                      <div class="d-flex">
                        <div class="flex-grow-1 me-3 position-relative">
                          <h5 class="mb-0 text-truncate">Forms</h5>
                        </div>
                        <div class="flex-shrink-0">
                          <span class="text-sm text-muted">2 hour ago</span>
                        </div>
                      </div>
                      <p class="position-relative text-muted mt-1 mb-2">
                        Lorem Ipsum is simply dummy text of the printing and typesetting
                        industry. Lorem Ipsum has been the industry's standard dummy text
                        ever since the 1500s.
                      </p>
                    </div>
                  </div>
                </li>
                <li class="list-group-item">
                  <div class="d-flex">
                    <div class="flex-shrink-0">
                      <img
                        src="@/assets/images/user/avatar-2.jpg"
                        alt="user-image"
                        class="user-avtar avtar avtar-s"
                      />
                    </div>
                    <div class="flex-grow-1 ms-3">
                      <div class="d-flex">
                        <div class="flex-grow-1 me-3 position-relative">
                          <h5 class="mb-0 text-truncate">
                            Keefe Bond
                            <span class="text-body"> added new tags to </span> 💪 Design
                            system
                          </h5>
                        </div>
                        <div class="flex-shrink-0">
                          <span class="text-sm text-muted">2 min ago</span>
                        </div>
                      </div>
                      <p class="position-relative text-muted mt-1 mb-2">
                        <br /><span class="text-truncate"
                          >Lorem Ipsum has been the industry's standard dummy text ever
                          since the 1500s.</span
                        >
                      </p>
                      <button class="btn btn-sm rounded-pill btn-outline-secondary me-2">
                        Decline
                      </button>
                      <button class="btn btn-sm rounded-pill btn-primary">Accept</button>
                    </div>
                  </div>
                </li>
                <li class="list-group-item">
                  <div class="d-flex">
                    <div class="flex-shrink-0">
                      <div class="avtar avtar-s bg-light-success">
                        <i class="ph-duotone ph-shield-checkered f-18"></i>
                      </div>
                    </div>
                    <div class="flex-grow-1 ms-3">
                      <div class="d-flex">
                        <div class="flex-grow-1 me-3 position-relative">
                          <h5 class="mb-0 text-truncate">Security</h5>
                        </div>
                        <div class="flex-shrink-0">
                          <span class="text-sm text-muted">5 hour ago</span>
                        </div>
                      </div>
                      <p class="position-relative text-muted mt-1 mb-2">
                        Lorem Ipsum is simply dummy text of the printing and typesetting
                        industry. Lorem Ipsum has been the industry's standard dummy text
                        ever since the 1500s.
                      </p>
                    </div>
                  </div>
                </li>
              </ul>
            </div>
          </simplebar>
          <div class="dropdown-footer">
            <BRow class="g-3">
              <BCol Cols="6">
                <div class="d-grid">
                  <button class="btn btn-primary">Archive all</button>
                </div>
              </BCol>
              <BCol Cols="6">
                <div class="d-grid">
                  <button class="btn btn-outline-secondary">Mark all as read</button>
                </div>
              </BCol>
            </BRow>
          </div>
        </BDropdown>
        <div v-if="userInfo === null">
          <BLink
            href="#"
            class="btn btn-primary"
            target="_blank"
            style="margin-top: 10px"
            :to="{ path: '/login-v1' }"
            >Đăng nhập</BLink
          >
        </div>
        <BDropdown
          v-else
          variant="link-secondary"
          auto-close="outside"
          class="card-header-dropdown py-0"
          toggle-class="text-reset dropdown-btn arrow-none me-0"
          menu-class="dropdown-menu-end dropdown-user-profile dropdown-menu-end pc-h-dropdown"
          aria-haspopup="true"
          :offset="{ alignmentAxis: -145, crossAxis: 0, mainAxis: 20 }"
        >
          <template #button-content
            ><span class="text-muted">
              <img
                src="@/assets/images/user/avatar-2.jpg"
                alt="user-image"
                class="user-avtar"
              />
            </span>
          </template>
          <div class="dropdown-header d-flex align-items-center justify-content-between">
            <h4 class="m-0">Hồ sơ</h4>
          </div>
          <div class="dropdown-body">
            <simplebar data-simplebar style="max-height: 500px">
              <div
                class="profile-notification-scroll position-relative"
                style="max-height: calc(100vh - 225px)"
              >
                <ul class="list-group list-group-flush w-100">
                  <li class="list-group-item">
                    <div class="d-flex align-items-center">
                      <div class="flex-shrink-0">
                        <img
                          src="@/assets/images/user/avatar-2.jpg"
                          alt="user-image"
                          class="wid-50 rounded-circle"
                        />
                      </div>
                      <div class="flex-grow-1 mx-3">
                        <h5 class="mb-0">{{ dataUser.fullName }}</h5>
                        <a class="link-primary" href="mailto:carson.darrin@company.io">{{
                          dataUser.email
                        }}</a>
                      </div>
                    </div>
                  </li>
                  <li class="list-group-item">
                    <RouterLink
                      href="#"
                      class="dropdown-item"
                      v-if="listRole && listRole.includes('User')"
                      :to="{ path: '/home' }"
                    >
                      <span class="d-flex align-items-center">
                        <i class="ph-duotone ph-heart"></i>
                        <span>Trang người dùng</span>
                      </span>
                    </RouterLink>
                  </li>
                  <li class="list-group-item">
                    <RouterLink
                      href="#"
                      class="dropdown-item"
                      :to="{ path: '/account-profile' }"
                    >
                      <span class="d-flex align-items-center">
                        <i class="ph-duotone ph-user-circle"></i>
                        <span>Chỉnh sửa hồ sơ</span>
                      </span>
                    </RouterLink>
                    <a href="#" class="dropdown-item">
                      <span class="d-flex align-items-center">
                        <i class="ph-duotone ph-bell"></i>
                        <span>Thông báo</span>
                      </span>
                    </a>
                    <a href="#" class="dropdown-item">
                      <span class="d-flex align-items-center">
                        <i class="ph-duotone ph-gear-six"></i>
                        <span>Cài đặt</span>
                      </span>
                    </a>
                  </li>
                  <li class="list-group-item">
                    <button href="#" class="dropdown-item" @click="logOut">
                      <span class="d-flex align-items-center">
                        <i class="ph-duotone ph-power"></i>
                        <span>Đăng xuất</span>
                      </span>
                    </button>
                  </li>
                </ul>
              </div>
            </simplebar>
          </div>
        </BDropdown>
      </ul>
    </div>
  </div>
</template>
