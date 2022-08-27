import { ColourEnum } from "../colour-enum/colour-enum.module";
import { ColoursMap } from "../colours-map/colours-map.module";
import { SoundEffectsMap } from "../sound-effects-map/sound-effects-map.module";

export class HtmlConsole {
  public charSize = 16;
  public xSpacing = 16;
  public ySpacing = 16;
  private _sounds = SoundEffectsMap.getSoundEffectsMap();
  private _colours = ColoursMap.getColoursMap();

  constructor(
    private context: CanvasRenderingContext2D
  ) {
  }

  public clear() {
    this.context.clearRect(0, 0, 80 * this.xSpacing, 45 * this.ySpacing);
  }

  public print(row: number, col: number, text: string, foreColor: ColourEnum, backColour: ColourEnum) {
    // The text alignments need to be set every call.  Something changes them.
    this.context.textBaseline = 'top';
    this.context.textAlign = 'left';
    this.context.font = `bold ${this.charSize}px Courier`;

    // Fill the background.
    const rgbBackColor = this._colours[backColour];
    this.context.fillStyle = `${rgbBackColor}`;
    this.context.fillRect(col * this.xSpacing, row * this.ySpacing, text.length * this.xSpacing, this.ySpacing);

    // Draw the text.
    const rgbForeColor = this._colours[foreColor];
    this.context.fillStyle = `${rgbForeColor}`;
    for (var i: number = 0; i < text.length; i++) {
      const c = text[i];
      this.context.fillText(c, col * this.xSpacing, row * this.ySpacing);
      col++;
    }
  }
}
