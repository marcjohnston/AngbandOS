export function convertToTitleCase(name: string): string {
  return name.replace(/(?!^)([A-Z])/g, ' $1');
}
