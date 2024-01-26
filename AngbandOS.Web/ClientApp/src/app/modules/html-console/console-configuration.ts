import { ColorsMap } from "../colors-map/colors-map.module";

export class ConsoleConfiguration {
  public charSize = 16; // The font size in pixels.
  public xSpacing = 12; // The number of pixels allocated to each column.
  public ySpacing = 15; // The number of pixels allocated to each row.
  public xOffset = 1; // The number of pixels to horizontally offset the drawing of the character.
  public yOffset = 0; // The number of pixels to vertically offset the drawing of the character.
  public width = 80; // The number of columns wide for the screen.
  public height = 45; // The number of rows high for the screen.
  public colors = ColorsMap.getColorsMap(); // An RGB conversion map from game colors to screen colors.
}
