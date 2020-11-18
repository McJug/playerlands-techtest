import { expect } from 'chai';
import { shallowMount, RouterLinkStub } from '@vue/test-utils';
import NavBar from '@/components/NavBar.vue';
import NavBarLink from '@/types/navBarLink';

describe('NavBar.vue', () => {
  it('renders links', () => {
    const links = [
      new NavBarLink('/', 'Home'),
      new NavBarLink('/about', 'About'),
      new NavBarLink('/players', 'Players'),
    ];
    const wrapper = shallowMount(NavBar, {
      propsData: {
        links,
      },
      stubs: {
        RouterLink: RouterLinkStub,
      },
    });
    expect(wrapper.text()).to.include('Home');
    expect(wrapper.text()).to.include('About');
    expect(wrapper.text()).to.include('Players');
  });
  it('validation fails when no links are provided', () => {
    const { validator } = NavBar.props.links;
    expect(validator()).to.equal(false);
  });
  it('validation fails when array items are not NavBarLinks', () => {
    const { validator } = NavBar.props.links;
    expect(validator([{}])).to.equal(false);
  });
});
