import api from './axios'

const handleError = (error: string) => {
}

const handleSuccess = (message: string) => {
  console.log(message)
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

export default {
  get,
  post
}
