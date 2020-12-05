<template>
  <div>
    <h2>电影</h2>
    <p>电影名:{{$route.query.name}}</p>
    <p>上映日期:{{$route.query.date}}</p>
  </div>
</template>

<script>
export default {
  name:"Profile"
}
</script>

<style>

</style>