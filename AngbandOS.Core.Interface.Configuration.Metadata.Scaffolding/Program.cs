﻿using AngbandOS.Core.Interface;
using System.Text.RegularExpressions;

string configurationName = args[0];
string outputFolder = args[1];

string folder = Path.GetDirectoryName(configurationName);
string filename = Path.GetFileNameWithoutExtension(configurationName);
//D:\OneDrive\Programming\AngbandOS\AngbandOS.Interface\GameConfigurations\GameConfiguration.cs
PropertyMetadata[] gameConfigurationPropertyMetadatas = ParseClass(configurationName);
WriteClass(outputFolder, filename, gameConfigurationPropertyMetadatas);

void WriteClass(string folder, string entityName, PropertyMetadata[] propertyMetadatas)
{
    string filename = Path.Combine(folder, $"{entityName}Metadata.cs");
    using (StreamWriter writer = new StreamWriter(filename, false))
    {
        writer.WriteLine("// <auto-generated>");
        writer.WriteLine("// This code was generated by the AngbandOS.Core.Interface.MetaGen tool.");
        writer.WriteLine("// Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.");
        writer.WriteLine("// </auto-generated>");
        writer.WriteLine("namespace AngbandOS.Core.Interface.Metadata;");
        writer.WriteLine();
        writer.WriteLine($"public static class {entityName}Metadata");
        writer.WriteLine("{");
        writer.WriteLine("    public static PropertyMetadata[] Metadata");
        writer.WriteLine("    {");
        writer.WriteLine("        get");
        writer.WriteLine("        {");
        writer.WriteLine("            return new PropertyMetadata[]");
        writer.WriteLine("            {");

        foreach (PropertyMetadata genericPropertyMetadata in propertyMetadatas)
        {
            WriteProperty(writer, folder, genericPropertyMetadata, 4);
        }
        writer.WriteLine("            };");
        writer.WriteLine("        }");
        writer.WriteLine("    }");
        writer.WriteLine("}");
    }
}

void WriteProperty(StreamWriter writer, string folder, PropertyMetadata genericPropertyMetadata, int indentUnits)
{
    string indentation = new string(' ', indentUnits * 4);
    switch (genericPropertyMetadata)
    {
        case IntegerPropertyMetadata genericIntegerPropertyMetadata:
            writer.WriteLine($"{indentation}new IntegerPropertyMetadata(\"{genericIntegerPropertyMetadata.PropertyName}\")");
            writer.WriteLine($"{indentation}{{");
            if (!genericIntegerPropertyMetadata.DefaultValue.HasValue)
            {
                writer.WriteLine($"{indentation}    DefaultValue = null,");
            }
            else
            {
                writer.WriteLine($"{indentation}    DefaultValue = {genericIntegerPropertyMetadata.DefaultValue.Value},");
            }
            break;
        case BooleanPropertyMetadata genericBooleanPropertyMetadata:
            writer.WriteLine($"{indentation}new BooleanPropertyMetadata(\"{genericBooleanPropertyMetadata.PropertyName}\")");
            writer.WriteLine($"{indentation}{{");
            if (!genericBooleanPropertyMetadata.DefaultValue.HasValue)
            {
                writer.WriteLine($"{indentation}    DefaultValue = null,");
            }
            else
            {
                writer.WriteLine($"{indentation}    DefaultValue = {genericBooleanPropertyMetadata.DefaultValue.Value.ToString().ToLower()},");
            }
            break;
        case StringPropertyMetadata genericStringPropertyMetadata:
            writer.WriteLine($"{indentation}new StringPropertyMetadata(\"{genericStringPropertyMetadata.PropertyName}\")");
            writer.WriteLine($"{indentation}{{");
            if (genericStringPropertyMetadata.DefaultValue == null)
            {
                writer.WriteLine($"{indentation}    DefaultValue = null,");
            }
            else
            {
                writer.WriteLine($"{indentation}    DefaultValue = {genericStringPropertyMetadata.DefaultValue},");
            }
            break;
        case StringsPropertyMetadata genericStringArrayPropertyMetadata:
            writer.WriteLine($"{indentation}new StringsPropertyMetadata(\"{genericStringArrayPropertyMetadata.PropertyName}\")");
            writer.WriteLine($"{indentation}{{");
            if (genericStringArrayPropertyMetadata.DefaultValue == null)
            {
                writer.WriteLine($"{indentation}    DefaultValue = null,");
            }
            else
            {
                writer.WriteLine($"{indentation}    DefaultValue = {genericStringArrayPropertyMetadata.DefaultValue},");
            }
            break;
        case CharacterPropertyMetadata genericCharacterPropertyMetadata:
            writer.WriteLine($"{indentation}new CharacterPropertyMetadata(\"{genericCharacterPropertyMetadata.PropertyName}\")");
            writer.WriteLine($"{indentation}{{");
            if (!genericCharacterPropertyMetadata.DefaultValue.HasValue)
            {
                writer.WriteLine($"{indentation}    DefaultValue = null,");
            }
            else
            {
                writer.WriteLine($"{indentation}    DefaultValue = {genericCharacterPropertyMetadata.DefaultValue.Value},");
            }
            break;
        case ColorPropertyMetadata genericColorEnumPropertyMetadata:
            writer.WriteLine($"{indentation}new ColorPropertyMetadata(\"{genericColorEnumPropertyMetadata.PropertyName}\")");
            writer.WriteLine($"{indentation}{{");
            if (!genericColorEnumPropertyMetadata.DefaultValue.HasValue)
            {
                writer.WriteLine($"{indentation}    DefaultValue = null,");
            }
            else
            {
                writer.WriteLine($"{indentation}    DefaultValue = ColorEnum.{genericColorEnumPropertyMetadata.DefaultValue.Value},");
            }
            break;
        case CollectionPropertyMetadata genericCollectionArrayPropertyMetadata:
            writer.WriteLine($"{indentation}new CollectionPropertyMetadata(\"{genericCollectionArrayPropertyMetadata.PropertyName}\")");
            writer.WriteLine($"{indentation}{{");
            writer.WriteLine($"{indentation}    PropertyMetadatas = {genericCollectionArrayPropertyMetadata.EntityTitle}Metadata.Metadata,");
            writer.WriteLine($"{indentation}    EntityTitle = \"{genericCollectionArrayPropertyMetadata.EntityTitle}\",");
            writer.WriteLine($"{indentation}    KeyPropertyName = \"Key\",");
            WriteClass(folder, genericCollectionArrayPropertyMetadata.EntityTitle, genericCollectionArrayPropertyMetadata.PropertyMetadatas);
            break;
        case TuplePropertyMetadata genericTupleArrayPropertyMetadata:
            writer.WriteLine($"{indentation}new TuplePropertyMetadata(\"{genericTupleArrayPropertyMetadata.PropertyName}\")");
            writer.WriteLine($"{indentation}{{");
            writer.WriteLine($"{indentation}    Types = new PropertyMetadata[]");
            writer.WriteLine($"{indentation}    {{");
            foreach (PropertyMetadata tuplePropertyMetadata in genericTupleArrayPropertyMetadata.Types)
            {
                WriteProperty(writer, folder, tuplePropertyMetadata, indentUnits + 2);
            }
            writer.WriteLine($"{indentation}    }},");
            break;       
        default:
            throw new Exception($"{genericPropertyMetadata.GetType().Name} not supported.");
    }

    writer.WriteLine($"{indentation}    Description = \"{genericPropertyMetadata.Description.Replace("\"", "\\\"")}\",");
    writer.WriteLine($"{indentation}    IsNullable = {genericPropertyMetadata.IsNullable.ToString().ToLower()},");
    if (genericPropertyMetadata.Title != null)
    {
        writer.WriteLine($"{indentation}    Title = \"{genericPropertyMetadata.Title}\",");
    }
    if (genericPropertyMetadata.CategoryTitle != null)
    {
        writer.WriteLine($"{indentation}    Category = \"{genericPropertyMetadata.CategoryTitle}\",");
    }
    writer.WriteLine($"{indentation}}},");
}


PropertyMetadata[] ParseClass(string classFilename)
{
    List<PropertyMetadata> propertyMetadatas = new List<PropertyMetadata>();

    string[] text = File.ReadAllLines(classFilename);
    ModeEnum mode = ModeEnum.None;
    List<string> descriptionList = new List<string>();
    List<string> returnsList = new List<string>();
    string? category = null;
    string? title = null;

    void ResetXMLComments()
    {
        descriptionList.Clear();
        title = null;
        category = null;
    }

    foreach (string line in text)
    {
        string trimmedLine = line.Trim();
        if (trimmedLine.Contains(@"<EntityTitle>"))
        {
            mode = ModeEnum.None;
        }
        else if (trimmedLine.StartsWith(@"///") && !trimmedLine.Contains(@"</"))
        {
            if (trimmedLine.Contains(@"<summary>"))
            {
                mode = ModeEnum.Summary;
            }
            else if (trimmedLine.Contains(@"<title>"))
            {
                mode = ModeEnum.Title;
            }
            else if (trimmedLine.Contains(@"<category>"))
            {
                mode = ModeEnum.Category;
            }
            else if (trimmedLine.Contains(@"<returns>"))
            {
                mode = ModeEnum.Returns;
            }
            else
            {
                switch (mode)
                {
                    case ModeEnum.Summary:
                        if (trimmedLine.Length > 3)
                        {
                            descriptionList.Add(trimmedLine.Substring(4));
                        }
                        break;
                    case ModeEnum.Returns:
                        if (trimmedLine.Length > 3)
                        {
                            returnsList.Add(trimmedLine.Substring(4));
                        }
                        break;
                    case ModeEnum.Title:
                        title = trimmedLine.Substring(4);
                        break;
                    case ModeEnum.Category:
                        category = trimmedLine.Substring(4);
                        break;
                    default:
                        break;
                }
            }
        }

        string[] tokens = trimmedLine.Split(' ');

        // Check to see if this line represents the class.
        int classIndex = Array.IndexOf(tokens, "class");
        if (classIndex >= 0)
        {
            // Ensure this file matches the class we are expecting to parse.
            string className = tokens[classIndex + 1];
            if (className != Path.GetFileNameWithoutExtension(classFilename))
            {
                throw new Exception();
            }

            // Reset the XML comments.
            ResetXMLComments();

            continue; // Skip the rest of the processing.
        }
        // Is this a property.
        else if (tokens.Length > 1 && tokens[0] == "public")
        {
            // Yes.  Check if there is a default value specified.
            string? defaultValueParsedString = null;
            int tokenIndex = Array.IndexOf(tokens, "=");
            if (tokenIndex >= 0)
            {
                // Extract the default value and remove the semi-colon.
                defaultValueParsedString = String.Join(" ", tokens.Skip(tokenIndex + 1).Take(tokens.Length - tokenIndex)).Replace(";", "");

                int commentPosition = defaultValueParsedString.IndexOf(@"//");
                if (commentPosition >= 0)
                {
                    defaultValueParsedString = defaultValueParsedString.Substring(0, commentPosition);
                }

                // Back off the { get; set; } tokens.
                tokenIndex -= 5;
            }
            else
            {
                // Find the } in the { get; set; } and back up 4 tokens.
                tokenIndex = Array.IndexOf(tokens, "}") - 4;
            }

            // Get the name of the property.
            string name = tokens[tokenIndex];

            // Check to see if we need to provide a default title.
            if (title == null)
            {
                // Add a space before each word in the property name using pascal case.
                title = Regex.Replace(name, "(?<!^)([A-Z])", " $1");
            }

            // Check if the virtual keyword was specified.
            int leadingTokensToSkip = 1; // Skip the public keyword.
            if (tokens[1] == "virtual")
            {
                leadingTokensToSkip++; // Skip the virtual keyword.
            }

            string fullDataType = String.Join(" ", tokens.Skip(leadingTokensToSkip).Take(tokenIndex - leadingTokensToSkip));
            (string dataType, bool isNullable, bool isArray) = ParseDataType(fullDataType);
            string description = String.Join(' ', descriptionList);

            // Detect a tuple
            if (dataType.StartsWith("("))
            {
                // Ensure it is properly enclosed in parenthesis
                if (!dataType.EndsWith(")"))
                {
                    string message = $"The {name} property in the {classFilename} file has a tuple data type of {dataType} that does not have a trailing end parenthesis ).";
                    Console.WriteLine(message);
                    throw new Exception(message);
                }

                // Remove the parenthesis.
                dataType = dataType.Substring(1, dataType.Length - 2);

                // Separate each tuple data type into a token.
                string[] tupleDataTypeTokens = dataType.Split(",");

                // Generate property metadata for each token.
                List<PropertyMetadata> tuplePropertyMetadatasList = new List<PropertyMetadata>();
                foreach (string tupleDataTypeToken in tupleDataTypeTokens)
                {
                    // Check to see if there is a name for this tuple.
                    string[] dataTypeAndNameTokens = tupleDataTypeToken.Trim().Split(" ");

                    (string tupleDataType, bool tupleIsNullable, bool tupleIsArray) = ParseDataType(dataTypeAndNameTokens[0]);

                    string tupleName = "";
                    string tupleDescription = "";

                    // Check to see if a name was provided.
                    if (dataTypeAndNameTokens.Length > 1)
                    {
                        // Find the description for the tuple in the returns XML comments.
                        string? matchingDescription = returnsList.SingleOrDefault(_description => _description.ToLower().StartsWith($"{dataTypeAndNameTokens[1].ToLower()}:"));
                        if (matchingDescription != null)
                        {
                            string[] matchingDescriptionTokens = matchingDescription.Split(":");
                            tupleName = matchingDescriptionTokens[0];
                            tupleDescription = matchingDescriptionTokens[1].Trim();
                        }
                    }
                    string tupleTitle = Regex.Replace(tupleName, "(?<!^)([A-Z])", " $1");

                    PropertyMetadata? propertyMetadata = GetPropertyMetadata(classFilename, tupleDataType, tupleName, category, tupleDescription, tupleIsNullable, tupleIsArray, tupleTitle, defaultValueParsedString);
                    if (propertyMetadata == null)
                    {
                        throw new Exception($"The {name} property in the {classFilename} file has a data type of {dataType} that is not supported.");
                    }
                    tuplePropertyMetadatasList.Add(propertyMetadata);
                }
                propertyMetadatas.Add(new TuplePropertyMetadata(name)
                {
                    CategoryTitle = category,
                    Description = description,
                    IsNullable = isNullable,
                    Title = title,
                    Types = tuplePropertyMetadatasList.ToArray(),
                });
            }
            else
            {
                if (dataType.EndsWith("GameConfiguration"))
                {
                    string entityTitle = dataType.Substring(0, dataType.Length - 17);
                    PropertyMetadata[] collectionPropertyMetadatas = ParseClass(Path.Combine(Path.GetDirectoryName(classFilename), $"{dataType}.cs"));
                    propertyMetadatas.Add(new CollectionPropertyMetadata(name)
                    {
                        CategoryTitle = category,
                        Description = description,
                        IsNullable = isNullable,
                        Title = title,
                        EntityTitle = entityTitle,
                        PropertyMetadatas = collectionPropertyMetadatas,
                    });
                }
                else
                {
                    PropertyMetadata? propertyMetadata = GetPropertyMetadata(classFilename, dataType, name, category, description, isNullable, isArray, title, defaultValueParsedString);
                    if (propertyMetadata == null)
                    {
                        throw new Exception($"The {name} property in the {classFilename} file has a data type of {dataType} that is not supported.");
                    }
                    propertyMetadatas.Add(propertyMetadata);
                }

            }

            ResetXMLComments();
        }
    }
    return propertyMetadatas.ToArray();
}

(string dataType, bool isNullable, bool isArray) ParseDataType(string fullDataType)
{
    bool isNullable = false;
    bool isArray = false;
    if (fullDataType.EndsWith(@"?"))
    {
        fullDataType = fullDataType.Substring(0, fullDataType.Length - 1);
        isNullable = true;
    }
    if (fullDataType.EndsWith(@"[]"))
    {
        fullDataType = fullDataType.Substring(0, fullDataType.Length - 2);
        isArray = true;
    }
    return (fullDataType, isNullable, isArray);
}

PropertyMetadata? GetPropertyMetadata(string classFilename, string dataType, string name, string? category, string description, bool isNullable, bool isArray, string? title, string? defaultValueParsedString)
{
    switch (dataType)
    {
        case "char":
            return new CharacterPropertyMetadata(name)
            {
                CategoryTitle = category,
                Description = description,
                IsNullable = isNullable,
                PropertyName = name,
                Title = title,
                DefaultValue = defaultValueParsedString == null || defaultValueParsedString == "null" ? null : Char.Parse(defaultValueParsedString)
            };
        case "bool":
            return new BooleanPropertyMetadata(name)
            {
                CategoryTitle = category,
                Description = description,
                IsNullable = isNullable,
                Title = title,
                DefaultValue = defaultValueParsedString == null || defaultValueParsedString == "null" ? null : Boolean.Parse(defaultValueParsedString)
            };
        case "int":
            return new IntegerPropertyMetadata(name)
            {
                CategoryTitle = category,
                Description = description,
                IsNullable = isNullable,
                Title = title,
                DefaultValue = defaultValueParsedString == null || defaultValueParsedString == "null" ? null : Int32.Parse(defaultValueParsedString)
            };
        case "ColorEnum":
            if (defaultValueParsedString != null && defaultValueParsedString != "null")
            {
                string[] colorEnumTokens = defaultValueParsedString.Split('.');
                if (colorEnumTokens.Length < 2 || colorEnumTokens[0] != "ColorEnum")
                {
                    throw new Exception($"The ColorEnum default value for the {name} property of the {classFilename} is not recognized.");
                }
                defaultValueParsedString = colorEnumTokens[1];
            }

            return new ColorPropertyMetadata(name)
            {
                CategoryTitle = category,
                Description = description,
                IsNullable = isNullable,
                Title = title,
                DefaultValue = defaultValueParsedString == null || defaultValueParsedString == "null" ? null : Enum.Parse<ColorEnum>(defaultValueParsedString)
            };
        case "string":
            if (isArray)
            {
                return new StringsPropertyMetadata(name)
                {
                    CategoryTitle = category,
                    Description = description,
                    IsNullable = isNullable,
                    Title = title,
                    //DefaultValue = defaultValueParsedString == null || defaultValueParsedString == "null" ? null : defaultValueParsedString
                };
            }
            else
            {
                return new StringPropertyMetadata(name)
                {
                    CategoryTitle = category,
                    Description = description,
                    IsNullable = isNullable,
                    Title = title,
                    DefaultValue = defaultValueParsedString == null || defaultValueParsedString == "null" ? null : defaultValueParsedString
                };
            }
        default:
            return null;
    }
}