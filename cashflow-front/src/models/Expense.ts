export default interface Expense {
  ExpenseName: string;
  Value: number;
  Category: string;
  Recurrence: string;
  InitialDate: Date;
  FinalDate: Date;
}