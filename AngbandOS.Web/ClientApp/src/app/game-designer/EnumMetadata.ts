import { SelectOption } from "./select-option";

/**
 * Represents a validated enumeration with its selectable values.
 */

export class EnumMetadata {
    public name: string;
    public options: SelectOption[];

  constructor(name: string, options: SelectOption[]) {
        this.name = name;
        this.options = options;
    }
}
