import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { MatSlider } from '@angular/material/slider';
import { ColorEnum } from '../modules/color-enum/color-enum.module';
import { HtmlConsole } from '../modules/html-console/html-console.module';
import { FormsModule } from '@angular/forms';
import { ColorPickerModule } from 'ngx-color-picker';
import { MasterLayoutComponent } from '../master-layout/master-layout.component';
import { MatSelectModule } from '@angular/material/select';
import { ConsoleConfiguration } from '../modules/html-console/console-configuration';

@Component({
  selector: 'app-ui',
  templateUrl: './ui.component.html',
  styleUrls: ['./ui.component.scss'],
  standalone: true,
  imports: [
    MatSlider,
    FormsModule,
    ColorPickerModule,
    MatSelectModule,
    MasterLayoutComponent
  ]
})
export class UiComponent implements OnInit {
  @ViewChild('console', { static: true }) private canvasRef: ElementRef | undefined;
  @ViewChild('canvasContainer', { static: true }) private canvasContainerRef: ElementRef | undefined;
  private _htmlConsole: HtmlConsole | undefined = undefined;
  private consoleConfiguration = new ConsoleConfiguration();

  /**
   * List of available color names.
   */
  public availableColorNames: string[];
  private resizeObserver!: ResizeObserver;
  public availableFontNames: string[];

  constructor(
  ) {
    // Generate all of the color names from the enum.
    const allColours = Object.values(ColorEnum).filter((_enum) => typeof (_enum) === "string") as string[];

    // We need to remove the background color.  It is not available for modification.
    this.availableColorNames = allColours.splice(1);
    this.availableFontNames = [
      "Courier",
      "Courier New",
      "Consolas",
      "Menlo",
      "Monaco",
      "Lucida Console",
      "DejaVu Sans Mono",
      "Liberation Mono",
      "Source Code Pro",
      "Arial",
      "Helvetica",
      "Segoe UI",
      "Verdana",
      "Tahoma",
      "Trebuchet MS",
      "Roboto",
      "Noto Sans",
      "Times New Roman",
      "Georgia",
      "Garamond",
      "Palatino",
      "Bookman"
    ];
    this.availableFontNames = this.availableFontNames.sort();
  }

  public refresh() {
    // Set the configuration, to our designer configuration.  The html console module automatically detectes the change and refreshes.
    this._htmlConsole!.consoleConfiguration = this.consoleConfiguration;
    this._htmlConsole?.drawAlignments();
  }

  public reset() {
    this.consoleConfiguration = new ConsoleConfiguration();
    this.refresh();
  }

  public get bold(): boolean {
    return this.consoleConfiguration.bold;
  }

  public set bold(value: boolean) {
    this.consoleConfiguration.bold = value;
    this.refresh();
  }

  public get fontName(): string {
    return this.consoleConfiguration.fontName;
  }

  public set fontName(value: string) {
    this.consoleConfiguration.fontName = value;
    this.refresh();
  }

  public get viewportWidth(): number {
    return this.consoleConfiguration.width;
  }

  public set viewportWidth(value: number) {
    this.consoleConfiguration.width = value;
    this.refresh();
  }

  public get viewportHeight(): number {
    return this.consoleConfiguration.height;
  }

  public set viewportHeight(value: number) {
    this.consoleConfiguration.height = value;
    this.refresh();
  }

  public getColor(index: number): string {
    return this.consoleConfiguration.colors[index + 1];
  }

  public setColor(index: number, color: string) {
    this.consoleConfiguration.colors[index + 1] = color;
    this.refresh();
  }

  ngOnInit(): void {
    // When the canvasRef is initialized, we can setup the HtmlConsole.
    if (this.canvasRef !== undefined) {
      this._htmlConsole = new HtmlConsole(this.canvasRef, this.consoleConfiguration);
    }

    // Track sizing on the canvas container.
    this.resizeObserver = new ResizeObserver(entries => {
      const maxDivWidth = this.canvasRef!.nativeElement.parentElement.parentElement.clientWidth;
      const maxDivHeight = this.canvasRef!.nativeElement.parentElement.parentElement.clientHeight;
      this.canvasRef!.nativeElement.parentElement.style.maxWidth = `${maxDivWidth}px`;
      this.canvasRef!.nativeElement.parentElement.style.maxHeight = `${maxDivHeight}px`;

      // Refresh the canvas.
      this.refresh();
    });
    this.resizeObserver.observe(this.canvasContainerRef?.nativeElement);

    // Draw the initial screen.
    this.refresh();
  }
}

