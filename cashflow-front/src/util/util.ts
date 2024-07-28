export const capitalizeFirstLetter = (string: any) => {
  if (!string) return string;
  var newString = separateCamelCase(string);
  return newString.charAt(0).toUpperCase() + newString.slice(1);
}

export const separateCamelCase = (str: string) => {
  return str.replace(/([a-z])([A-Z])/g, '$1 $2');
}