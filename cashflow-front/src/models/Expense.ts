export enum Recurrence {
  DAILY,
  WEEKLY,
  MONTHLY,
  QUARTERLY,
  YEARLY
}

export default interface Expense {
  Id: string,
  expenseName: string;
  value: number;
  category: string;
  recurrence: Recurrence;
  initialDate: Date;
  finalDate: Date;
}