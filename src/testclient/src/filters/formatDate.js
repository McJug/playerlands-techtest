import moment from 'moment';

export default (value, format = 'DD/MM/YYYY') => {
  if (value) {
    return moment(String(value), format);
  }
  return '';
};
