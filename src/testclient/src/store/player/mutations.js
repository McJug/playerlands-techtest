export default {
  savePlayerPageData(state, payload) {
    state.nextPlayerPage += 1;
    state.totalPlayers = payload.totalPlayers;
    state.playerPageSize = payload.pageSize;
    state.players.push(...payload.players);
  },
};
