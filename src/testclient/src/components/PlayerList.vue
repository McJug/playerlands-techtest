<template>
  <div class="player-list">
    <Card
      v-for="player in players"
      v-bind:key="player.username"
    >
      <h4>
        Username:
      </h4>
      <span>{{ player.username }}</span>
      <h4>
        Member Since:
      </h4>
      <span>{{ player.joined | formatDate('D MMM YYYY') }}</span>
      <h4>
        Email:
      </h4>
      <span>{{ player.email }}</span>
    </Card>

    <a
      class="load-more-players-link"
      :class="{ 'disabled': !areMorePlayerPages }"
      @click="loadMorePlayers"
    >
      Load More Players
    </a>
  </div>
</template>

<script>
import vuex from 'vuex';
import Card from '@/components/Card.vue';

const { mapGetters } = vuex.createNamespacedHelpers('player');

export default {
  name: 'PlayerList',
  components: {
    Card,
  },
  computed: mapGetters([
    'players',
    'areMorePlayerPages',
  ]),
  mounted() {
    if (this.players.length === 0) {
      this.loadMorePlayers();
    }
  },
  methods: {
    loadMorePlayers() {
      if (this.players.length === 0 || this.areMorePlayerPages) {
        this.$store.dispatch('player/getNextPlayerPage');
      }
    },
  },
};
</script>

<style lang="scss">
.player-list {
  margin: 0 auto;
  width: 100%;
  max-width: 76.8rem;
  display: flex;
  flex-wrap: wrap;

  & > * {
    flex: 1 1 100%;
  }

  @media (min-width: 76.8rem) {
    & > * {
      flex: 1 1 20%;
    }
  }

  h4 {
    margin: 0;
    padding: 0;

    &:not(:first-of-type) {
      margin-top: 2rem;
    }
  }

  span {
    font-size: 1.5rem;
    font-weight: 300;
  }

  .load-more-players-link {
    text-decoration: underline;
    font-weight: bold;
    cursor: pointer;

    &:hover {
      color: var(--accent-color);
    }

    &.disabled {
      color: lightgray;
      cursor: not-allowed;
    }
  }
}
</style>
