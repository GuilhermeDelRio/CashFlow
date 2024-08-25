export enum Recurrence {
  DAILY,
  WEEKLY,
  MONTHLY,
  QUARTERLY,
  YEARLY
}

export default interface Expense {
  id: string,
  expenseName: string;
  value: number;
  category: string;
  recurrence: Recurrence;
  initialDate: Date;
  finalDate: Date;
}