import axios from 'axios';

const api = axios.create({
  baseURL: 'https://192.168.1.9:45455/api/Stores',
  //baseURL: 'https://localhost:7051/api/Stores',
  //baseURL: 'https://10.0.2.2:7051/api/Stores',
  timeout: 10000,
});

api.interceptors.response.use(
  (res) => {
    //console.log(res);
    return res;
  }, 
  
  (error) => {
    if (error.response) {
      throw new Error(error.response.data?.message || 'Error en la respuesta del servidor');
    }
    if (error.request) {
      throw new Error('No se recibió respuesta del servidor');
    }
    throw new Error('Error en la solicitud');
  }
);

export default api;