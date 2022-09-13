import { ChangeDetectorRef, Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { MatSlider, MatSliderChange } from '@angular/material/slider';
import { ColourEnum } from '../modules/colour-enum/colour-enum.module';
import { ColoursMap } from '../modules/colours-map/colours-map.module';
import { HtmlConsole } from '../modules/html-console/html-console.module';
import { UiConfiguration } from './ui-configuration';

@Component({
  selector: 'app-ui',
  templateUrl: './ui.component.html',
  styleUrls: ['./ui.component.scss']
})
export class UiComponent implements OnInit {
  @ViewChild('console', { static: true }) private canvasRef: ElementRef | undefined;
  private uiConfiguration = new UiConfiguration();
  private _htmlConsole: HtmlConsole | undefined = undefined;

  constructor(
    private changeDetectorRef: ChangeDetectorRef
  ) { }

  public get charSize(): number {
    return this._htmlConsole!.charSize;
  }

  public get xSpacing(): number {
    return this._htmlConsole!.xSpacing;
  }

  public get ySpacing(): number {
    return this._htmlConsole!.ySpacing;
  }

  public get windowWidth(): number {
    return this._htmlConsole!.width;
  }

  public get windowHeight(): number {
    return this._htmlConsole!.height;
  }

  public setCharSize(value: number | null) {
    if (value !== null) {
      this._htmlConsole!.charSize = value;
      this.refresh();
    }
  }

  public setXSpacing(value: number | null) {
    if (value !== null) {
      this._htmlConsole!.xSpacing = value;
      this.refresh();
    }
  }

  public setYSpacing(value: number | null) {
    if (value !== null) {
      this._htmlConsole!.ySpacing = value;
      this.refresh();
    }
  }

  public setWindowWidth(value: number | null) {
    if (value !== null) {
      this._htmlConsole!.width = value;
      this.refresh();
    }
  }

  public setWindowHeight(value: number | null) {
    if (value !== null) {
      this._htmlConsole!.height = value;
      this.refresh();
    }
  }

  public refresh() {
    if (this._htmlConsole !== undefined) {
      this._htmlConsole.resizeCanvas();
      this.changeDetectorRef.detectChanges();

      this._htmlConsole.clear();

      for (var y: number = 0; y < this.windowHeight; y++) {
        this._htmlConsole.printUnmappedColor(y, 0, `${y % 10}`, "#FFFFFF", "#000000");
      }

      for (var x: number = 0; x < this.windowWidth; x++) {
        this._htmlConsole.printUnmappedColor(0, x, `${x % 10}`, "#FFFFFF", "#000000");
      }

      var charCode = 33;
      for (var y: number = 0; y < 10; y++) {
        for (var x: number = 0; x < this.windowWidth - 2; x++) {
          const c = String.fromCharCode(charCode);
          charCode++;
          if (charCode > 126) {
            charCode = 32;
          }
          this._htmlConsole.printUnmappedColor(y + 2, x + 2, c, "#FFFFFF", "#000000");
        }
      }

      const colours: string[] = ColoursMap.getColoursMap();
      for (var colour: number = 1; colour < colours.length; colour++) {
        this._htmlConsole.printUnmappedColor(12 + colour, 3, colour.toString(), "#FFFFFF", "#000000");
        this._htmlConsole.print(12 + colour, 6, ColourEnum[colour], colour, ColourEnum.Background);
      }
    }
  }

  ngOnInit(): void {
    if (this.canvasRef !== undefined) {
      this._htmlConsole = new HtmlConsole(this.canvasRef);
    }
    this.refresh();
  }
}
