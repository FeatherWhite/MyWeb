<template> 
  <!-- 鼠标移动到li上之后删除键显示移出去删除键消失 -->
  <li :class="{completed:checked,editing:isEdit}">
    
    <div class="view">
      <!-- 点击checkbox表示完成任务 -->
      <input class="toggle" type="checkbox" :checked="checked" @change="updateChecked">
      <!-- 双击label隐藏label显示input修改任务 -->
      <label
      @dblclick="editTodo">{{content}}</label>
      <!-- 删除任务 -->
      <button class="destroy" @click="deleteTodo"></button>
    </div>
      <!-- keyup也会触发一次blur就由blur统一处理 -->
      <!-- 当把v-model改为:value按完enter键先触发一次keyup后触 -->
      <!-- 发一次blur,keyup的target.value是input中的值也就是修 -->
      <!-- 改后的值blur中的target.value是input中的初始值 -->
      <input class="edit" type="text" v-model="modifiedContent"
      v-autofocus
       v-if="isEdit"
      @keyup.enter="(isEdit = false)" @blur="editDone">
  </li>
</template>

<script>
export default {
    model: {
    prop: 'checked',
    event: 'change'
  },
  props: {
    content: {
      type: String,
      default: ""
    },
    checked: {
      type: Boolean,
      default: false
    }
  },
  data() {
    return {
      isEdit: false,
      modifiedContent:""
    }
  },
  mounted () {
    console.log("初始化中间变量");
    this.modifiedContent = this.content;
  },
  methods: {
    updateChecked(event) {
      // this.checked = event.target.checked;
      this.$emit('change',event.target.checked);
    },
    editTodo() {
      //隐藏label显示text input进行修改
      console.log("双击label");
      console.log("将label值赋给中间变量");
      this.modifiedContent = this.content;
      this.isEdit = true;
    },
    editDone(event) {
      //把修改后的值传给父组件的中间变量
      this.$emit('updateContent',event.target.value)
      //把中间变量的值传给父组件的todo.content
      this.$emit('editing');
      this.isEdit = false;
    },
    deleteTodo() {
      this.$emit("delete")
    }
  },
    // 其他选项省略
  directives: {
    autofocus: {
      // 被绑定元素插入父节点时调用 (仅保证父节点存在，但不一定已被插入文档中)
      inserted: function(el) {
        // el: 指令所绑定的元素，可以用来直接操作 DOM
        el.focus();
      }
    }
  }
}
</script>
<style>
@import "https://unpkg.com/todomvc-app-css@2.1.0/index.css";
</style>
