import { ColourEnum } from "../colour-enum/colour-enum.module";

export class PrintLine {
  public row: number | undefined;
  public col: number | undefined;
  public text: string | undefined;
  public foreColour: ColourEnum | undefined;
  public backColour: ColourEnum | undefined;
}
