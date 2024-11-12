import { Component, NgZone, OnInit } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ErrorMessages } from '../modules/error-messages/error-messages.module';
import { PropertyMetadata } from './property-metadata';
import { TreeNode } from './tree-node';
import { PropertyMetadataAndConfiguration } from './property-metadata-and-configuration';
import { JsonPropertyMetadata } from './json-property-metadata';
import { getEntityName } from './game-designer-library.module';
import { convertToTitleCase } from '../modules/strings-library/strings-library.module';


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
    if (jsonPropertyMetadata.propertyName === undefined) {
      this._snackBar.open(`Metadata property name is invalid after json deserialization.`, "", {
        duration: 5000
      });
      return undefined;
    }
    if (jsonPropertyMetadata.type === undefined) {
      this._snackBar.open(`Metadata property ${jsonPropertyMetadata.propertyName} has an invalid type value after json deserialization.`, "", {
        duration: 5000
      });
      return undefined;
    }
    if (jsonPropertyMetadata.title === undefined) {
      this._snackBar.open(`Metadata property ${jsonPropertyMetadata.propertyName} has an invalid title value after json deserialization.`, "", {
        duration: 5000
      });
      return undefined;
    }
    if (jsonPropertyMetadata.categoryTitle === undefined) {
      this._snackBar.open(`Metadata property ${jsonPropertyMetadata.propertyName} has an invalid category title value after json deserialization.`, "", {
        duration: 5000
      });
      return undefined;
    }
    if (jsonPropertyMetadata.isNullable === undefined) {
      this._snackBar.open(`Metadata property ${jsonPropertyMetadata.propertyName} has an invalid isNullable value after json deserialization.`, "", {
        duration: 5000
      });
      return undefined;
    }
    if (jsonPropertyMetadata.description === undefined) {
      this._snackBar.open(`Metadata property ${jsonPropertyMetadata.propertyName} has an invalid description value after json deserialization.`, "", {
        duration: 5000
      });
      return undefined;
    }
    if (jsonPropertyMetadata.defaultValue === undefined) {
      this._snackBar.open(`Metadata property ${jsonPropertyMetadata.propertyName} has an invalid defaultValue value after json deserialization.`, "", {
        duration: 5000
      });
      return undefined;
    }
    if (jsonPropertyMetadata.propertyMetadatas === undefined) {
      this._snackBar.open(`Metadata property ${jsonPropertyMetadata.propertyName} has an invalid propertyMetadatas value after json deserialization.`, "", {
        duration: 5000
      });
      return undefined;
    }
    if (jsonPropertyMetadata.entityKeyPropertyName === undefined) {
      this._snackBar.open(`Metadata property ${jsonPropertyMetadata.propertyName} has an invalid entityKeyPropertyName value after json deserialization.`, "", {
        duration: 5000
      });
      return undefined;
    }
    if (jsonPropertyMetadata.entityNamePropertyName === undefined) {
      this._snackBar.open(`Metadata property ${jsonPropertyMetadata.propertyName} has an invalid entityNamePropertyName value after json deserialization.`, "", {
        duration: 5000
      });
      return undefined;
    }
    if (jsonPropertyMetadata.entityNounTitle === undefined) {
      this._snackBar.open(`Metadata property ${jsonPropertyMetadata.propertyName} has an invalid entityTitle value after json deserialization.`, "", {
        duration: 5000
      });
      return undefined;
    }
    if (jsonPropertyMetadata.entityNoun === undefined) {
      this._snackBar.open(`Metadata property ${jsonPropertyMetadata.propertyName} has an invalid entityName value after json deserialization.`, "", {
        duration: 5000
      });
      return undefined;
    }
    if (jsonPropertyMetadata.foreignCollectionName === undefined) {
      this._snackBar.open(`Metadata property ${jsonPropertyMetadata.propertyName} has an invalid foreignCollectionName value after json deserialization.`, "", {
        duration: 5000
      });
      return undefined;
    }

    // Now check for data types that require additional properties to not be null.
    // Validate that entityKeyPropertyName is not null.
    switch (jsonPropertyMetadata.type) {
      case "collection":
        if (jsonPropertyMetadata.entityKeyPropertyName === null) {
          this._snackBar.open(`Collection metadata property ${jsonPropertyMetadata.propertyName} has an null entityKeyPropertyName value.`, "", {
            duration: 5000
          });
          return undefined;
        }
        break;
    }

    // Validate that foreignCollectionName is not null.
    switch (jsonPropertyMetadata.type) {
      case "foreign-key":
      case "foreign-keys":
        if (jsonPropertyMetadata.foreignCollectionName === null) {
          this._snackBar.open(`Collection metadata property ${jsonPropertyMetadata.propertyName} has an null foreignCollectionName value.`, "", {
            duration: 5000
          });
          return undefined;
        }
        break;
    }

    // Validate that propertyMetadatas is not null.
    let collectionPropertyMetadataList: PropertyMetadata[] | null = null;
    switch (jsonPropertyMetadata.type) {
      case "collection":
      case "tuple":
      case "tuples":
        if (jsonPropertyMetadata.propertyMetadatas !== null) {
          collectionPropertyMetadataList = [];
          for (let jsonCollectionPropertyMetadata of jsonPropertyMetadata.propertyMetadatas) {
            const collectionPropertyMetadata: PropertyMetadata | undefined = this.validateJsonPropertyMetadata(jsonCollectionPropertyMetadata);
            if (collectionPropertyMetadata === undefined) {
              this._snackBar.open(`Collection metadata property ${jsonPropertyMetadata.propertyName} has an null propertyMetadatas element value.`, "", {
                duration: 5000
              });
              return undefined;
            }

            collectionPropertyMetadataList.push(collectionPropertyMetadata);
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
      jsonPropertyMetadata.defaultValue,
      collectionPropertyMetadataList,
      jsonPropertyMetadata.entityKeyPropertyName,
      jsonPropertyMetadata.entityNamePropertyName,
      jsonPropertyMetadata.entityNounTitle,
      jsonPropertyMetadata.entityNoun,
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
          return;
        }

        switch (propertyMetadata.type) {
          case "collection":
            const entityTable: any[] | null = this.configuration[propertyMetadata.propertyName];
            if (entityTable === null) {
              this._snackBar.open(`The ${propertyMetadata.propertyName} collection does not exist in the configuration.`, "", {
                duration: 5000
              });
              return;
            }
            const childTreeNodes: TreeNode[] = [];
            const collectionKeysArray: string[] = [];
            for (var entity of entityTable) {
              // Get the key value for the entity.
              const keyValue = entity[propertyMetadata.entityKeyPropertyName!]; // collectionKeyPropertyName was already validated.

              // Now generate the entity name for the tree node title.
              const entityName = getEntityName(propertyMetadata, entity);

              // Build the child tree node for each entity of the collection.
              const childPropertyMetadataAndConfiguration = new PropertyMetadataAndConfiguration(propertyMetadata, entity);
              childTreeNodes.push(new TreeNode(entityName, null, [childPropertyMetadataAndConfiguration]));

              // Add the key value to the collection keys array.  This array will be assigned to the collections Map that is used for foreign key references.
              collectionKeysArray.push(keyValue);
            }

            // This is the parent node, we are not rendering any children.
            const collectionPropertyMetadataAndConfiguration = new PropertyMetadataAndConfiguration(propertyMetadata, entityTable); // This is the parent node with no children (null).
            const collectionTreeNode = new TreeNode(propertyMetadata.title!, childTreeNodes, [collectionPropertyMetadataAndConfiguration]);
            rootTreeNodes.push(collectionTreeNode);

            // Add the keys to the Map of collections by the property name.
            this.collections.set(propertyMetadata.propertyName, collectionKeysArray);
            break;
          case "strings":
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
    this._httpClient.get<JsonPropertyMetadata[]>(`/apiv1/configurations/metadata`).toPromise().then((_jsonMetadata) => {
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

