import { JsonEnumMetadata } from "./JsonEnumMetadata";
import { JsonPropertyMetadata } from "./json-property-metadata";


export class JsonGameMetadata {
    public properties: JsonPropertyMetadata[] | undefined = undefined;
    public enums: JsonEnumMetadata[] | undefined = undefined;
}
