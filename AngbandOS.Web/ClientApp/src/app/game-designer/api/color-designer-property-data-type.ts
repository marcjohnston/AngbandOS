import { SelectListDesignerPropertyDataType } from "./select-list-designer-property-data-type";
import { SelectItem } from "./select-item";

export class ColorDesignerPropertyDataType extends SelectListDesignerPropertyDataType {
  public override name: string = "Color";
  public override render = "SelectList";
  public override options: SelectItem[] = [
    {
      text: "Background",
      value: "0",
      description: "Transparent"
    },
    {
      text: "Black",
      value: "1",
      description: "#2F4F4F"
    },
    {
      text: "Grey",
      value: "2",
      description: "#696969"
    },
    {
      text: "BrightGrey",
      value: "3",
      description: "#A9A9A9"
    },
    {
      text: "Silver",
      value: "4",
      description: "#778899"
    },
    {
      text: "Beige",
      value: "5",
      description: "#FFE4B5"
    },
    {
      text: "BrightBeige",
      value: "6",
      description: "#F5F5DC"
    },
    {
      text: "White",
      value: "7",
      description: "#D3D3D3"
    },
    {
      text: "BrightWhite",
      value: "8",
      description: "#FFFFFF"
    },
    {
      text: "Red",
      value: "9",
      description: "#8B0000"
    },
    {
      text: "BrightRed",
      value: "10",
      description: "#FF0000"
    },
    {
      text: "Copper",
      value: "11",
      description: "#D2691E"
    },
    {
      text: "Orange",
      value: "12",
      description: "#FF4500"
    },
    {
      text: "BrightOrange",
      value: "13",
      description: "#FFA500"
    },
    {
      text: "Brown",
      value: "14",
      description: "#8B4513"
    },
    {
      text: "BrightBrown",
      value: "15",
      description: "#DEB887"
    },
    {
      text: "Gold",
      value: "16",
      description: "#FFD700"
    },
    {
      text: "Yellow",
      value: "17",
      description: "#F0E68C"
    },
    {
      text: "BrightYellow",
      value: "18",
      description: "#FFFF00"
    },
    {
      text: "Chartreuse",
      value: "19",
      description: "#9ACD32"
    },
    {
      text: "BrightChartreuse",
      value: "20",
      description: "#7FFF00"
    },
    {
      text: "Green",
      value: "21",
      description: "#006400"
    },
    {
      text: "BrightGreen",
      value: "22",
      description: "#32CD32"
    },
    {
      text: "Turquoise",
      value: "23",
      description: "#00CED1"
    },
    {
      text: "BrightTurquoise",
      value: "24",
      description: "#00FFFF"
    },
    {
      text: "Blue",
      value: "25",
      description: "#0000CD"
    },
    {
      text: "BrightBlue",
      value: "26",
      description: "#00BFFF"
    },
    {
      text: "Diamond",
      value: "27",
      description: "#E0FFFF"
    },
    {
      text: "Purple",
      value: "28",
      description: "#800080"
    },
    {
      text: "BrightPurple",
      value: "29",
      description: "#EE82EE"
    },
    {
      text: "Pink",
      value: "30",
      description: "#FF1493"
    },
    {
      text: "BrightPink",
      value: "31",
      description: "#FF69B4"
    }
  ]
}
