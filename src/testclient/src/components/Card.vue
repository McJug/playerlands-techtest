<template>
  <div class="card">
    <slot />
  </div>
</template>

<style lang="scss">
.card {
  box-shadow: 0 0.1rem 0.5rem rgba(0,0,0,0.2),
    0 0.2rem 0.2rem rgba(0,0,0,0.14),
    0 0.3rem 0.1rem -0.2rem;
  border-radius: 0.4rem;
  background: white;
  padding: 2rem;
  margin: 2rem;
}
</style>
