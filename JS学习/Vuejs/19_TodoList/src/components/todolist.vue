<template> 
  <!-- 鼠标移动到li上之后删除键显示移出去删除键消失 -->
  <li class="todo" :class="{completed:isDone,editing:isEdit}">
    
    <div class="view">
      <!-- 点击checkbox表示完成任务 -->
      <input class="toggle" type="checkbox" :checked="isDone" @change="updateChecked">
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
      @keyup.enter="(isEdit = false)" @blur="editDone">
  </li>
</template>

<script>
export default {
    model: {
    prop: 'isDone',
    event: 'change'
  },
  props: {
    content: {
      default: ""
    },
  },
  data() {
    return {
      isDone: false,
      isEdit: false,
      isShow: false,
      modifiedContent:""
    }
  },
  mounted () {
    console.log("初始化中间变量");
    this.modifiedContent = this.content;
  },
  methods: {
    updateChecked(event) {
      this.isDone = event.target.checked;
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
    deleteTodo(params) {
      this.$emit("delete")
    }
  }
}
</script>
<style>
@import "https://unpkg.com/todomvc-app-css@2.1.0/index.css";
</style>
