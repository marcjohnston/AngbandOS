import { ColorsMap } from "../colors-map/colors-map.module";

export class ConsoleConfiguration {
  public fontName = "Courier";
  public bold = true;
  public width = 80; // The number of columns wide for the screen.
  public height = 45; // The number of rows high for the screen.
  public colors = ColorsMap.getColorsMap(); // An RGB conversion map from game colors to screen colors.
}
