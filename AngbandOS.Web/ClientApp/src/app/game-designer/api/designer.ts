import { DesignerProperty } from "./designer-property";

/**
 * Represents a designer that describes the properties of the object to be designed.
 */
export interface Designer {
  /**
   * Returns the text for the object to be rendered to the user.  In most cases, this title should be the same as the object name.
   */
  title: string;
  description: string;
  properties: DesignerProperty[];
}

