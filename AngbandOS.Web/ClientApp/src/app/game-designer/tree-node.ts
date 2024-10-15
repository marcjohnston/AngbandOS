import { PropertyMetadataAndConfiguration } from './property-metadata-and-configuration';

export class TreeNode {
    /**
     * The text to render for the tree node.
     */
    public title: string;

    /**
     * The children tree nodes.
     */
    public children: TreeNode[] | null = null;

    /**
     * True, when the tree node is expanded; false, when the tree node is closed.
     */
    public isOpen: boolean = false;

    /**
     * The property metadata and the configuration that apply to this tree node.  When the tree node is clicked by the user, these properties are used to process the node.
     * @type {[PropertyMetadata, any | null]} - The PropertyMetadata for the tree node and the entity.  If the tree node is a collection and the user clicks to root (a non entity), a null value.
     */
    public metadataAndConfigurations: PropertyMetadataAndConfiguration[];

    constructor(title: string, children: TreeNode[] | null, metadataAndConfigurations: PropertyMetadataAndConfiguration[]) {
        this.title = title;
        this.children = children;
        this.metadataAndConfigurations = metadataAndConfigurations;
    }
}
