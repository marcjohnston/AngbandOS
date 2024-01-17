import { DesignerPropertyDataType } from "./designer-property-data-type";
import { SelectItem } from "./select-item";

export abstract class SelectListDesignerPropertyDataType extends DesignerPropertyDataType {
  public override name: string = "Select List";
  public override render = "SelectList";
  public abstract options: SelectItem[];
}
