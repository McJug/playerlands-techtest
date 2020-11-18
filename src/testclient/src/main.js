import Vue from 'vue';
import App from './App.vue';
import router from './router';
import store from './store';
import formatDate from './filters/formatDate';

Vue.config.productionTip = false;

Vue.filter('formatDate', formatDate);

new Vue({
  router,
  store,
  render: h => h(App),
}).$mount('#app');
