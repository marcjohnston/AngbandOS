import { Designer } from "./designer";
import { DesignerProperty } from "./designer-property";
import { RepositoryDesignerPropertyDataType } from "./repository-designer-property-data-type";

/**
 * Represents a designer for a customized game.
 */
export class GameDataDesigner implements Designer {
  public title: string = "Angband Game";
  public description: string = "Based from Cthangband.";
  public properties: DesignerProperty[] = [
    {
      title: "Activations",
      description: "Represents a power that can be assigned to a random artifact that can be activated.",
      propertyName: "activations",
      dataType: new RepositoryDesignerPropertyDataType([])
    },
    {
      title: "Alter Actions",
      description: "Represents an action that occurs when the player bumps into a feature.",
      propertyName: "alterActions",
      dataType: new RepositoryDesignerPropertyDataType([])
    },
    {
      title: "Animations",
      description: "Represents an animation that occurs when a projectile is launched.",
      propertyName: "animations",
      dataType: new RepositoryDesignerPropertyDataType([])
    },
    {
      title: "Artifact Biases",
      description: "",
      propertyName: "artifactBiases",
      dataType: new RepositoryDesignerPropertyDataType([])
    },
    {
      title: "Attacks",
      description: "",
      propertyName: "attacks",
      dataType: new RepositoryDesignerPropertyDataType([])
    },
    {
      title: "Birth Stages",
      description: "",
      propertyName: "birthStages",
      dataType: new RepositoryDesignerPropertyDataType([])
    },
    {
      title: "Casting Types",
      description: "",
      propertyName: "castingTypes",
      dataType: new RepositoryDesignerPropertyDataType([])
    },
    {
      title: "Character Classes",
      description: "",
      propertyName: "characterClasses",
      dataType: new RepositoryDesignerPropertyDataType([])
    },
    {
      title: "Chest Trap Configurations",
      description: "",
      propertyName: "chestTrapConfigurations",
      dataType: new RepositoryDesignerPropertyDataType([])
    },
    {
      title: "Chest Traps",
      description: "",
      propertyName: "chestTraps",
      dataType: new RepositoryDesignerPropertyDataType([])
    },
    {
      title: "Class Spells",
      description: "",
      propertyName: "classSpells",
      dataType: new RepositoryDesignerPropertyDataType([])
    },
    {
      title: "Dungeons",
      description: "",
      propertyName: "dungeons",
      dataType: new RepositoryDesignerPropertyDataType([])
    },
    {
      title: "Fixed Artifacts",
      description: "",
      propertyName: "fixedArtifacts",
      dataType: new RepositoryDesignerPropertyDataType([])
    },
    {
      title: "Flagged Actions",
      description: "",
      propertyName: "flaggedActions",
      dataType: new RepositoryDesignerPropertyDataType([])
    },
    {
      title: "Flavours",
      description: "",
      propertyName: "flavours",
      dataType: new RepositoryDesignerPropertyDataType([])
    },
    {
      title: "Game Commands",
      description: "",
      propertyName: "gameCommands",
      dataType: new RepositoryDesignerPropertyDataType([])
    },
    {
      title: "Genders",
      description: "",
      propertyName: "genders",
      dataType: new RepositoryDesignerPropertyDataType([])
    },
    {
      title: "Help Groups",
      description: "",
      propertyName: "helpGroups",
      dataType: new RepositoryDesignerPropertyDataType([])
    },
    {
      title: "Inventory Slots",
      description: "",
      propertyName: "inventorySlots",
      dataType: new RepositoryDesignerPropertyDataType([])
    },
    {
      title: "Item Classes",
      description: "",
      propertyName: "itemClasses",
      dataType: new RepositoryDesignerPropertyDataType([])
    },
    {
      title: "Items",
      description: "",
      propertyName: "items",
      dataType: new RepositoryDesignerPropertyDataType([])
    },
    {
      title: "Martial Arts Attacks",
      description: "",
      propertyName: "martialArtsAttacks",
      dataType: new RepositoryDesignerPropertyDataType([])
    },
    {
      title: "Monster Races",
      description: "",
      propertyName: "monsterRaces",
      dataType: new RepositoryDesignerPropertyDataType([])
    },
    {
      title: "Monster Spells",
      description: "",
      propertyName: "monsterSpells",
      dataType: new RepositoryDesignerPropertyDataType([])
    },
    {
      title: "Mutations",
      description: "",
      propertyName: "mutations",
      dataType: new RepositoryDesignerPropertyDataType([])
    },
    {
      title: "Patrons",
      description: "",
      propertyName: "patrons",
      dataType: new RepositoryDesignerPropertyDataType([])
    },
    {
      title: "Projectile Graphics",
      description: "",
      propertyName: "projectileGraphics",
      dataType: new RepositoryDesignerPropertyDataType([])
    },
    {
      title: "Projectiles",
      description: "",
      propertyName: "projectiles",
      dataType: new RepositoryDesignerPropertyDataType([])
    },
    {
      title: "Races",
      description: "",
      propertyName: "races",
      dataType: new RepositoryDesignerPropertyDataType([])
    },
    {
      title: "Rare Items",
      description: "",
      propertyName: "rareItems",
      dataType: new RepositoryDesignerPropertyDataType([])
    },
    {
      title: "Realms",
      description: "",
      propertyName: "realms",
      dataType: new RepositoryDesignerPropertyDataType([])
    },
    {
      title: "Rewards",
      description: "",
      propertyName: "rewards",
      dataType: new RepositoryDesignerPropertyDataType([])
    },
    {
      title: "Room Layouts",
      description: "",
      propertyName: "roomLayouts",
      dataType: new RepositoryDesignerPropertyDataType([])
    },
    {
      title: "Scripts",
      description: "",
      propertyName: "scripts",
      dataType: new RepositoryDesignerPropertyDataType([])
    },
    {
      title: "Spell Resistant Detections",
      description: "",
      propertyName: "spellResistantDetections",
      dataType: new RepositoryDesignerPropertyDataType([])
    },
    {
      title: "Spells",
      description: "",
      propertyName: "spells",
      dataType: new RepositoryDesignerPropertyDataType([])
    },
    {
      title: "Store Commands",
      description: "",
      propertyName: "storeCommands",
      dataType: new RepositoryDesignerPropertyDataType([])
    },
    {
      title: "Store Owners",
      description: "",
      propertyName: "storeOwners",
      dataType: new RepositoryDesignerPropertyDataType([])
    },
    {
      title: "Stores",
      description: "",
      propertyName: "stores",
      dataType: new RepositoryDesignerPropertyDataType([])
    },
    {
      title: "Symbols",
      description: "",
      propertyName: "symbols",
      dataType: new RepositoryDesignerPropertyDataType([])
    },
    {
      title: "Talents",
      description: "",
      propertyName: "talents",
      dataType: new RepositoryDesignerPropertyDataType([])
    },
    {
      title: "Tiles",
      description: "",
      propertyName: "tiles",
      dataType: new RepositoryDesignerPropertyDataType([])
    },
    {
      title: "Timed Actions",
      description: "",
      propertyName: "timedActions",
      dataType: new RepositoryDesignerPropertyDataType([])
    },
    {
      title: "Towns",
      description: "",
      propertyName: "towns",
      dataType: new RepositoryDesignerPropertyDataType([])
    },
    {
      title: "Vaults",
      description: "",
      propertyName: "vaults",
      dataType: new RepositoryDesignerPropertyDataType([])
    },
    {
      title: "Wizard Commands",
      description: "",
      propertyName: "wizardCommands",
      dataType: new RepositoryDesignerPropertyDataType([])
    }
  ]
}
