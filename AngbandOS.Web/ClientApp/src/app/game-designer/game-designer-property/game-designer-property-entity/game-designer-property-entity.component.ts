import { Component, Input, forwardRef } from '@angular/core';
import { getEntityName } from '../../game-designer-library.module';
import { PropertyMetadata } from '../../property-metadata';
import { PropertyMetadataAndConfiguration } from '../../property-metadata-and-configuration';
import { SelectOption } from '../../select-option';
import { GameDesignerPropertyComponent } from '../game-designer-property.component';

@Component({
  selector: 'app-game-designer-property-entity',
  imports: [forwardRef(() => GameDesignerPropertyComponent)],
  templateUrl: './game-designer-property-entity.component.html',
  styleUrl: './game-designer-property-entity.component.scss',
})
export class GameDesignerPropertyEntityComponent {
  @Input({ required: true }) public propertyMetadataAndConfiguration!: PropertyMetadataAndConfiguration;
  @Input({ required: true }) public gameConfiguration!: Record<string, unknown>;
  @Input({ required: true }) public gamePropertyMetadata!: PropertyMetadata[];
  @Input({ required: true }) public enumMap!: Map<string, SelectOption[]>;

  public get entityName(): string {
    const { propertyMetadata, configuration } = this.propertyMetadataAndConfiguration;
    return getEntityName(propertyMetadata, configuration);
  }

  public createChild(childPropertyMetadata: PropertyMetadata): PropertyMetadataAndConfiguration {
    return new PropertyMetadataAndConfiguration(
      childPropertyMetadata,
      this.propertyMetadataAndConfiguration.configuration,
    );
  }
}
