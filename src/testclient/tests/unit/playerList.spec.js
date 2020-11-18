import { expect } from 'chai';
import { shallowMount, mount } from '@vue/test-utils';
import PlayerList from '@/components/PlayerList.vue';
import store from '@/store';
import formatDate from '@/filters/formatDate';
import Card from '@/components/Card.vue';

describe('PlayerList.vue', () => {
  it('load more players link is disabled when no more pages are available', () => {
    const wrapper = shallowMount(PlayerList, {
      store,
      filters: {
        formatDate,
      },
    });
    expect(wrapper.find('a').classes()).to.contain('disabled');
  });
  it('load more players link is enabled when no more pages are available', () => {
    store.state.player.totalPlayers = 100;
    const wrapper = shallowMount(PlayerList, {
      store,
      filters: {
        formatDate,
      },
    });
    expect(wrapper.find('a').classes()).to.not.contain('disabled');
  });
  it('renders correct number of players', () => {
    store.state.player.players.push({ username: 'tom', email: 'tom@fake.com', joined: '"2020-09-19T00:00:00"' });
    const wrapper = mount(PlayerList, {
      store,
      filters: {
        formatDate,
      },
    });
    expect(wrapper.findAll(Card).length).to.equal(1);
  });
});
