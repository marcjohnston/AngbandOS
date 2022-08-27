import { ElementRef } from "@angular/core";
import { ColourEnum } from "../colour-enum/colour-enum.module";
import { ColoursMap } from "../colours-map/colours-map.module";
import { SoundEffectsMap } from "../sound-effects-map/sound-effects-map.module";

export class HtmlConsole {
  public charSize = 16;
  public xSpacing = 16;
  public ySpacing = 16;
  public width = 80;
  public height = 45;
  private _sounds = SoundEffectsMap.getSoundEffectsMap();
  private _colours = ColoursMap.getColoursMap();
  private context: CanvasRenderingContext2D | undefined;

  constructor(
    private canvasRef: ElementRef
  ) {
    const canvas = this.canvasRef.nativeElement;
    const context: CanvasRenderingContext2D = canvas.getContext('2d');
    canvas.width = this.width * this.charSize;
    canvas.height = this.height * this.charSize;
    canvas.style.minWidth = canvas.width + "px";
    canvas.style.maxWidth = canvas.width + "px";
    canvas.style.minHeight = canvas.height + "px";
    canvas.style.maxHeight = canvas.height + "px";
  }

  public clear() {
    this.context?.clearRect(0, 0, this.width * this.xSpacing, this.height * this.ySpacing);
  }

  public playSound(sound: number) {
    // Get the list of available sounds.
    const availableSounds: string[] | undefined = this._sounds[sound];

    // Ensure there are sounds available.
    if (availableSounds !== undefined) {
      const randomSelection = Math.floor(Math.random() * availableSounds.length);

      // Choose one.
      var soundResourceName = availableSounds[randomSelection];

      // Play it.
      const audio = new Audio();
      audio.src = `/assets/sounds/${soundResourceName}`;
      audio.load();
      audio.play();
    }
  }

  public print(row: number, col: number, text: string, foreColor: ColourEnum, backColour: ColourEnum) {
    // The text alignments need to be set every call.  Something changes them.
    this.context!.textBaseline = 'top';
    this.context!.textAlign = 'left';
    this.context!.font = `bold ${this.charSize}px Courier`;

    // Fill the background.
    const rgbBackColor = this._colours[backColour];
    this.context!.fillStyle = `${rgbBackColor}`;
    this.context!.fillRect(col * this.xSpacing, row * this.ySpacing, text.length * this.xSpacing, this.ySpacing);

    // Draw the text.
    const rgbForeColor = this._colours[foreColor];
    this.context!.fillStyle = `${rgbForeColor}`;
    for (var i: number = 0; i < text.length; i++) {
      const c = text[i];
      this.context!.fillText(c, col * this.xSpacing, row * this.ySpacing);
      col++;
    }
  }
}
