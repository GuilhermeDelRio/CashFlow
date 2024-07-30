import { defineStore } from "pinia";
import api from "../api/axios";
import Expense from "../models/Expense";

export const useExpensesStore = defineStore('expenses', {
  state: () => ({
    expenses: [] as Expense[],
  }),
  actions: {
    async getAllExpenses() : Promise<Expense[]>{
      try {
        const res = await api.get('/Expense/GetAllExpenses');
        this.expenses = res.data;
      } catch(e) {
        console.log(e);
      }

      return this.expenses;
    }
  }
});