import { Recurrence } from "../models/Expense";

export const capitalizeFirstLetter = (string: any) => {
  if (!string) return string;
  var newString = separateCamelCase(string);
  return newString.charAt(0).toUpperCase() + newString.slice(1);
}

export const separateCamelCase = (str: string) => {
  return str.replace(/([a-z])([A-Z])/g, '$1 $2');
}

export const parseRecurrence = (recurrence: string) => {
  switch (recurrence.toUpperCase()) {
    case "DAILY":
      return Recurrence.DAILY;
    case "WEEKLY":
      return Recurrence.WEEKLY;
    case "MONTHLY":
      return Recurrence.MONTHLY;
    case "QUARTERLY":
      return Recurrence.QUARTERLY;
    case "YEARLY":
      return Recurrence.YEARLY;
  }
}

export const parseRecurrenceToString = (recurrence: any) => {
  switch (recurrence) {
    case 0:
      return "Daily"
    case 1:
      return "Weekly"
    case 2:
      return "Monthly"
    case 3:
      return "Quarterly"
    case 4:
      return "Yearly"
    default:
      return "Something went wrong"
  }
}