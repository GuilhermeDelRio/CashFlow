export enum Recurrence {
  DAILY,
  WEEKLY,
  MONTHLY,
  QUARTERLY,
  YEARLY
}

export default interface Expense {
  expenseName: string;
  value: number;
  category: string;
  recurrence: Recurrence;
  initialDate: Date;
  finalDate: Date;
}