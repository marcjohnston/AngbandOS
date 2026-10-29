import { EnumOption } from "./EnumOption";

/**
 * Represents a validated enumeration with its selectable values.
 */

export class EnumMetadata {
    public name: string;
    public options: EnumOption[];

    constructor(name: string, options: EnumOption[]) {
        this.name = name;
        this.options = options;
    }
}
