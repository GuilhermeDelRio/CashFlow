import { defineStore } from "pinia";
// import { useFetch } from "../composables/crudComposable";
import Expense from "../models/Expense";
import httpRequestService from "../api/httpRequestService";

export const useExpensesStore = defineStore('expenses', {
  state: () => ({
    expenses: [] as Expense[],
  }),
  actions: {
    async getAllExpenses(): Promise<Expense[]> {
      const response = await httpRequestService.get(('/Expense/GetAllExpenses'));
      this.expenses = response;
      return this.expenses;
    }
  }
});