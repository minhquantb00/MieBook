<script>
import { layoutComputed } from "@/state/helper.js";

import VERTICALADMIN from "./vertical-admin";
// import Horizontal from "./horizontal.vue"
export default {
  name: "MAINADMIN",
  components: {
    VERTICALADMIN,
  },
  data() {
    return {};
  },
  computed: {
    ...layoutComputed,
  },
  mounted() {
    // document.body.setAttribute("data-pc-direction", "rtl");
  },
};
</script>

<template>
  <VERTICALADMIN v-if="layoutType === 'vertical'" :layout="layoutType">
    <slot />
  </VERTICALADMIN>
</template>
