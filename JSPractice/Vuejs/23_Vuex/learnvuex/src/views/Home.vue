<template>
  <div class="home">
    <hello/>
  </div>
</template>

<script>
// @ is an alias to /src
import Hello from '@/components/Hello.vue';

export default {
  name: 'Home',
  components: {
    Hello
  }
}
</script>
