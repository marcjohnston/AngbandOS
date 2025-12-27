import { ChangeDetectorRef, Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { MatSlider } from '@angular/material/slider';
import { ColorEnum } from '../modules/color-enum/color-enum.module';
import { ColorsMap } from '../modules/colors-map/colors-map.module';
import { HtmlConsole } from '../modules/html-console/html-console.module';
import { NgFor } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ColorPickerModule } from 'ngx-color-picker';

@Component({
  selector: 'app-ui',
  templateUrl: './ui.component.html',
  styleUrls: ['./ui.component.scss'],
  standalone: true,
  imports: [
    NgFor,
    MatSlider,
    FormsModule,
    ColorPickerModule
  ]
})
export class UiComponent implements OnInit {
  @ViewChild('console', { static: true }) private canvasRef: ElementRef | undefined;
  //private uiConfiguration = new UiConfiguration();
  private _htmlConsole: HtmlConsole | undefined = undefined;
  public color: string = "#FFFFFF";
  public colors: string[];

  constructor(
    private changeDetectorRef: ChangeDetectorRef
  ) {
    const allColours = Object.values(ColorEnum).filter((_enum) => typeof (_enum) === "string") as string[];
    this.colors = allColours.splice(1);
  }

  public get charSize(): number {
    return this._htmlConsole!.configuration.charSize;
  }

  public set charSize(value: number) {
    if (value !== null) {
      this._htmlConsole!.configuration.charSize = value;
      this.refresh();
    }
  }
  public get xSpacing(): number {
    return this._htmlConsole!.configuration.xSpacing;
  }

  public set xSpacing(value: number) {
    if (value !== null) {
      this._htmlConsole!.configuration.xSpacing = value;
      this.refresh();
    }
  }

  public get ySpacing(): number {
    return this._htmlConsole!.configuration.ySpacing;
  }

  public set ySpacing(value: number) {
    if (value !== null) {
      this._htmlConsole!.configuration.ySpacing = value;
      this.refresh();
    }
  }

  public get windowWidth(): number {
    return this._htmlConsole!.configuration.width;
  }

  public set windowWidth(value: number) {
    if (value !== null) {
      this._htmlConsole!.configuration.width = value;
      this.refresh();
    }
  }

  public get windowHeight(): number {
    return this._htmlConsole!.configuration.height;
  }

  public set windowHeight(value: number) {
    if (value !== null) {
      this._htmlConsole!.configuration.height = value;
      this.refresh();
    }
  }

  public getColor(index: number): string {
    return this._htmlConsole!.configuration.colors[index];
  }

  public setColor(index: number, color: string) {
    if (this._htmlConsole !== undefined && this._htmlConsole.configuration.colors !== undefined) {
      this._htmlConsole!.configuration.colors[index] = color;
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

      const colors: string[] = ColorsMap.getColorsMap();
      for (var color: number = 1; color < colors.length; color++) {
        this._htmlConsole.printUnmappedColor(12 + color, 30, color.toString(), "#FFFFFF", "#000000");
        this._htmlConsole.print(12 + color, 33, ColorEnum[color], color, ColorEnum.Background);
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
