
export default {
  players: state => state.players,

  areMorePlayerPages: state => state.totalPlayers > state.players.length,
};
