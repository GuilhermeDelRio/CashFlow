import { defineStore } from "pinia"
import Category from "../models/Category"
import httpRequestService from "../api/httpRequestService"

export const useCategoriesStore = defineStore('categories', {
  state: () => ({
    categories: [] as any[],
  }),
  getters: {
    getAllEntity: (state) => {
      return state.categories
    }
  },
  actions: {
    async getAll() {
      const response = await httpRequestService.get('/Category/GetAllCategories', 'Category')
      this.categories = response
      return this.categories
    },
    async postCategory(category: Category): Promise<Category> {
      const response = await httpRequestService.post('/Category/CreateCategory', category, 'Category')	
      this.categories = [...this.categories, response]
      return response
    },
    async updateCategory(category: Category): Promise<Category> {
      const response = await httpRequestService.put('/Category/UpdateCategory', category, 'Category')
      const index = this.categories.findIndex((e) => e.id === category.id)
      if (index !== -1) {
        // Atualiza o objeto existente para manter a reatividade
        Object.assign(this.categories[index], response)
      }
      return response
    },
    async deleteSingleItem(categoryId: string): Promise<void> {
      await httpRequestService.deleteSingleItem(`/Category/DeleteCategory/${categoryId}`, 'Category')
      this.categories = this.categories.filter((e) => e.id !== categoryId)
    },
    async bulkDeleteItems(payload: { ids: string[] }): Promise<void> {
      await httpRequestService.bulkDeleteItems('/Category/BulkDeleteCategories', payload, 'Categories')
      this.categories = this.categories.filter((e) => !payload.ids.includes(e.id))
    }
  }
})