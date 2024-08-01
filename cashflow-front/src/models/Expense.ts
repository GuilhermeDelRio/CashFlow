export enum Recurrence {
  DAILY = "DAILY",
  WEEKLY = "WEEKLY",
  MONTHLY = "MONTHLY",
  QUARTERLY = "QUARTERLY",
  YEARLY = "YEARLY",
}

export default interface Expense {
  ExpenseName: string;
  Value: number;
  Category: string;
  Recurrence: Recurrence;
  InitialDate: Date;
  FinalDate: Date;
}