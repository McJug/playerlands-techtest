<template>
  <div class="players">
    <h1>Players</h1>
    <PlayerList />
  </div>
</template>

<script>
import PlayerList from '@/components/PlayerList.vue';

export default {
  name: 'Players',
  components: {
    PlayerList,
  },
};
</script>

<style lang="scss">
.players {
  // TODO:
}
</style>
