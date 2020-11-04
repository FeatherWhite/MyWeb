## 1. Vue绑定了哪些内容
1. DOM文本  
2. Attribute
  - Class与Style  
    - 1.v-bind:class
    - 2.v-bind:style
    - 3.v-bind:key
  - 条件渲染
    - 1.v-if v-else v-else-if
3. DOM结构  
  - 1.列表渲染  
## 2. 对于需要计算才能得到的值Vue是怎样处理的  
1. 使用函数
2. 使用计算属性即执行一次函数将结果缓存如果函数变量未发生变化直接使用缓存的值,函数变量改变才重新计算(自定义getter,setter方法)
3. 使用回调函数每次函数变量修改都会进行回调
## 3. 事件处理
## 4. 表单输入绑定

##  Vue可以组件化
`即允许我们使用小型、独立和通常可复用的组件构建大型应用`
 - note:
   - data 必须是一个函数
 - 组件名命规则
   - kebab-case：短横线分隔命名如'my-component-name'
   - PascalCase：首字母大写命名如'MyComponentName'
 - 组件声明
   - 全局注册或局部注册 `(局部注册的组件在其子组件中不可用)`
   - 通过new Vue创建实例
## 当一个Vue实例被创建时，它将data对象中的所有的property加入到Vue的响应式系统中(数据)
## 生命周期钩子 这使得用户在不同阶段都有添加自己的代码的机会。