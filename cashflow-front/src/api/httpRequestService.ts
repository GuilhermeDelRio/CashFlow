import api from './axios'
import { toast, type ToastOptions } from 'vue3-toastify'

const handleError = (error: string) => {
}

const handleSuccess = (message: string) => {
  toast.success(message, {
    position: toast.POSITION.BOTTOM_RIGHT,
  } as ToastOptions);
}

const get = async (url: string, _entity: string, config = {}) => {
  try {
    const response = await api.get(url, config)
    return response.data
  } catch (error: any) {
    handleError(error)
    throw error
  }
}

const post = async (url: string, data:Object, entity: string, config = {}) => {
  try {
    const response = await api.post(url, data, config)
    handleSuccess(`${entity} created successfully`)
    return response.data
  } catch (error: any) {
    handleError(error)
    throw error
  }
}

const put = async (url: string, data:Object, entity: string, config = {}) => {
  try {
    const response = await api.put(url, data, config)
    handleSuccess(`${entity} updated successfully`)
    return response.data
  } catch (error: any) {
    handleError(error)
    throw error
  }
}

const deleteSingleItem = async (url: string, entity: string, config = {}) => {
  try {
    await api.delete(url, config)
    handleSuccess(`${entity} deleted successfully`)
  } catch (error: any) {
    handleError(error)
    throw error
  }
}

export default {
  get,
  post,
  put,
  deleteSingleItem
}
