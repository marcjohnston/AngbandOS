import { ColorEnum } from "../color-enum/color-enum.module";

export class ColorsMap {
  public static getColorsMap(): string[] {
    const colors: string[] = [];
    colors[ColorEnum.Background] = "#000000";
    colors[ColorEnum.Black] = "#2F4F4F";
    colors[ColorEnum.Grey] = "#696969";
    colors[ColorEnum.BrightGrey] = "#A9A9A9";
    colors[ColorEnum.Silver] = "#778899";
    colors[ColorEnum.Beige] = "#FFE4B5";
    colors[ColorEnum.BrightBeige] = "#F5F5DC";
    colors[ColorEnum.White] = "#D3D3D3";
    colors[ColorEnum.BrightWhite] = "#FFFFFF";
    colors[ColorEnum.Red] = "#8B0000";
    colors[ColorEnum.BrightRed] = "#FF0000";
    colors[ColorEnum.Copper] = "#D2691E";
    colors[ColorEnum.Orange] = "#FF4500";
    colors[ColorEnum.BrightOrange] = "#FFA500";
    colors[ColorEnum.Brown] = "#8B4513";
    colors[ColorEnum.BrightBrown] = "#DEB887";
    colors[ColorEnum.Gold] = "#FFD700";
    colors[ColorEnum.Yellow] = "#F0E68C";
    colors[ColorEnum.BrightYellow] = "#FFFF00";
    colors[ColorEnum.Chartreuse] = "#9ACD32";
    colors[ColorEnum.BrightChartreuse] = "#7FFF00";
    colors[ColorEnum.Green] = "#006400";
    colors[ColorEnum.BrightGreen] = "#32CD32";
    colors[ColorEnum.Turquoise] = "#00CED1";
    colors[ColorEnum.BrightTurquoise] = "#00FFFF";
    colors[ColorEnum.Blue] = "#0000CD";
    colors[ColorEnum.BrightBlue] = "#00BFFF";
    colors[ColorEnum.Diamond] = "#E0FFFF";
    colors[ColorEnum.Purple] = "#800080";
    colors[ColorEnum.BrightPurple] = "#EE82EE";
    colors[ColorEnum.Pink] = "#FF1493";
    colors[ColorEnum.BrightPink] = "#FF69B4";
    return colors;
  }
}
