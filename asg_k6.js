import http from 'k6/http';
import { check, sleep } from 'k6';

export const options = {
  stages: [
    { duration: '30s', target: 200 },
    { duration: '30s', target: 300 },
    { duration: '30s', target: 400 },
    { duration: '5m', target: 800 },
    { duration: '5m', target: 1200 },
    { duration: '5m', target: 1600 }
  ],
};

export default function () {
  const res = http.get('http://!!!!!!.amazonaws.com:8002');
  //sleep(1);
}