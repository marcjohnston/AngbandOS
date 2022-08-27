import { ColourEnum } from "../colour-enum/colour-enum.module";

export class ColoursMap {
  public static getColoursMap(): string[] {
    const colours: string[] = [];
    colours[ColourEnum.Background] = "#000000";
    colours[ColourEnum.Black] = "#2F4F4F";
    colours[ColourEnum.Grey] = "#696969";
    colours[ColourEnum.BrightGrey] = "#A9A9A9";
    colours[ColourEnum.Silver] = "#778899";
    colours[ColourEnum.Beige] = "#FFE4B5";
    colours[ColourEnum.BrightBeige] = "#F5F5DC";
    colours[ColourEnum.White] = "#D3D3D3";
    colours[ColourEnum.BrightWhite] = "#FFFFFF";
    colours[ColourEnum.Red] = "#8B0000";
    colours[ColourEnum.BrightRed] = "#FF0000";
    colours[ColourEnum.Copper] = "#D2691E";
    colours[ColourEnum.Orange] = "#FF4500";
    colours[ColourEnum.BrightOrange] = "#FFA500";
    colours[ColourEnum.Brown] = "#8B4513";
    colours[ColourEnum.BrightBrown] = "#DEB887";
    colours[ColourEnum.Gold] = "#FFD700";
    colours[ColourEnum.Yellow] = "#F0E68C";
    colours[ColourEnum.BrightYellow] = "#FFFF00";
    colours[ColourEnum.Chartreuse] = "#9ACD32";
    colours[ColourEnum.BrightChartreuse] = "#7FFF00";
    colours[ColourEnum.Green] = "#006400";
    colours[ColourEnum.BrightGreen] = "#32CD32";
    colours[ColourEnum.Turquoise] = "#00CED1";
    colours[ColourEnum.BrightTurquoise] = "#00FFFF";
    colours[ColourEnum.Blue] = "#0000CD";
    colours[ColourEnum.BrightBlue] = "#00BFFF";
    colours[ColourEnum.Diamond] = "#E0FFFF";
    colours[ColourEnum.Purple] = "#800080";
    colours[ColourEnum.BrightPurple] = "#EE82EE";
    colours[ColourEnum.Pink] = "#FF1493";
    colours[ColourEnum.BrightPink] = "#FF69B4";
    return colours;
  }
}
