<template>
  <div id="app">
    <chara ref="chara" :x="100" :y="0" :scaleX="0.3" :scaleY="0.3"></chara>
  </div>
</template>

<script>
import Chara from './components/Chara.vue'
export default {
  name: 'app',
  components: {
    Chara
  },
  mounted: function () {
    this.play()
  },
  methods: {
    async play () {
      const chara = this.$refs.chara
      await chara.jump(100, 1500)
      await chara.jump(200, 1500)
      await chara.jump(150, 1000)
    }
  }
}
</script>

<style lang="scss">
html, body {
  margin: 0;
  padding: 0;
}
body {
  position: relative;
  height: 100%;
}
#app {
  margin: 0;
}
</style>
