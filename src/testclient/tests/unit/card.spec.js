import { expect } from 'chai';
import { shallowMount } from '@vue/test-utils';
import Card from '@/components/Card.vue';

describe('Card.vue', () => {
  it('renders slot components', () => {
    const msg = 'Testing Slot';
    const wrapper = shallowMount(Card, {
      propsData: { msg },
      slots: {
        default: msg,
      },
    });
    expect(wrapper.text()).to.include(msg);
  });
});
