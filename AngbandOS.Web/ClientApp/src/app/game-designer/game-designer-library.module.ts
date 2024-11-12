import { convertToTitleCase } from "../modules/strings-library/strings-library.module";
import { PropertyMetadata } from "./property-metadata";

/***
  * Returns an entity name.  If the entity doesn't have a defined property name, the property key value will be returned.
  */
export function getEntityName(propertyMetadata: PropertyMetadata, entity: any): string {
  if (propertyMetadata.entityNamePropertyName === null) {
    // Retrieve the value of the entity key as the default.
    const keyValue: string = entity[propertyMetadata.entityKeyPropertyName!] as string; // The activePropertyMetadataAndConfiguration will always be available.

    // Check to see if the entity name is properly suffixed with the entity title.
    var entityName = keyValue; // Default the entity name to the key value.
    const collectionEntityName: string = propertyMetadata.entityNoun!;
    if (keyValue.endsWith(collectionEntityName)) {
      // Override the entity name by removing the suffix.
      entityName = keyValue.slice(0, -collectionEntityName.length);

      // and converting it to title case now.
      entityName = convertToTitleCase(entityName);
    }
    return entityName;
  }
  else {
    return entity[propertyMetadata.entityNamePropertyName]; // The activePropertyMetadataAndConfiguration and entityKeyPropertyName properties will always be available.
  }
}
