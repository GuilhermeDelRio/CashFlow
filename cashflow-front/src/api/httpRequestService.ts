import api from './axios';
import { useToast } from 'primevue/usetoast';

// const toast = useToast();

// const showToast = (severity: any, summary: string, detail: string) => {
//   toast.add({ severity, summary, detail, life: 3000 });
// };

const handleError = (error: string) => {
  // showToast('error', 'Erro', error);
};

const handleSuccess = (message: string) => {
  // showToast('success', 'Sucesso', message);
  console.log(message)
};

const get = async (url: string, _entity: string, config = {}) => {
  try {
    const response = await api.get(url, config);
    return response.data;
  } catch (error: any) {
    handleError(error);
    throw error;
  }
};

const post = async (url: string, data:Object, entity: string, config = {}) => {
  try {
    console.log(data)
    const response = await api.post(url, data, config);
    handleSuccess(`${entity} created successfully`);
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
