import { z } from "zod"

const expenseSchema = z.object({
  expenseName: z.string()
    .min(3, { message: 'Expense name must have at least 3 characters' }),	
  value: z.number()
    .min(0.01, { message: 'Expense amount must be greater than 0' }),
  category: z.object({ name: z.string()
    .min(1, { message: 'Category must be selected' }) }),
  recurrence: z.object({ name: z.string()
    .min(1, { message: 'Recurrence must be selected' }) }),
  initialDate: z.date(),
  finalDate: z.date()
})

export default expenseSchema