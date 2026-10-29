/**
 * Represents one validated selectable value of an enumeration.
 */
export class EnumOption {
    public name: string;
    public value: number;

    constructor(name: string, value: number) {
        this.name = name;
        this.value = value;
    }
}
