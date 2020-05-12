<template>
  <img class="tama-root" src="/img/superman.svg" alt="キャラ"
    :style="{
      transform: `translate(${x + dx}px, ${y + dy}px) scale(${scaleX * dScaleX}, ${scaleY * dScaleY}) rotate(${rotate + dRotate}deg)`,
      transition: `transform ${duration}ms ${easing}`
    }"
    @click="jump(200)"
  >
</template>

<style lang="scss" scoped>
.tama-root {
  position: absolute;
  left: 0;
  top: -100;
  margin: -300px auto auto -90px;
  transform-origin: 90px 100%;
  will-change: transform;
}
</style>

<script>
import Time from '@/core/Time'
export default {
  name: 'chara',
  props: {
    x: { type: Number, default: 50 },
    y: { type: Number, default: -100 },
    scaleX: { type: Number, default: 1.0 },
    scaleY: { type: Number, default: 1.0 },
    rotate: { type: Number, default: 0 }
  },
  data () {
    return {
      dx: 0,
      dy: 0,
      dScaleX: 1.0,
      dScaleY: 1.0,
      dRotate: 0,
      duration: 1000,
      easing: 'ease'
    }
  },
  methods: {
    async tween (props = {}, duration = 1000) {
      Object.assign(this.$data, props)
      this.$data.duration = duration
      await Time.wait(duration)
    },
    async jump (height = 200, duration = 2500) {
      await this.tween({ dScaleY: 0.9, easing: 'ease' }, duration * 0.1)
      await this.tween({ dy: -height, dScaleY: 1.1, easing: 'ease-out' }, duration * 0.35)
      await this.tween({ dy: 0, dScale: 1.4, easing: 'ease-in' }, duration * 0.35)
      await this.tween({ dScaleY: 0.7, easing: 'ease' }, duration * 0.1)
      await this.tween({ dScaleY: 1.0, easing: 'ease' }, duration * 0.1)
    }
  }
}
</script>
