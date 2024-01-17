import { DesignerPropertyDataType } from "./designer-property-data-type";

/**
 * Represents an interface that an object must implement to be designable via the Html UI.
 */
export interface DesignerProperty {
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

  dataType: DesignerPropertyDataType;
}
