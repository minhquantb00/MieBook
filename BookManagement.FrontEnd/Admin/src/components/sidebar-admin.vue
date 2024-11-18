<script>
import { ref, onMounted, watch } from "vue";
import simplebar from "simplebar-vue";
import LogoDark from "@/assets/images/logo-dark.svg";
import LogoWhite from "@/assets/images/logo-white.svg";
export default {
  setup() {
    const logo = ref(null);
    let isDarkTheme = document.body.getAttribute("data-pc-layout") === "dark";

    const updateLogo = () => {
      if (isDarkTheme) {
        logo.value.src = require("@/assets/images/logo-white.svg");
      } else {
        logo.value.src = require("@/assets/images/logo-dark.svg");
      }
    };

    onMounted(() => {
      updateLogo();
    });

    watch(
      () => isDarkTheme,
      () => {
        updateLogo();
      }
    );

    return { logo };
  },
  components: {
    simplebar,
  },
  data() {
    return {
      LogoDark,
      LogoWhite,
    };
  },
  methods: {
    changeLayoutType(layoutType) {
      // Update the layout type in the store
      this.$store.commit("changeLayoutType", { layoutType });

      // Set the layout attribute based on the layout type
      document.body.setAttribute("data-pc-layout", layoutType);
    },
  },
  computed: {
    // ...layoutComputed,
    layoutType: {
      get() {
        return this.$store.state.layout.layoutType;
      },
      set(layoutType) {
        this.$store.commit("changeLayoutType", { layoutType });
      },
    },
  },
  watch: {
    layoutType: {
      immediate: true,
      deep: true,
      handler(newVal, oldVal) {
        if (newVal !== oldVal) {
          switch (newVal) {
            case "horizontal":
              document.body.setAttribute("data-pc-layout", "horizontal");
              break;
            case "vertical":
              document.body.setAttribute("data-pc-layout", "vertical");
          }
        }
      },
    },
  },
  mounted() {
    this.isDarkTheme = document.body.getAttribute("data-pc-layout") === "dark";
    const activeListItem = document.querySelector("li.active");
    if (activeListItem) {
      const parentElementOrSelf = activeListItem?.parentElement
        ? activeListItem.parentElement
        : activeListItem;
      if (parentElementOrSelf && !parentElementOrSelf.classList.contains("pc-navbar")) {
        const closestItem = parentElementOrSelf.parentElement.closest(".pc-item");
        if (closestItem) {
          closestItem.classList.add("active");
        }
      }
    } else {
      console.error("No list item with class 'active' found.");
    }
  },
};
</script>

<template>
  <div class="navbar-wrapper" id="navbar-wrapper">
    <div class="m-header">
      <router-link to="/" class="b-brand text-primary">
        <!-- ========   Change your logo from here   ============ -->
        <img ref="logo" alt="logo image" class="logo-lg custom_logo" />
        <!-- <img :src="isDarkTheme ? '@/assets/images/logo-dark.svg' : '@/assets/images/logo-white.svg'" alt="logo image" class="logo-lg custom_logo"> -->
        <!-- <img src="@/assets/images/logo-dark.svg" alt="" class="logo logo-lg">
                <img src="@/assets/images/logo-white.svg" alt="" class="logo logo-lg"> -->
        <img src="@/assets/images/favicon.svg" alt="" class="logo logo-sm" />
        <span class="badge bg-brand-color-2 rounded-pill ms-2 theme-version">v1.0</span>
      </router-link>
    </div>
    <simplebar data-simplebar style="height: 760px">
      <div class="navbar-content">
        <ul class="pc-navbar">
          <li class="pc-item" :class="{ active: this.$route.path === '/product-list' }">
            <router-link to="/product-list" class="pc-link">
              <span class="pc-micon">
                <i class="ph-duotone ph-projector-screen-chart"></i>
              </span>
              <span class="pc-mtext"> Quản lý sách</span>
            </router-link>
          </li>
          <li class="pc-item" :class="{ active: this.$route.path === '/category-list' }">
            <router-link to="/category-list" class="pc-link">
              <span class="pc-micon">
                <i class="ph-duotone ph-identification-card"></i>
              </span>
              <span class="pc-mtext"> Quản lý danh mục</span>
            </router-link>
          </li>
          <li class="pc-item" :class="{ active: this.$route.path === '/chart' }">
            <router-link to="/chart" class="pc-link">
              <span class="pc-micon"> <i class="ph-duotone ph-flower"></i> </span
              ><span class="pc-mtext">Thống kê</span></router-link
            >
          </li>
          <li class="pc-item" :class="{ active: this.$route.path === '/user-card' }">
            <router-link to="/user-card" class="pc-link">
              <span class="pc-micon">
                <i class="ph-duotone ph-database"></i>
              </span>
              <span class="pc-mtext"> Quản lý voucher</span>
            </router-link>
          </li>
          <li class="pc-item" :class="{ active: this.$route.path === '/invoice-list' }">
            <router-link to="/invoice-list" class="pc-link">
              <span class="pc-micon">
                <i class="ph-duotone ph-chart-pie"></i>
              </span>
              <span class="pc-mtext"> Quản lý sự kiện</span>
            </router-link>
          </li>

          <li class="pc-item" :class="{ active: this.$route.path === '/preview' }">
            <router-link to="/preview" class="pc-link">
              <span class="pc-micon">
                <i class="ph-duotone ph-compass-tool"></i>
              </span>
              <span class="pc-mtext"> Quản lý payment</span>
            </router-link>
          </li>
          <li class="pc-item" :class="{ active: this.$route.path === '/user-list' }">
            <router-link to="/user-list" class="pc-link">
              <span class="pc-micon"> <i class="ph-duotone ph-flower"></i> </span
              ><span class="pc-mtext">Quản lý người dùng</span></router-link
            >
          </li>
        </ul>
      </div>
    </simplebar>
  </div>
  <BCard no-body class="pc-user-card">
    <BCardBody>
      <div class="d-flex align-items-center">
        <div class="flex-shrink-0">
          <img
            src="@/assets/images/user/avatar-1.jpg"
            alt="user-image"
            class="user-avtar wid-45 rounded-circle"
          />
        </div>
        <div class="flex-grow-1 ms-3 me-2">
          <h6 class="mb-0">Jonh Smith</h6>
          <small>Administrator</small>
        </div>
        <BDropdown variant="purple" dropup no-caret>
          <template v-slot:button-content>
            <span
              class="btn btn-icon btn-link-secondary avtar arrow-none dropdown-toggle"
            >
              <i class="ph-duotone ph-windows-logo"></i>
            </span>
          </template>
          <BRow xl="6">
            <BCol xl="6">
              <BDropdownItem class="pc-user-links p-0">
                <div class="align-middle">
                  <i class="ph-duotone ph-user"></i>
                  <br />
                  <span>My Account</span>
                </div>
              </BDropdownItem>
              <BDropdownDivider />
              <BDropdownItem class="pc-user-links p-0">
                <i class="ph-duotone ph-lock-key"></i> <br />
                <span>Lock Screen</span>
              </BDropdownItem>
              <BDropdownDivider />
            </BCol>
            <BCol xl="6">
              <BDropdownItem class="pc-user-links p-0">
                <i class="ph-duotone ph-gear"></i> <br />
                <span>Settings</span>
              </BDropdownItem>
              <BDropdownDivider />
              <BDropdownItem class="pc-user-links p-0">
                <i class="ph-duotone ph-power"></i> <br />
                <span>Logout</span>
              </BDropdownItem>
              <BDropdownDivider />
            </BCol>
          </BRow>
        </BDropdown>
      </div>
    </BCardBody>
  </BCard>
</template>

<style>
.pc-sidebar .card.pc-user-card {
  z-index: 1;
}
</style>
