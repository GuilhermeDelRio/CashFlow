import { ref } from 'vue';
import { AxiosRequestConfig } from 'axios';
import api from '../api/axios';

export function useFetch<T>(url: string, config?: AxiosRequestConfig) {
  const data = ref<T | null>(null);
  const error = ref<string | null>(null);
  const loading = ref<boolean>(false);

  const fetchData = async () => {
    loading.value = true;
    try {
      const response = await api.get(url, config);
      data.value = response.data;
    } catch (err: any) {
      error.value = err.message || 'An error occurred';
    } finally {
      loading.value = false;
    }
  };

  return { data, error, loading, fetchData };
}
