import { DesignerPropertyDataType } from "./designer-property-data-type";

export class StringDesignerPropertyDataType extends DesignerPropertyDataType {
  public override name: string = "String";
  public override render = "String";
}
