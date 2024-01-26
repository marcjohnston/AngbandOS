import { ColorEnum } from "../color-enum/color-enum.module";

export class PrintLine {
  public row: number | undefined;
  public col: number | undefined;
  public text: string | undefined;
  public foreColor: ColorEnum | undefined;
  public backColor: ColorEnum | undefined;
}
