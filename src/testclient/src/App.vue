<template>
  <div id="app">
    <NavBar
      :links="navBarLinks"
    />
    <router-view/>
  </div>
</template>

<script>
import NavBar from '@/components/NavBar.vue';
import NavBarLink from '@/types/navBarLink';

export default {
  name: 'App',
  components: {
    NavBar,
  },
  data: () => ({
    navBarLinks: [
      new NavBarLink('/', 'Home'),
      new NavBarLink('/about', 'About'),
      new NavBarLink('/players', 'Players'),
    ],
  }),
};
</script>

<style lang="scss">
html { font-size: 62.5%; }
body { font-size: 1.6rem; }

:root {
  --text-color: #2c3e50;
  --accent-color: #42b983;
}

#app {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: var(--text-color);
}
</style>
