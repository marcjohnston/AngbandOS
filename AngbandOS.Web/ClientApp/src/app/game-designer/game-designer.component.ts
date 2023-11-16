import { Component, OnInit } from '@angular/core';
import { ColourEnum } from '../modules/colour-enum/colour-enum.module';

@Component({
  selector: 'app-game-designer',
  templateUrl: './game-designer.component.html',
  styleUrls: ['./game-designer.component.scss']
})

export class GameDesignerComponent implements OnInit {
  public designer: IDesigner | undefined = undefined;
  public object: any | undefined = undefined;
  public propertiesDisplayedColumns: string[] = ["property-name", "property-data-type", "property-value"];
  constructor() { }

  ngOnInit(): void {
    this.designer = new GameDataDesigner();
    this.object = new SampleGameData();
  }

  onRepositoryAddClick(property: IDesignerProperty) {
    // Cast the property into a repository property.  The Add button only applies to repository properties.
    const repositoryDataType: RepositoryPropertyDataType = property.dataType as RepositoryPropertyDataType;
    for (let item of repositoryDataType.items) {
      // Cast the item into the shape where we can access the selected property.
      const selectableItem = item as ISelectableItem;
      if (selectableItem.selected) {
        // Add the item value to the object value.
        this.object[property.propertyName].push(selectableItem.value);

        // Deselect the checkbox for the item.
        selectableItem.selected = false;
      }
    }
  }

  onRepositoryRemoveClick(property: IDesignerProperty) {
  }
}

interface ISelectableItem {
  text: string;
  value: string;
  description: string | undefined;
  selected: boolean | undefined;
}

interface IDesigner {
  title: string;
  description: string;
  properties: IDesignerProperty[];
}

export class SampleData {
  public text: string | undefined = "sample text";
  public bool: boolean | undefined = false;
  public color: ColourEnum | undefined = ColourEnum.Blue;
  public diceRoll: IRandom | undefined = {
    dice: 2,
    sides: 4,
    bonus: 5
  };
  public int: number | undefined = 10;
  public repo: string[] | undefined = [
    "BreatheAcidSpell",
    "BreatheColdSpell",
    "BreatheFireSpell"
  ]
}

interface IRandom {
  dice: number;
  sides: number;
  bonus: number;
}

export class SampleGameData {
  public activations: string[] | undefined = undefined;
  public alterActions: string[] | undefined = undefined;
  public animations: string[] | undefined = undefined;
  public artifactBiases: string[] | undefined = undefined;
  public attacks: string[] | undefined = undefined;
  public birthStages: string[] | undefined = undefined;
  public castingTypes: string[] | undefined = undefined;
  public characterClasses: string[] | undefined = undefined;
  public chestTrapConfigurations: string[] | undefined = undefined;
  public chestTraps: string[] | undefined = undefined;
  public classSpells: string[] | undefined = undefined;
  public dungeons: string[] | undefined = undefined;
  public fixedArtifacts: string[] | undefined = undefined;
  public flaggedActions: string[] | undefined = undefined;
  public flavours: string[] | undefined = undefined;
  public gameCommands: string[] | undefined = undefined;
  public genders: string[] | undefined = undefined;
  public helpGroups: string[] | undefined = undefined;
  public inventorySlots: string[] | undefined = undefined;
  public itemClasses: string[] | undefined = undefined;
  public items: string[] | undefined = undefined;
  public martialArtsAttacks: string[] | undefined = undefined;
  public monsterRaces: string[] | undefined = undefined;
  public monsterSpells: string[] | undefined = undefined;
  public mutations: string[] | undefined = undefined;
  public patrons: string[] | undefined = undefined;
  public projectileGraphics: string[] | undefined = undefined;
  public projectiles: string[] | undefined = undefined;
  public races: string[] | undefined = undefined;
  public rareItems: string[] | undefined = undefined;
  public realms: string[] | undefined = undefined;
  public rewards: string[] | undefined = undefined;
  public roomLayouts: string[] | undefined = undefined;
  public scripts: string[] | undefined = undefined;
  public spellResistantDetections: string[] | undefined = undefined;
  public spells: string[] | undefined = undefined;
  public storeCommands: string[] | undefined = undefined;
  public storeOwners: string[] | undefined = undefined;
  public stores: string[] | undefined = undefined;
  public symbols: string[] | undefined = undefined;
  public talents: string[] | undefined = undefined;
  public tiles: string[] | undefined = undefined;
  public timedActions: string[] | undefined = undefined;
  public towns: string[] | undefined = undefined;
  public vaults: string[] | undefined = undefined;
  public wizardCommands: string[] | undefined = undefined;
}

export class GameDataDesigner implements IDesigner {
  public title: string = "Angband Game";
  public description: string = "Based from Cthangband.";
  public properties: IDesignerProperty[] = [
    {
      title: "Activations",
      description: "Represents a power that can be assigned to a random artifact that can be activated.",
      propertyName: "activations",
      dataType: new RepositoryPropertyDataType([])
    },
    {
      title: "Alter Actions",
      description: "Represents an action that occurs when the player bumps into a feature.",
      propertyName: "alterActions",
      dataType: new RepositoryPropertyDataType([])
    },
    {
      title: "Animations",
      description: "Represents an animation that occurs when a projectile is launched.",
      propertyName: "animations",
      dataType: new RepositoryPropertyDataType([])
    },
    {
      title: "Artifact Biases",
      description: "",
      propertyName: "artifactBiases",
      dataType: new RepositoryPropertyDataType([])
    },
    {
      title: "Attacks",
      description: "",
      propertyName: "attacks",
      dataType: new RepositoryPropertyDataType([])
    },
    {
      title: "Birth Stages",
      description: "",
      propertyName: "birthStages",
      dataType: new RepositoryPropertyDataType([])
    },
    {
      title: "Casting Types",
      description: "",
      propertyName: "castingTypes",
      dataType: new RepositoryPropertyDataType([])
    },
    {
      title: "Character Classes",
      description: "",
      propertyName: "characterClasses",
      dataType: new RepositoryPropertyDataType([])
    },
    {
      title: "Chest Trap Configurations",
      description: "",
      propertyName: "chestTrapConfigurations",
      dataType: new RepositoryPropertyDataType([])
    },
    {
      title: "Chest Traps",
      description: "",
      propertyName: "chestTraps",
      dataType: new RepositoryPropertyDataType([])
    },
    {
      title: "Class Spells",
      description: "",
      propertyName: "classSpells",
      dataType: new RepositoryPropertyDataType([])
    },
    {
      title: "Dungeons",
      description: "",
      propertyName: "dungeons",
      dataType: new RepositoryPropertyDataType([])
    },
    {
      title: "Fixed Artifacts",
      description: "",
      propertyName: "fixedArtifacts",
      dataType: new RepositoryPropertyDataType([])
    },
    {
      title: "Flagged Actions",
      description: "",
      propertyName: "flaggedActions",
      dataType: new RepositoryPropertyDataType([])
    },
    {
      title: "Flavours",
      description: "",
      propertyName: "flavours",
      dataType: new RepositoryPropertyDataType([])
    },
    {
      title: "Game Commands",
      description: "",
      propertyName: "gameCommands",
      dataType: new RepositoryPropertyDataType([])
    },
    {
      title: "Genders",
      description: "",
      propertyName: "genders",
      dataType: new RepositoryPropertyDataType([])
    },
    {
      title: "Help Groups",
      description: "",
      propertyName: "helpGroups",
      dataType: new RepositoryPropertyDataType([])
    },
    {
      title: "Inventory Slots",
      description: "",
      propertyName: "inventorySlots",
      dataType: new RepositoryPropertyDataType([])
    },
    {
      title: "Item Classes",
      description: "",
      propertyName: "itemClasses",
      dataType: new RepositoryPropertyDataType([])
    },
    {
      title: "Items",
      description: "",
      propertyName: "items",
      dataType: new RepositoryPropertyDataType([])
    },
    {
      title: "Martial Arts Attacks",
      description: "",
      propertyName: "martialArtsAttacks",
      dataType: new RepositoryPropertyDataType([])
    },
    {
      title: "Monster Races",
      description: "",
      propertyName: "monsterRaces",
      dataType: new RepositoryPropertyDataType([])
    },
    {
      title: "Monster Spells",
      description: "",
      propertyName: "monsterSpells",
      dataType: new RepositoryPropertyDataType([])
    },
    {
      title: "Mutations",
      description: "",
      propertyName: "mutations",
      dataType: new RepositoryPropertyDataType([])
    },
    {
      title: "Patrons",
      description: "",
      propertyName: "patrons",
      dataType: new RepositoryPropertyDataType([])
    },
    {
      title: "Projectile Graphics",
      description: "",
      propertyName: "projectileGraphics",
      dataType: new RepositoryPropertyDataType([])
    },
    {
      title: "Projectiles",
      description: "",
      propertyName: "projectiles",
      dataType: new RepositoryPropertyDataType([])
    },
    {
      title: "Races",
      description: "",
      propertyName: "races",
      dataType: new RepositoryPropertyDataType([])
    },
    {
      title: "Rare Items",
      description: "",
      propertyName: "rareItems",
      dataType: new RepositoryPropertyDataType([])
    },
    {
      title: "Realms",
      description: "",
      propertyName: "realms",
      dataType: new RepositoryPropertyDataType([])
    },
    {
      title: "Rewards",
      description: "",
      propertyName: "rewards",
      dataType: new RepositoryPropertyDataType([])
    },
    {
      title: "Room Layouts",
      description: "",
      propertyName: "roomLayouts",
      dataType: new RepositoryPropertyDataType([])
    },
    {
      title: "Scripts",
      description: "",
      propertyName: "scripts",
      dataType: new RepositoryPropertyDataType([])
    },
    {
      title: "Spell Resistant Detections",
      description: "",
      propertyName: "spellResistantDetections",
      dataType: new RepositoryPropertyDataType([])
    },
    {
      title: "Spells",
      description: "",
      propertyName: "spells",
      dataType: new RepositoryPropertyDataType([])
    },
    {
      title: "Store Commands",
      description: "",
      propertyName: "storeCommands",
      dataType: new RepositoryPropertyDataType([])
    },
    {
      title: "Store Owners",
      description: "",
      propertyName: "storeOwners",
      dataType: new RepositoryPropertyDataType([])
    },
    {
      title: "Stores",
      description: "",
      propertyName: "stores",
      dataType: new RepositoryPropertyDataType([])
    },
    {
      title: "Symbols",
      description: "",
      propertyName: "symbols",
      dataType: new RepositoryPropertyDataType([])
    },
    {
      title: "Talents",
      description: "",
      propertyName: "talents",
      dataType: new RepositoryPropertyDataType([])
    },
    {
      title: "Tiles",
      description: "",
      propertyName: "tiles",
      dataType: new RepositoryPropertyDataType([])
    },
    {
      title: "Timed Actions",
      description: "",
      propertyName: "timedActions",
      dataType: new RepositoryPropertyDataType([])
    },
    {
      title: "Towns",
      description: "",
      propertyName: "towns",
      dataType: new RepositoryPropertyDataType([])
    },
    {
      title: "Vaults",
      description: "",
      propertyName: "vaults",
      dataType: new RepositoryPropertyDataType([])
    },
    {
      title: "Wizard Commands",
      description: "",
      propertyName: "wizardCommands",
      dataType: new RepositoryPropertyDataType([])
    }
  ]
}

export class SampleDataDesigner implements IDesigner {
  public title: string = "Sample Data";
  public description: string = "Represents a sample of each and every data type supported.";
  public properties: IDesignerProperty[] = [
    {
      title: "Text",
      description: "An input field for text.",
      propertyName: "text",
      dataType: new StringPropertyDataType()
    },
    {
      title: "Boolean",
      description: "Radio buttons for true or false.",
      propertyName: "bool",
      dataType: new BooleanPropertyDataType()
    },
    {
      title: "Color",
      description: "Returns the color that monsters of this race will be rendered.",
      propertyName: "color",
      dataType: new ColorPropertyDataType()
    },
    {
      title: "Dice Roll",
      description: "Returns the a random chance value.",
      propertyName: "diceRoll",
      dataType: new DiceRollPropertyDataType()
    },
    {
      title: "Integer",
      description: "An input box that only accepts numbers.",
      propertyName: "int",
      dataType: new IntegerPropertyDataType()
    },
    {
      title: "Repository",
      description: "Allows zero or more items from a fixed repository to be selected.",
      propertyName: "repo",
      dataType: new RepositoryPropertyDataType([{
          text: "Breathe Acid",
          value: "BreatheAcidSpell",
          description: "A spell that grants the ability to breathe acid."
        },
        {
          text: "Breathe Cold",
          value: "BreatheColdSpell",
          description: "A spell that grants the ability to breathe cold."
        },
        {
          text: "Breathe Fire",
          value: "BreatheFireSpell",
          description: "A spell that grants the ability to breathe fire."
        },
        {
          text: "Breathe Lightning",
          value: "BreatheLightningSpell",
          description: "A spell that grants the ability to breathe lightning."
        },
        {
          text: "Breathe Poison",
          value: "BreathePoisonSpell",
          description: "A spell that grants the ability to breathe poison."
        },
        {
          text: "Breathe Chaos",
          value: "BreatheChaosSpell",
          description: "A spell that grants the ability to breathe chaos."
        },
        {
          text: "Breathe Confusion",
          value: "BreatheConfusionSpell",
          description: "A spell that grants the ability to breathe confusion."
        },
        {
          text: "Breathe Dark",
          value: "BreatheDarkSpell",
          description: "A spell that grants the ability to breathe dark."
        },
        {
          text: "Breathe Sound",
          value: "BreatheSoundSpell",
          description: "A spell that grants the ability to breathe sound."
        },
        {
          text: "Breathe Force",
          value: "BreatheForceSpell",
          description: "A spell that grants the ability to breathe force."
        },
        {
          text: "Breathe Shards",
          value: "BreatheShardsSpell",
          description: "A spell that grants the ability to breathe shards."
        },
        {
          text: "Breathe Gravity",
          value: "BreatheGravitySpell",
          description: "A spell that grants the ability to breathe gravity."
        },
        {
          text: "Breathe Inertia",
          value: "BreatheInertiaSpell",
          description: "A spell that grants the ability to breathe inertia."
        },
        {
          text: "Breathe Time",
          value: "BreatheTimeSpell",
          description: "A spell that grants the ability to breathe time."
        },
        {
          text: "Breathe Self",
          value: "BreatheSelfSpell",
          description: "A spell that grants the ability to breathe self."
        }])
    }
  ]
}

interface IDesignerProperty {
  /**
   * Returns the text for the title of the property to be rendered to the user.  In most cases, this title should be the same as the property name.
   */
  title: string;

  /**
   * Returns a long description to indicate more details about the property to the user.
   */
  description: string;

  /**
   * Returns the name of the property.  This property name is used to read and write the value in the target object.
   */
  propertyName: string;

  dataType: PropertyDataType;
}

export abstract class PropertyDataType {
  public abstract name: string;
  public abstract render: string;
}

export class RepositoryPropertyDataType extends PropertyDataType {
  constructor(items: IItem[]) {
    super();
    this.items = items;
  }
  public override name: string = "Repository";
  public override render = "Repository";
  public readonly items: IItem[];
}

export class DiceRollPropertyDataType extends PropertyDataType {
  public override name: string = "Dice Roll";
  public override render = "DiceRoll";
}

export class StringPropertyDataType extends PropertyDataType {
  public override name: string = "String";
  public override render = "String";
}

export class BooleanPropertyDataType extends PropertyDataType {
  public override name: string = "Boolean";
  public override render = "Boolean";
}

export class IntegerPropertyDataType extends PropertyDataType {
  public override name: string = "Integer";
  public override render = "Integer";
}

export abstract class SelectListPropertyDataType extends PropertyDataType {
  public override name: string = "Select List";
  public override render = "SelectList";
  public abstract options: IItem[];
}

interface IItem {
  text: string;
  value: string;
  description: string | undefined;
}

export class ColorPropertyDataType extends SelectListPropertyDataType {
  public override name: string = "Color";
  public override render = "SelectList";
  public override options: IItem[] = [
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
