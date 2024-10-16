import { Component, NgZone, OnInit } from '@angular/core';
import { ColorEnum } from '../modules/color-enum/color-enum.module';
import { StringDesignerPropertyDataType } from './api/string-designer-property-data-type';
import { BooleanDesignerPropertyDataType } from './api/boolean-designer-property-data-type';
import { ColorDesignerPropertyDataType } from './api/color-designer-property-data-type';
import { DiceRollDesignerPropertyDataType } from './api/dice-roll-designer-property-data-type';
import { IntegerDesignerPropertyDataType } from './api/integer-designer-property-data-type';
import { RepositoryDesignerPropertyDataType } from './api/repository-designer-property-data-type';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ErrorMessages } from '../modules/error-messages/error-messages.module';
import { PropertyMetadata } from './property-metadata';
import { TreeNode } from './tree-node';
import { PropertyMetadataAndConfiguration } from './property-metadata-and-configuration';
import { JsonPropertyMetadata } from './json-property-metadata';


@Component({
  selector: 'app-game-designer',
  templateUrl: './game-designer.component.html',
  styleUrls: ['./game-designer.component.scss']
})

export class GameDesignerComponent implements OnInit {
  public collections = new Map<string, string[]>();

  /**
   * The unverified metadata that has been received from the game controller.
   */
  private jsonPropertyMetadata: JsonPropertyMetadata[] | undefined = undefined;

  /**
   * The configuration object being worked on.
   */
  public configuration: any | undefined = undefined;

  /**
   * Returns the unmodified original configuration to detect changes.
   */
  public unmodifiedConfigurationAsJson: string | undefined = undefined;

  /**
   * The root tree nodes that are being rendered in the left panel.
   */
  public rootTreeNodes: TreeNode[] | undefined = undefined;

  /**
   * The property metadata and the configuration to be rendered on demand when the user clicks a tree node; null, if the user hasn't selected any tree node.
   */
  public activePropertyMetadataAndConfigurations: PropertyMetadataAndConfiguration[] | null = null;

  constructor(
    private _httpClient: HttpClient,
    private _ngZone: NgZone,
    private _snackBar: MatSnackBar
  ) { }

  validateJsonPropertyMetadata(jsonPropertyMetadata: JsonPropertyMetadata): PropertyMetadata | undefined {
    // Check that none of the properties are undefined.
    if (jsonPropertyMetadata.type === undefined) {
      return undefined;
    }
    if (jsonPropertyMetadata.propertyName === undefined) {
      return undefined;
    }
    if (jsonPropertyMetadata.title === undefined) {
      return undefined;
    }
    if (jsonPropertyMetadata.categoryTitle === undefined) {
      return undefined;
    }
    if (jsonPropertyMetadata.isNullable === undefined) {
      return undefined;
    }
    if (jsonPropertyMetadata.description === undefined) {
      return undefined;
    }
    if (jsonPropertyMetadata.defaultIntegerValue === undefined) {
      return undefined;
    }
    if (jsonPropertyMetadata.defaultBooleanValue === undefined) {
      return undefined;
    }
    if (jsonPropertyMetadata.defaultCharacterValue === undefined) {
      return undefined;
    }
    if (jsonPropertyMetadata.defaultStringValue === undefined) {
      return undefined;
    }
    if (jsonPropertyMetadata.defaultStringArrayValue === undefined) {
      return undefined;
    }
    if (jsonPropertyMetadata.tupleTypes === undefined) {
      return undefined;
    }
    if (jsonPropertyMetadata.collectionPropertyMetadatas === undefined) {
      return undefined;
    }
    if (jsonPropertyMetadata.collectionKeyPropertyName === undefined) {
      return undefined;
    }
    if (jsonPropertyMetadata.collectionEntityTitle === undefined) {
      return undefined;
    }
    if (jsonPropertyMetadata.foreignCollectionName === undefined) {
      return undefined;
    }

    // Now check for data types that require additional properties to not be null.
    let collectionPropertyMetadataList: PropertyMetadata[] | null = null;
    let tupleTypesPropertyMetadataList: PropertyMetadata[] | null = null;
    switch (jsonPropertyMetadata.type.toLowerCase()) {
      case "collection":
        if (jsonPropertyMetadata.collectionKeyPropertyName === null) {
          return undefined;
        }

        if (jsonPropertyMetadata.collectionPropertyMetadatas !== null) {
          collectionPropertyMetadataList = [];
          for (let jsonCollectionPropertyMetadata of jsonPropertyMetadata.collectionPropertyMetadatas) {
            const collectionPropertyMetadata: PropertyMetadata | undefined = this.validateJsonPropertyMetadata(jsonCollectionPropertyMetadata);
            if (collectionPropertyMetadata === undefined) {
              return undefined;
            }

            collectionPropertyMetadataList.push(collectionPropertyMetadata);
          }
        }
        break;
      case "tuple":
      case "tuple-array":
        if (jsonPropertyMetadata.tupleTypes !== null) {
          tupleTypesPropertyMetadataList = [];
          for (let jsonTupleTypePropertyMetadata of jsonPropertyMetadata.tupleTypes) {
            const tupleTypePropertyMetadata: PropertyMetadata | undefined = this.validateJsonPropertyMetadata(jsonTupleTypePropertyMetadata);
            if (tupleTypePropertyMetadata === undefined) {
              return undefined;
            }

            tupleTypesPropertyMetadataList.push(tupleTypePropertyMetadata);
          }
        }
        break;
    }

    return new PropertyMetadata(jsonPropertyMetadata.type,
      jsonPropertyMetadata.propertyName,
      jsonPropertyMetadata.title,
      jsonPropertyMetadata.categoryTitle,
      jsonPropertyMetadata.isNullable,
      jsonPropertyMetadata.description,
      jsonPropertyMetadata.defaultIntegerValue,
      jsonPropertyMetadata.defaultBooleanValue,
      jsonPropertyMetadata.defaultCharacterValue,
      jsonPropertyMetadata.defaultStringValue,
      jsonPropertyMetadata.defaultStringArrayValue,
      collectionPropertyMetadataList,
      tupleTypesPropertyMetadataList,
      jsonPropertyMetadata.collectionKeyPropertyName,
      jsonPropertyMetadata.collectionEntityTitle,
      jsonPropertyMetadata.foreignCollectionName);
  }

  initialize() {
    if (this.jsonPropertyMetadata !== undefined && this.configuration !== undefined) {
      const rootTreeNodes: TreeNode[] = [];
      const gameSettingsPropertyAndMetadataAndConfigurations: PropertyMetadataAndConfiguration[] = []; // We will need to build the game settings tree node manually.
      for (var jsonPropertyMetadata of this.jsonPropertyMetadata) {
        // We need to validate the json metadata before we can provide it to a tree node.
        const propertyMetadata = this.validateJsonPropertyMetadata(jsonPropertyMetadata);
        if (propertyMetadata === undefined) {
          this._snackBar.open("Invalid metadata.", "", {
            duration: 5000
          });
          return;
        }

        switch (propertyMetadata.type?.toLowerCase()) {
          case "collection":
            const entityTable: any[] = this.configuration[propertyMetadata.propertyName];
            const childTreeNodes: TreeNode[] = [];
            const collectionKeysArray: string[] = [];
            for (var entity of entityTable) {
              // Get the key value for the entity.
              const keyValue = entity[propertyMetadata.collectionKeyPropertyName!]; // collectionKeyPropertyName was already validated.

              // Build the child tree node.
              const childPropertyMetadataAndConfiguration = new PropertyMetadataAndConfiguration(propertyMetadata, entity);
              childTreeNodes.push(new TreeNode(keyValue, null, [childPropertyMetadataAndConfiguration]));

              // Add the key value to the collection keys array.  This array will be assigned to the collections Map that is used for foreign key references.
              collectionKeysArray.push(keyValue);
            }

            // This is the parent node, we are not rendering any children.
            const collectionPropertyMetadataAndConfiguration = new PropertyMetadataAndConfiguration(propertyMetadata, null);
            const collectionTreeNode = new TreeNode(propertyMetadata.propertyName, childTreeNodes, [collectionPropertyMetadataAndConfiguration]);
            rootTreeNodes.push(collectionTreeNode);

            // Add the keys to the Map of collections by the property name.
            this.collections.set(propertyMetadata.propertyName, collectionKeysArray);
            break;
          case "string-array":
              const stringArrayPropertyMetadataAndConfiguration = new PropertyMetadataAndConfiguration(propertyMetadata, this.configuration);
              const stringArrayTreeNode = new TreeNode(propertyMetadata.renderTitle, null, [stringArrayPropertyMetadataAndConfiguration]);
              rootTreeNodes.push(stringArrayTreeNode);
            break;
          default:
            const gameSettingPropertyAndMetadataConfiguration = new PropertyMetadataAndConfiguration(propertyMetadata, this.configuration);
            gameSettingsPropertyAndMetadataAndConfigurations.push(gameSettingPropertyAndMetadataConfiguration);
            break;
        }
      }

      // Sort the root tree nodes by title.
      rootTreeNodes.sort((treeNodeA, treeNodeB) => treeNodeA.title.localeCompare(treeNodeB.title));

      // Build the Game Settings tree node to place at the top of the tree.
      const gameSettingsTreeNode = new TreeNode("Game Settings", null, gameSettingsPropertyAndMetadataAndConfigurations);

      // Assign the list to comply with the Angular change detection assignment.
      this.rootTreeNodes = [gameSettingsTreeNode, ...rootTreeNodes]; 
    }
  }

  public get isModified(): boolean {
    return JSON.stringify(this.configuration) != this.unmodifiedConfigurationAsJson;
  }

  public treeNodeClicked(treeNode: TreeNode) {
    // Activate the tree node property metadata and configuration.
    this.activePropertyMetadataAndConfigurations = treeNode.propertyMetadataAndConfigurations;
  }

  ngOnInit(): void {
    this._httpClient.get<PropertyMetadata[]>(`/apiv1/configurations/metadata`).toPromise().then((_jsonMetadata) => {
      this._ngZone.run(() => {
        if (_jsonMetadata !== undefined) {
          this.jsonPropertyMetadata = _jsonMetadata;
          this.initialize();
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
          // Keep a reference to the configuration.
          this.configuration = _configuration;

          // Make a deep-copy of the configuration to detect changes.
          this.unmodifiedConfigurationAsJson = JSON.stringify(_configuration);
          this.initialize();
        }
      });
    }, (_errorResponse: HttpErrorResponse) => {
      this._snackBar.open(ErrorMessages.getMessage(_errorResponse).join('\n'), "", {
        duration: 5000
      });
    });
  }
}

