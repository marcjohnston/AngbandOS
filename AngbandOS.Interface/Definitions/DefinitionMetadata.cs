namespace AngbandOS.Core.Interface.Definitions;

public class DefinitionMetadata
{
    public DefinitionMetadata(string propertyName)
    {
        PropertyName = propertyName;
    }

    /// <summary>
    /// Returns the name of the configuration property to assign the value to.
    /// </summary>
    public string PropertyName { get; }

    /// <summary>
    /// Returns a title (or short description) of the property that can be presented to the user.
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Returns a description of the property that can be presented to the user that provides the maximum amount of details on how the property is to be used.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Returns true, if the property is an array.
    /// </summary>
    public bool IsArray { get; set; }

    /// <summary>
    /// Returns true, if the property is required.
    /// </summary>
    public bool IsRequired { get; set; }

    /// <summary>
    /// Returns the data type(s) that the property represents.  Non-tuple properties will only have a single data type.  Properties that reprsent tuples will have more than one 
    /// data type. 
    /// </summary>
    public DefinitionDataType[] DataType { get; set; }

    /// <summary>
    /// Returns the child properties.
    /// </summary>
    public DefinitionMetadata[] Properties { get; set; }

    public override string ToString()
    {
        return PropertyName;
    }
}

public class ForeignKeyDefinitionDataType
{

}

public class StringDefinitionDataType
{

}

public class BoolDefinitionDataType
{

}

public class IntDefinitionDataType
{

}

public class CharDefinitionDataType
{

}

public class DefinitionDataType
{

}

