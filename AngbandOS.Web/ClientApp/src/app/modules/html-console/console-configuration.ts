import { ColoursMap } from "../colours-map/colours-map.module";

export class ConsoleConfiguration {
  public charSize = 16;
  public xSpacing = 9;
  public ySpacing = 15;
  public width = 80;
  public height = 45;
  public colours = ColoursMap.getColoursMap();
}
