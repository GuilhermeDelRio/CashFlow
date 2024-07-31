import { defineStore } from "pinia";
import { useFetch } from "../composables/crudComposable";
import Expense from "../models/Expense";

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