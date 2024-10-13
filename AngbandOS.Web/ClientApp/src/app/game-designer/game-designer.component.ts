import { Component, NgZone, OnInit } from '@angular/core';
import { ColorEnum } from '../modules/color-enum/color-enum.module';
import { StringDesignerPropertyDataType } from './api/string-designer-property-data-type';
import { BooleanDesignerPropertyDataType } from './api/boolean-designer-property-data-type';
import { ColorDesignerPropertyDataType } from './api/color-designer-property-data-type';
import { DiceRollDesignerPropertyDataType } from './api/dice-roll-designer-property-data-type';
import { IntegerDesignerPropertyDataType } from './api/integer-designer-property-data-type';
import { RepositoryDesignerPropertyDataType } from './api/repository-designer-property-data-type';
import { GameDataDesigner } from './api/game-data-designer';
import { SelectItem } from "./api/select-item";
import { Designer } from './api/designer';
import { DesignerProperty } from './api/designer-property';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ErrorMessages } from '../modules/error-messages/error-messages.module';
import { PropertyMetadata } from './PropertyMetadata';


@Component({
  selector: 'app-game-designer',
  templateUrl: './game-designer.component.html',
  styleUrls: ['./game-designer.component.scss']
})

export class GameDesignerComponent implements OnInit {
  public designer: Designer | undefined = undefined;
  public object: any | undefined = undefined;
  private metadata: any;
  public configuration: any;
  public propertiesDisplayedColumns: string[] = ["collection-title"];
  public collections: string[] = [];

  constructor(
    private _httpClient: HttpClient,
    private _ngZone: NgZone,
    private _snackBar: MatSnackBar
  ) { }

  loadMetadata(metadata: PropertyMetadata[]) {
    const collectionsList: string[] = [];
    for (var propertyMetadata of metadata) {
      if (propertyMetadata.propertyName === null) {
        this._snackBar.open("Property metadata contains a null PropertyName value.", "", {
          duration: 5000
        });
        return;
      }
      collectionsList.push(propertyMetadata.propertyName);
    }
    this.collections = collectionsList.sort();
    this.metadata = metadata;
  }

  ngOnInit(): void {
    // We preconfigure a top level game to be designed.
    this.designer = new GameDataDesigner();
    this.object = new CthangbandGameData();

    this._httpClient.get<PropertyMetadata[]>(`/apiv1/configurations/metadata`).toPromise().then((_metadata) => {
      this._ngZone.run(() => {
        if (_metadata !== undefined) {
          this.loadMetadata(_metadata);
        }
      });
    }, (_errorResponse: HttpErrorResponse) => {
      this._snackBar.open(ErrorMessages.getMessage(_errorResponse).join('\n'), "", {
        duration: 5000
      });
    });

    this._httpClient.get<any>(`/apiv1/configurations/default`).toPromise().then((_configuration) => {
      this._ngZone.run(() => {
        if (_configuration !== undefined) {
          this.configuration = _configuration;
        }
      });
    }, (_errorResponse: HttpErrorResponse) => {
      this._snackBar.open(ErrorMessages.getMessage(_errorResponse).join('\n'), "", {
        duration: 5000
      });
    });
  }

  onRepositoryAddClick(property: DesignerProperty) {
    // Cast the property into a repository property.  The Add button only applies to repository properties.
    const repositoryDataType: RepositoryDesignerPropertyDataType = property.dataType as RepositoryDesignerPropertyDataType;
    for (let item of repositoryDataType.items) {
      // Cast the item into the shape where we can access the selected property.
      const selectableItem = item as SelectItem;
      if (selectableItem.selected) {
        // Add the item value to the object value.
        this.object[property.propertyName].push(selectableItem.value);

        // Deselect the checkbox for the item.
        selectableItem.selected = false;
      }
    }
  }

  onRepositoryRemoveClick(property: DesignerProperty) {
  }
}

export class SampleData {
  public text: string | undefined = "sample text";
  public bool: boolean | undefined = false;
  public color: ColorEnum | undefined = ColorEnum.Blue;
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

/**
 * Represents the Cthangband preconfigured game.
 */
export class CthangbandGameData {
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


/**
 * Represents a designer object that represents a sample all of the various types of designable properties.
 */
export class SampleDataDesigner implements Designer {
  public title: string = "Sample Data";
  public description: string = "Represents a sample of each and every data type supported.";
  public properties: DesignerProperty[] = [
    {
      title: "Text",
      description: "An input field for text.",
      propertyName: "text",
      dataType: new StringDesignerPropertyDataType()
    },
    {
      title: "Boolean",
      description: "Radio buttons for true or false.",
      propertyName: "bool",
      dataType: new BooleanDesignerPropertyDataType()
    },
    {
      title: "Color",
      description: "Returns the color that monsters of this race will be rendered.",
      propertyName: "color",
      dataType: new ColorDesignerPropertyDataType()
    },
    {
      title: "Dice Roll",
      description: "Returns the a random chance value.",
      propertyName: "diceRoll",
      dataType: new DiceRollDesignerPropertyDataType()
    },
    {
      title: "Integer",
      description: "An input box that only accepts numbers.",
      propertyName: "int",
      dataType: new IntegerDesignerPropertyDataType()
    },
    {
      title: "Repository",
      description: "Allows zero or more items from a fixed repository to be selected.",
      propertyName: "repo",
      dataType: new RepositoryDesignerPropertyDataType([{
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
