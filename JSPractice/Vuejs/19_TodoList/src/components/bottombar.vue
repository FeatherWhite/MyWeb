<template>
<div>
  <footer class="footer" v-show="things">
    <span class="todo-count"><strong style="font-weight: bold">{{remaining}}</strong> 件待办事项</span>
      <!-- 当有已完成的备忘时，一键移除已完成按钮出现 -->
  <button
    class="clear-completed"
    @click="removeDone"
    v-show="things > remaining"
  >
    清除已完成的事项
  </button>
  </footer>
</div>
</template>

<script>
export default {
  props: {
    //剩余的事
    remaining: {
      type: Number,
      default: 0
    },
    things: {
      type: Number,
      default: 0
    }
  },
  methods: {
    removeDone() {
      this.$emit("remove")
    }
  },
}
</script>