import { ElementRef } from "@angular/core";
import { ColorEnum } from "../color-enum/color-enum.module";
import { SoundEffectsMap } from "../sound-effects-map/sound-effects-map.module";
import { ConsoleConfiguration } from "./console-configuration";
import { PrintLine } from "./print-line";

export class HtmlConsole {
  private _sounds = SoundEffectsMap.getSoundEffectsMap();
  private context: CanvasRenderingContext2D | undefined;
  public configuration = new ConsoleConfiguration();

  constructor(
    private canvasRef: ElementRef,
  ) {
    const canvas = this.canvasRef.nativeElement;
    this.context = CanvasRenderingContext2D = canvas.getContext('2d');
    this.resizeCanvas();
  }

  public resizeCanvas() {
    const canvas = this.canvasRef.nativeElement;
    canvas.width = this.canvasWidth;
    canvas.height = this.canvasHeight;
    canvas.style.minWidth = canvas.width + "px";
    canvas.style.maxWidth = canvas.width + "px";
    canvas.style.minHeight = canvas.height + "px";
    canvas.style.maxHeight = canvas.height + "px";
  }

  public get canvasWidth(): number {
    return this.configuration.width * this.configuration.xSpacing;
  }

  public get canvasHeight(): number {
    return this.configuration.height * this.configuration.ySpacing;
  }

  public clear() {
    this.context?.clearRect(0, 0, this.canvasWidth, this.canvasHeight);
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

  public printUnmappedColor(row: number, col: number, text: string, foreColor: string, backColor: string) {
    // The text alignments need to be set every call.  Something changes them.
    this.context!.textBaseline = 'top';
    this.context!.textAlign = 'left';
    this.context!.font = `bold ${this.configuration.charSize}px Courier`;

    // Fill/erase the background.
    const rowY = row * this.configuration.ySpacing;
    this.context!.fillStyle = `${backColor}`;
    this.context!.fillRect(col * this.configuration.xSpacing, rowY, text.length * this.configuration.xSpacing, this.configuration.ySpacing);

    // Draw the text.
    this.context!.fillStyle = `${foreColor}`;
    for (var i: number = 0; i < text.length; i++) {
      const c = text[i];
      this.context!.fillText(c, col * this.configuration.xSpacing + this.configuration.xOffset, rowY + this.configuration.yOffset);
      col++;
    }
  }

  public print(row: number, col: number, text: string, foreColorEnum: ColorEnum, backColorEnum: ColorEnum) {
    const backColor = this.configuration.colors[backColorEnum];
    const foreColor = this.configuration.colors[foreColorEnum];
    this.printUnmappedColor(row, col, text, foreColor, backColor);
  }

  public batchPrint(printLines: PrintLine[]) {
    for (let i = 0; i < printLines.length; i++) {
      const printLine = printLines[i];
      this.print(printLine.row!, printLine.col!, printLine.text!, printLine.foreColor!, printLine.backColor!);
    }
  }
}
