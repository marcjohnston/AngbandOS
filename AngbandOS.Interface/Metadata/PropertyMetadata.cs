﻿namespace AngbandOS.Core.Interface;

/// <summary>
/// Represents the common properties for both tuple and simple property metadata.  This class is abstract because the TuplePropertyMetadata and the 
/// SimplePropertyMetadata classes add a differing Type property to denote support for either a Tuple type or a non-tuple "simple" type.
/// </summary>
public abstract class PropertyMetadata
{
    public PropertyMetadata(string propertyName)
    {
        PropertyName = propertyName;
    }

    /// <summary>
    /// Returns the name of the configuration property to assign the user value to.
    /// </summary>
    public string PropertyName { get; }

    /// <summary>
    /// Returns a title (or short description) of the property that can be presented to the user or null; in which the property name should be used.
    /// </summary>
    public string? Title { get; set; } = null;

    /// <summary>
    /// Returns the category of the property, when presenting the property to the user or empty; if the property has no category and could be considered miscellaneous.
    /// </summary>
    public string CategoryTitle { get; set; } = "";

    /// <summary>
    /// Returns true, if the property value must be provided by the user.  Returns false, by default.
    /// </summary>
    public bool IsRequired { get; set; } = false;

    /// <summary>
    /// Returns true, if the property supports more than one value.  Returns false, by default.
    /// </summary>
    public bool IsArray { get; set; } = false;

    /// <summary>
    /// Returns a description of the property that can be presented to the user that provides the maximum amount of details on how the property is to be used.  Returns a blank description, by default.
    /// </summary>
    public string? Description { get; set; } = "";

    public override string ToString()
    {
        return PropertyName;
    }
}