import { defineStore } from "pinia"
import Expense from "../models/Expense"
import httpRequestService from "../api/httpRequestService"

export const useExpensesStore = defineStore('expenses', {
  state: () => ({
    expenses: [] as Expense[],
  }),
  actions: {
    async getAllExpenses(): Promise<Expense[]> {
      const response = await httpRequestService.get('/Expense/GetAllExpenses', 'Expense')
      console.log(response)
      this.expenses = response
      return this.expenses
    },
    async postExpense(expense: Expense): Promise<Expense> {
      const response = await httpRequestService.post('/Expense/CreateExpense', expense, 'Expense')	
      this.expenses = [...this.expenses, response]
      return response
    }
  }
})