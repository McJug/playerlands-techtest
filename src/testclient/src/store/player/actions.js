import axios from 'axios';

export default {
  async getNextPlayerPage(ctx) {
    const response = await axios.get(`${process.env.VUE_APP_BASE_URL}/api/players?page=${ctx.state.nextPlayerPage}`);

    if (response.status === 200) {
      ctx.commit('savePlayerPageData', response.data);
    }
  },
};
