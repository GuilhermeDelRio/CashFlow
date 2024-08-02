import api from './axios';
// import { useToast } from 'primevue/usetoast';

// const toast = useToast();

// const showToast = (severity, summary, detail) => {
//   toast.add({ severity, summary, detail, life: 3000 });
// };

const handleError = (error: string) => {
  // showToast('error', 'Erro', error.message);
  console.log('error');
};

const handleSuccess = (message: string) => {
  // showToast('success', 'Sucesso', message);
  console.log(message)
};

const get = async (url: string, config = {}) => {
  try {
    const response = await api.get(url, config);
    handleSuccess('Dados carregados com sucesso');
    return response.data;
  } catch (error: any) {
    handleError(error);
    throw error;
  }
};

const post = async (url: string, data:Object, config = {}) => {
  try {
    const response = await api.post(url, data, config);
    handleSuccess('Dados enviados com sucesso');
    return response.data;
  } catch (error: any) {
    handleError(error);
    throw error;
  }
};

export default {
  get,
  post
};
