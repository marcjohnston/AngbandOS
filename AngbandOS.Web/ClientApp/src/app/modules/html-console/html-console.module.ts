import { ElementRef } from "@angular/core";
import { ColorEnum } from "../color-enum/color-enum.module";
import { SoundEffectsMap } from "../sound-effects-map/sound-effects-map.module";
import { ConsoleConfiguration } from "./console-configuration";
import { PrintLine } from "./print-line";
import { ColorsMap } from '../../modules/colors-map/colors-map.module';
import { FontMeasurements } from "./font-measurements";

export class HtmlConsole {
  private _sounds = SoundEffectsMap.getSoundEffectsMap();
  private context: CanvasRenderingContext2D;
  private fontSizeInPixels!: number;
  private fontMeasurements!: FontMeasurements;

  constructor(
    private canvasRef: ElementRef,
    private configuration: ConsoleConfiguration
  ) {
    const canvas = this.canvasRef.nativeElement;
    this.context = canvas.getContext('2d')!;
    this.refresh();
}

  public get consoleConfiguration() {
    return this.configuration;
  }

  public set consoleConfiguration(value: ConsoleConfiguration) {
    this.configuration = value;
    this.refresh();
  }

  public drawAlignments() {
    const font = this.generateFontName(this.fontSizeInPixels);
    this.context.font = font;

    // Clear the screen.
    this.clear();

    // Draw row numbers.
    for (var y: number = 0; y < this.configuration.height; y++) {
      this.printUnmappedColor(y, 0, `${y}`, "#FFFFFF", "#000000");
    }

    // Draw column numbers.
    for (var x: number = 1; x < this.configuration.width; x++) {
      if (x % 10 == 0) {
        this.printUnmappedColor(1, x, `${Math.floor(x / 10)}`, "#FFFFFF", "#000000");
      }
      this.printUnmappedColor(0, x, `${x % 10}`, "#FFFFFF", "#000000");
    }

    // Draw the color map.
    const colors: string[] = ColorsMap.getColorsMap();
    var row = 9;
    var col = 57
    for (var color: number = 1; color < colors.length; color++) {
      this.printUnmappedColor(row + color, col, color.toString(), "white", "black");
      this.print(row + color, col + 3, ColorEnum[color], color, ColorEnum.Background);
    }

    // Draw the font name in the lower right corner.
    this.printUnmappedColor(this.configuration.height - 1, this.configuration.width - this.context.font.length, this.context.font, "white", "grey", false);

    row = 3;
    col = 3;

    for (var asciiIndex = 0; asciiIndex <= 255; asciiIndex++) {
      // Fill/erase the background for this cell.
      this.context.fillStyle = `black`;
      this.context.fillRect(col * this.fontMeasurements.characterWidth, row * this.fontMeasurements.characterHeight, this.fontMeasurements.characterWidth, this.fontMeasurements.characterHeight);

      // Draw the ascii index.
      this.printUnmappedColor(row, col, `${this.leftPad(asciiIndex, 3, "0")}-`, "white", "black", false);

      // We need to update the textbase.  Preserve the original value and set it after we draw the glyph.
      const textBaseline = this.context.textBaseline;
      this.context.textBaseline = "top";

      // Draw the glyph.
      const character = String.fromCharCode(asciiIndex);
      this.context.fillStyle = `white`;
      this.context.fillText(character, (col + 5) * this.fontMeasurements.characterWidth, row * this.fontMeasurements.characterHeight);

      // Draw the anchor point.
      this.context.fillStyle = `yellow`;
      this.context.fillRect((col + 5) * this.fontMeasurements.characterWidth, row * this.fontMeasurements.characterHeight, 1, 1);

      // Draw the text metrics bounding rectangle.
      const textMetrics = this.context.measureText(character);
      this.context.strokeStyle = 'red';
      this.context.strokeRect((col + 5) * this.fontMeasurements.characterWidth - textMetrics.actualBoundingBoxLeft, row * this.fontMeasurements.characterHeight - textMetrics.actualBoundingBoxAscent, textMetrics.actualBoundingBoxLeft + textMetrics.actualBoundingBoxRight, textMetrics.actualBoundingBoxAscent + textMetrics.actualBoundingBoxDescent);

      // Restore the textbaseline.
      this.context.textBaseline = textBaseline;

      // Draw a bounding character box.
      this.context.strokeStyle = 'yellow';
      this.context.strokeRect((col + 7) * this.fontMeasurements.characterWidth, row * this.fontMeasurements.characterHeight, this.fontMeasurements.characterWidth, this.fontMeasurements.characterHeight);

      // Draw the text using the precomputed per-glyph offsets.
      this.printUnmappedColor(row, col + 7, character, "white", "black");

      // Go to the next row down.
      row += 1;

      // Check for wrapping.
      if (row >= this.configuration.height) {
        row = 3;
        col += 9;
      }
    }
  }

  private leftPad(value: number, length: number, char: string): string {
    var text = `${value}`;
    while (text.length < length) {
      text = `${char}${text}`;
    }
    return text;
  }

  /**
   * Force refresh.  The refresh resizes the font and updates the canvas size accordingly.
   */
  public refresh() {

    const canvas = this.canvasRef.nativeElement;

    // Measure the font size.
    const containerWidth = this.canvasRef.nativeElement.parentElement.clientWidth;
    const containerHeight = this.canvasRef.nativeElement.parentElement.clientHeight;

    // Initialize the default font setup.    
    this.fontSizeInPixels = 3;
    this.context.font = this.generateFontName(this.fontSizeInPixels);
    this.context.textBaseline = 'alphabetic';
    this.context.textAlign = 'left';

    // Resize the font.
    this.fontMeasurements = new FontMeasurements(this.canvasRef, this.configuration.fontName);

    while (true) {
      // Test the next font size.
      const nextFontMeasurements = new FontMeasurements(this.canvasRef, this.generateFontName(this.fontSizeInPixels + 1));

      if (nextFontMeasurements.characterWidth * this.configuration.width > containerWidth || nextFontMeasurements.characterHeight * this.configuration.height > containerHeight) {
        // Use the previous font size and values.
        break;
      }

      // Accept this font size.
      this.fontSizeInPixels++;
      this.fontMeasurements = nextFontMeasurements;
    }

    // Resize the canvas. 
    canvas.width = this.fontMeasurements.characterWidth * this.configuration.width;
    canvas.height = this.fontMeasurements.characterHeight * this.configuration.height;

    // Resizing the canvas causes the font and other settings to reset.  So these needs to be reapplied.
    this.context.font = this.generateFontName(this.fontSizeInPixels);
    this.context.textBaseline = 'alphabetic';
    this.context.textAlign = 'left';

    canvas.title = `Font: ${this.context.font} Cell: ${this.fontMeasurements.characterWidth},${this.fontMeasurements.characterHeight} Canvas: ${canvas.width}x${canvas.height} Container: ${containerWidth}x${containerHeight}`;

    canvas.style.minWidth = canvas.width + "px";
    canvas.style.maxWidth = canvas.width + "px";
    canvas.style.minHeight = canvas.height + "px";
    canvas.style.maxHeight = canvas.height + "px";
  }

  public clear() {
    this.context?.clearRect(0, 0, this.configuration.width * this.fontMeasurements.characterWidth, this.configuration.height * this.fontMeasurements.characterHeight);
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

  private generateFontName(fontSizeInPixels: number): string {
    const bold = this.configuration.bold ? "bold" : "";
    return `${bold} ${fontSizeInPixels}px ${this.configuration.fontName}`;
  }

  public printUnmappedColor(row: number, col: number, text: string, foreColor: string, backColor: string, drawBorder = false) {
    // Fill/erase the background.
    var colX = col * this.fontMeasurements.characterWidth;
    const rowY = row * this.fontMeasurements.characterHeight;
    this.context.fillStyle = `${backColor}`;
    this.context.fillRect(colX, rowY, text.length * this.fontMeasurements.characterWidth, this.fontMeasurements.characterHeight);

    if (drawBorder) {
      this.context.strokeStyle = 'yellow';
      this.context.strokeRect(colX, rowY, text.length * this.fontMeasurements.characterWidth, this.fontMeasurements.characterHeight);
    }

    // Draw the text using the precomputed per-glyph offsets when available.
    this.context.fillStyle = `${foreColor}`;
    for (var i: number = 0; i < text.length; i++) {
      const c = text[i];
      const code = c.charCodeAt(0);
      const offset = this.fontMeasurements.offsets[code]; // TODO: there is no safeguard for invalid ascii range
      this.context.fillText(c, colX + offset.x, rowY + offset.y);
      colX += this.fontMeasurements.characterWidth;
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
