<template>
<div>
  <section class="todoapp">
    <header class="header">
      <h2>Todos</h2>
      <v-input :placedText = 'placedText' v-model="title"
      @keyup.enter.native='addTodo'></v-input>
    </header>
    <section class="main">
      <ul class="todo-list">
        <v-todolist 
        :key="i" v-for="(todo,i) in todos" :content="todo.content"
        @updateContent="updateContent" @editing="editing(todo)"
        @delete="deleteTodo(todo)" v-model="todo.isDone">
        </v-todolist>
      </ul>
      <v-bottombar :remaining="remaining" :things="todos.length" @remove="removeDone"></v-bottombar>
    </section>
  </section>
</div>
</template>

<script>
import vInput from './components/input.vue';
import vTodolist from './components/todolist.vue';
import vBottombar from './components/bottombar.vue';
export default {
    components:{
        vInput,
        vTodolist,
        vBottombar
    },
    data() {
      return {
        placedText: "接下来要做",
        title:"",
        todos: [], // 所有的备忘
        modifiedContent: "", // 修改后的备忘内容
        // 初始化的时候，获取下本地的缓存
        todos: JSON.parse(localStorage.getItem("todos") || "[]") // 所有的备忘
      }
    },
      watch: {
    // 侦听 todos 的变化
    todos(newVal) {
      // 每次更新写入缓存
      localStorage.setItem("todos", JSON.stringify(newVal));
    }
  },
    computed: {
    // 代办事项个数
      remaining() {
      // 过滤掉已完成的，获取数量
      return this.todos.filter(x => !x.isDone).length;
    }
  },
    methods: {
      addTodo(e) {
        //console.log("按了一下回车");
        if (!this.title) {
          return;
        }
        this.todos.unshift({
          isDone:false,
          content:this.title
        });
        this.title=""
      },
      updateContent(modifiedContent) {
        console.log("修改值");
        this.modifiedContent = modifiedContent;       
      },
      editing(todo) {
        console.log("更新值");
        todo.content = this.modifiedContent;
        console.log(todo.content);
      },
      deleteTodo(todo) {
        const index = this.todos.indexOf(todo);
        if (index > -1) {
          this.todos.splice(index,1);
        }
      },
      removeDone() {
        // 删除已完成的备忘
        this.todos = this.todos.filter(x => !x.isDone);
      }
    }
}
</script>
