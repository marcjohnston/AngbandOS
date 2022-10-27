import { HttpErrorResponse } from "@angular/common/http";

export class ErrorMessages {
  public static getMessage(error: HttpErrorResponse): string[] {
    const messages: string[] = [];
    if (error.status >= 400 && error.status < 500) {
      messages.push("Unauthorized.");
    }
    if (error.error !== null && error.error.length > 0) {
      messages.push(error.error);
    }
    return messages;
  }
}

