import { defineStore } from "pinia"
import Expense from "../models/Expense"
import httpRequestService from "../api/httpRequestService"
import { parseRecurrenceToString } from '../util/util'

export const useExpensesStore = defineStore('expenses', {
  state: () => ({
    expenses: [] as Expense[],
  }),
  getters: {
    getAllEntity: (state) => {
      return state.expenses
    }
  },
  actions: {
    async getAll(): Promise<Expense[]> {
      const response = await httpRequestService.get('/Expense/GetAllExpenses', 'Expense')
      this.expenses = response
      this.expenses.forEach((e) => {
        e.recurrence = parseRecurrenceToString(e.recurrence)
      })
      return this.expenses
    },
    async postExpense(expense: Expense): Promise<Expense> {
      const response = await httpRequestService.post('/Expense/CreateExpense', expense, 'Expense')	
      this.expenses = [...this.expenses, response]
      return response
    },
    async updateExpense(expense: Expense): Promise<Expense> {
      const response = await httpRequestService.put('/Expense/UpdateExpense', expense, 'Expense')
      const index = this.expenses.findIndex((e) => e.id === expense.id)
      if (index !== -1) {
        // Atualiza o objeto existente para manter a reatividade
        Object.assign(this.expenses[index], response)
      }
      return response
    },
    async deleteSingleExpense(expenseId: string): Promise<void> {
      await httpRequestService.deleteSingleItem(`/Expense/DeleteExpense/${expenseId}`, 'Expense')
      this.expenses = this.expenses.filter((e) => e.id !== expenseId)
    },
    async bulkDeleteExpenses(payload: { ids: string[] }): Promise<void> {
      await httpRequestService.bulkDeleteItems('/Expense/BulkDeleteExpenses', payload, 'Expenses')
      this.expenses = this.expenses.filter((e) => !payload.ids.includes(e.id))
    }
  }
})