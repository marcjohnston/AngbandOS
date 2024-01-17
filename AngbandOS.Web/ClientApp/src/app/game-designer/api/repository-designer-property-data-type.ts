import { DesignerPropertyDataType } from "./designer-property-data-type";
import { SelectItem } from "./select-item";

export class RepositoryDesignerPropertyDataType extends DesignerPropertyDataType {
  constructor(items: SelectItem[]) {
    super();
    this.items = items;
  }
  public override name: string = "Repository";
  public override render = "Repository";
  public readonly items: SelectItem[];
}
