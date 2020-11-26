<template>
<body>
  <div>
    <el-container>
    <el-header>Header</el-header>
    <el-main>Main</el-main>
  </el-container>
    <el-button @click="visible = true">Button</el-button>
    <el-dialog :visible.sync="visible" title="Hello world">
      <p>{{msg}}</p>
    </el-dialog>
  </div>
</body>
</template>

<script>
export default {
  title: 'HelloWorld',
  props: {
    msg: String
  },
  data: function() {
    return { visible: false }
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
h3 {
  margin: 40px 0 0;
}
ul {
  list-style-type: none;
  padding: 0;
}
li {
  display: inline-block;
  margin: 0 10px;
}
a {
  color: #42b983;
}
</style>
