using System.ComponentModel.Design;
using System.Reflection;
using System.Xml.Linq;

namespace AngbandOS.Core.Interface.Metadata;

public class AnnotatedDataType
{
    /// <remarks>
    /// The recognized values are:
    ///    Name             Matches                                         Notes
    /// 1. boolean          bool, bool?
    /// 2. character        char, char?
    /// 3. enum             *Enum, *Enum?                                   The enum type must be decorated with the EnumMetadataAttribute
    /// 4. integer
    /// 5. string
    /// 6. tuple            
    /// 7. array            AssociatedProperties contains 1 item representing the underlying type.
    /// 8. 2d-array         AssociatedProperties contains 1 item representing the underlying type.
    /// </remarks>
    public string Type { get; set; }
    public bool IsNullable { get; set; }
    public string? EnumName { get; set; } = null;
    public string PropertyName { get; set; }
    public AnnotatedDataType[]? AssociatedProperties { get; set; } = null;

    public PropertyMetadata ToPropertyMetadata(string? propertyName)
    {
        // We force inject the property name when it comes from the parent call ... otherwise we keep the property name because it belongs
        // to the tuple names.
        return new PropertyMetadata(Type, propertyName ?? PropertyName ?? "") // Force inject, keep tuple, or "" for neither
        {
            LabelIfNullable = IsNullable ? "" : null,
            ForeignCollectionName = EnumName,
            AssociatedProperties = AssociatedProperties?.Select(x => x.ToPropertyMetadata(null)).ToArray() // Keep the tuple property name
        };
    }

    public override string ToString()
    {
        string type = Type switch
        {
            "boolean" => "bool",
            "character" => "char",
            "integer" => "int",
            "string" => "string",
            "enum" => EnumName!,
            "tuple" => $"({string.Join(", ", AssociatedProperties!.Select(x => x.ToString()))})",
            "array" => $"{AssociatedProperties![0]}[]",
            "2d-array" => $"{AssociatedProperties![0]}[][]",
            "collection" => $"collection",
            _ => Type
        };

        if (IsNullable)
        {
            type += "?";
        }

        return !string.IsNullOrEmpty(PropertyName) ? $"{type} {PropertyName}" : type;
    }


    public static AnnotatedDataType Parse(string dataType)
    {
        if (string.IsNullOrWhiteSpace(dataType))
        {
            throw new ArgumentException("Data type cannot be empty.", nameof(dataType));
        }

        dataType = dataType.Trim();

        // Determine nullability.
        bool isNullable = dataType.EndsWith("?");

        if (isNullable)
        {
            dataType = dataType[..^1].Trim();
        }

        // Determine array dimensions.
        int arrayDimensions = 0;

        while (dataType.EndsWith("[]"))
        {
            arrayDimensions++;
            dataType = dataType[..^2].Trim();
        }

        // Parse the underlying type.
        AnnotatedDataType result;

        if (arrayDimensions == 1)
        {
            result = new AnnotatedDataType
            {
                Type = "array",
                IsNullable = isNullable,
                AssociatedProperties = new AnnotatedDataType[] { Parse(dataType) }
            };
        }
        else if (arrayDimensions == 2)
        {
            result = new AnnotatedDataType
            {
                Type = "2d-array",
                IsNullable = isNullable,
                AssociatedProperties = new AnnotatedDataType[] { Parse(dataType) }
            };
        }
        else if (arrayDimensions > 2)
        {
            throw new FormatException("Arrays with more than two dimensions are not supported.");
        }
        else
        {
            if (dataType.StartsWith("(") && dataType.EndsWith(")"))
            {
                // Tuple
                string[] elements = SplitTupleElements(dataType[1..^1]);

                if (elements.Length < 2)
                {
                    throw new FormatException("A tuple must contain at least two elements.");
                }

                result = new AnnotatedDataType
                {
                    Type = "tuple",
                    IsNullable = isNullable && arrayDimensions == 0,
                    AssociatedProperties = elements.Select(ParseTupleElement).ToArray()
                };
            }
            else
            {
                // Primitive types and named types.
                string type = dataType switch
                {
                    "bool" => "boolean",
                    "char" => "character",
                    "int" => "integer",
                    "string" => "string",
                    _ => "enum"
                };

                result = new AnnotatedDataType
                {
                    Type = type,
                    IsNullable = isNullable && arrayDimensions == 0,
                    EnumName = type == "enum" ? dataType : null
                };
            }
        }
        return result;
    }

    private static AnnotatedDataType ParseTupleElement(string element)
    {
        element = element.Trim();

        int separator = element.LastIndexOf(' ');

        if (separator < 0)
        {
            throw new FormatException($"Unnamed tuple elements are not supported: '{element}'.");
        }

        string elementType = element[..separator].Trim();
        string propertyName = element[(separator + 1)..].Trim();

        if (string.IsNullOrWhiteSpace(elementType) || !System.Text.RegularExpressions.Regex.IsMatch(propertyName, @"^[a-zA-Z_]\w*$"))
        {
            throw new FormatException($"Invalid tuple element: '{element}'.");
        }

        AnnotatedDataType result = Parse(elementType);
        result.PropertyName = propertyName;

        return result;
    }

    private static string[] SplitTupleElements(string value)
    {
        List<string> elements = new();
        int depth = 0;
        int start = 0;

        for (int i = 0; i < value.Length; i++)
        {
            if (value[i] == '(')
            {
                depth++;
            }
            else if (value[i] == ')')
            {
                depth--;

                if (depth < 0)
                {
                    throw new FormatException("Invalid tuple syntax.");
                }
            }
            else if (value[i] == ',' && depth == 0)
            {
                elements.Add(value[start..i].Trim());
                start = i + 1;
            }
        }

        if (depth != 0)
        {
            throw new FormatException("Invalid tuple syntax.");
        }

        elements.Add(value[start..].Trim());

        if (elements.Any(string.IsNullOrWhiteSpace))
        {
            throw new FormatException("Invalid tuple element.");
        }

        return elements.ToArray();
    }
}
