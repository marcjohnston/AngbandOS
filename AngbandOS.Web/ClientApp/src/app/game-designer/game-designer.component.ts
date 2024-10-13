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
  private metadata: PropertyMetadata[] | undefined = undefined;
  public configuration: any | undefined = undefined;
  public rootTreeNode: TreeNode | undefined = undefined;
  public panelPropertyMetadata: PropertyMetadata | null = null;
  public panelConfiguration: any | null = null;

  constructor(
    private _httpClient: HttpClient,
    private _ngZone: NgZone,
    private _snackBar: MatSnackBar
  ) { }

  initialize() {
    if (this.metadata !== undefined && this.configuration !== undefined) {
      const childTreeNodes: TreeNode[] = [];
      for (var propertyMetadata of this.metadata) {
        if (propertyMetadata.type === undefined) {
          this._snackBar.open("Property metadata contains an invalid type value.", "", {
            duration: 5000
          });
          return;
        }

        switch (propertyMetadata.type?.toLowerCase()) {
          case "collection":
            const collectionPropertyTreeNode: TreeNode | undefined = this.buildCollectionTree(propertyMetadata, this.configuration);
            if (collectionPropertyTreeNode !== undefined) {
              childTreeNodes.push(collectionPropertyTreeNode);
            }
            break;
          case "string":
            if (propertyMetadata.isArray) {
              const stringPropertyTreeNode: TreeNode | undefined = this.buildStringArrayTree(propertyMetadata, this.configuration);
              if (stringPropertyTreeNode !== undefined) {
                childTreeNodes.push(stringPropertyTreeNode);
              }
            }
            break;
        }
      }
      this.rootTreeNode = new TreeNode("", childTreeNodes);
    }
  }

  buildCollectionTree(propertyMetadata: PropertyMetadata, configuration: any): TreeNode | undefined {
    if (propertyMetadata.propertyName === undefined) {
      this._snackBar.open("Property metadata contains an invalid type value.", "", {
        duration: 5000
      });
      return undefined;
    }
    if (propertyMetadata.collectionKeyPropertyName === undefined || propertyMetadata.collectionKeyPropertyName === null) {
      this._snackBar.open("Property metadata contains an invalid collection key property name value.", "", {
        duration: 5000
      });
      return undefined;
    }

    const entityTable: any[] = configuration[propertyMetadata.propertyName];
    const childTreeNodes: TreeNode[] = [];
    for (var entity of entityTable) {
      const keyValue = entity[propertyMetadata.collectionKeyPropertyName];
      childTreeNodes.push(new TreeNode(keyValue, null));
    }
    return new TreeNode(propertyMetadata.propertyName, childTreeNodes);
  }

  buildStringArrayTree(propertyMetadata: PropertyMetadata, configuration: any): TreeNode | undefined {
    if (propertyMetadata.propertyName === undefined) {
      this._snackBar.open("Property metadata contains an invalid type value.", "", {
        duration: 5000
      });
      return undefined;
    }

    const stringTable: string[] = configuration[propertyMetadata.propertyName];
    const childTreeNodes: TreeNode[] = [];
    for (var text of stringTable) {
      childTreeNodes.push(new TreeNode(text, null));
    }
    return new TreeNode(propertyMetadata.propertyName, childTreeNodes);
  }

  public treeNodeClicked(treeNode: TreeNode) {
    //this.panelPropertyMetadata = this.metadata;
  }

  ngOnInit(): void {
    this._httpClient.get<PropertyMetadata[]>(`/apiv1/configurations/metadata`).toPromise().then((_metadata) => {
      this._ngZone.run(() => {
        if (_metadata !== undefined) {
          this.metadata = _metadata;
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
          this.configuration = _configuration;
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

export class TreeNode {
  public title: string;
  public children: TreeNode[] | null = null;
  public isOpen: boolean = false;

  constructor(title: string, children: TreeNode[] | null) {
    this.title = title;
    this.children = children;
  }
}
