<template>
  <div class="navbar">
    <ul>
      <li
        v-for="link in links"
        v-bind:key="link.to"
      >
        <router-link
          :to="link.to"
          :exact="link.exact ? true : undefined"
        >
          <span>{{ link.label }}</span>
        </router-link>
      </li>
    </ul>
  </div>
</template>

<script>
import NavBarLink from '@/types/navBarLink';

export default {
  name: 'NavBar',
  props: {
    links: {
      type: Array,
      required: true,
      validator: value => value ? value.every(link => link instanceof NavBarLink) : false,
    },
  },
};
</script>

<style lang="scss">
.navbar {
  padding: 3rem;

  ul {
    padding: 0;
    margin: 0;

    li {
      display: inline-block;

      &:not(:first-child):before {
        content: "|";
        padding: 0 0.8rem;
      }

      a {
        font-weight: bold;
        color: var(--text-color);
        &.router-link-exact-active {
          color: var(--accent-color);
        }
      }
    }
  }
}
</style>
