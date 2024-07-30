import { defineStore } from "pinia";
import Expense from "../models/Expense";
import { useFetch } from "../composables/crudComposable";

export const useExpensesStore = defineStore('expenses', {
  state: () => ({
    expenses: [] as Expense[],
  }),
  actions: {
    async getAllExpenses(): Promise<Expense[]> {
      const { data, error, fetchData } = useFetch<Expense[]>('/Expense/GetAllExpenses');

      await fetchData();

      if (error.value) {
        console.log(error.value);
      } else {
        this.expenses = data.value || [];
      }

      return this.expenses;
    }
  }
});