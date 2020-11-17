<template>
<div>
    <input class="new-todo" type="text" :placeholder="placedText" 
    @keyup.enter="addTodo" :value="value" @input="$emit('input',$event.target.value)">
</div>
</template>

<script>
    export default {
        props: {
            placedText: {
                default: ""
            },
            value: {
                default: ""
            }
        },
        methods: {
            addTodo(e) {
                this.$emit('keyup.enter.native',e)
            }
        },
    }
</script>