using AngbandOS.Core.Interface;

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
    Console.WriteLine();
}

void WriteProperty(StreamWriter writer, string folder, PropertyMetadata genericPropertyMetadata, int indentUnits)
{
    string indentation = new string(' ', indentUnits * 4);
    switch (genericPropertyMetadata)
    {
        case IntegerPropertyMetadata genericIntegerPropertyMetadata:
            writer.WriteLine($"{indentation}new IntegerPropertyMetadata(\"{genericPropertyMetadata.PropertyName}\")");
            writer.WriteLine($"{indentation}{{");
            if (genericIntegerPropertyMetadata.IsNullable || genericIntegerPropertyMetadata.DefaultValue != null)
            {
                writer.WriteLine($"{indentation}    DefaultValue = {genericIntegerPropertyMetadata.DefaultValue.ToString()},");
            }
            break;
        case BooleanPropertyMetadata genericBooleanPropertyMetadata:
            writer.WriteLine($"{indentation}new BooleanPropertyMetadata(\"{genericPropertyMetadata.PropertyName}\")");
            writer.WriteLine($"{indentation}{{");
            if (genericBooleanPropertyMetadata.IsNullable || genericBooleanPropertyMetadata.DefaultValue.HasValue)
            {
                writer.WriteLine($"{indentation}    DefaultValue = {genericBooleanPropertyMetadata.DefaultValue.Value.ToString().ToLower()},");
            }
            break;
        case StringPropertyMetadata genericStringPropertyMetadata:
            writer.WriteLine($"{indentation}new StringPropertyMetadata(\"{genericPropertyMetadata.PropertyName}\")");
            writer.WriteLine($"{indentation}{{");
            if (genericStringPropertyMetadata.IsNullable || genericStringPropertyMetadata.DefaultValue != null)
            {
                writer.WriteLine($"{indentation}    DefaultValue = \"{genericStringPropertyMetadata.DefaultValue}\",");
            }
            break;
        case StringArrayPropertyMetadata genericStringArrayPropertyMetadata:
            writer.WriteLine($"{indentation}new StringArrayPropertyMetadata(\"{genericPropertyMetadata.PropertyName}\")");
            writer.WriteLine($"{indentation}{{");
            if (genericStringArrayPropertyMetadata.IsNullable || genericStringArrayPropertyMetadata.DefaultValue != null)
            {
                writer.WriteLine($"{indentation}    DefaultValue = {genericStringArrayPropertyMetadata.DefaultValue},");
            }
            break;
        case CharacterPropertyMetadata genericCharacterPropertyMetadata:
            writer.WriteLine($"{indentation}new CharacterPropertyMetadata(\"{genericPropertyMetadata.PropertyName}\")");
            writer.WriteLine($"{indentation}{{");
            if (genericCharacterPropertyMetadata.IsNullable || genericCharacterPropertyMetadata.DefaultValue != null)
            {
                writer.WriteLine($"{indentation}    DefaultValue = '{genericCharacterPropertyMetadata.DefaultValue}',");
            }
            break;
        case CollectionPropertyMetadata genericCollectionArrayPropertyMetadata:
            writer.WriteLine($"{indentation}new CollectionPropertyMetadata(\"{genericPropertyMetadata.PropertyName}\")");
            writer.WriteLine($"{indentation}{{");
            writer.WriteLine($"{indentation}    PropertyMetadatas = {genericCollectionArrayPropertyMetadata.EntityTitle}Metadata.Metadata,");
            WriteClass(folder, genericCollectionArrayPropertyMetadata.EntityTitle, genericCollectionArrayPropertyMetadata.PropertyMetadatas);
            break;
        case ColorEnumPropertyMetadata genericColorEnumPropertyMetadata:
            writer.WriteLine($"{indentation}new ColorEnumPropertyMetadata(\"{genericPropertyMetadata.PropertyName}\")");
            writer.WriteLine($"{indentation}{{");
            break;
        default:
            throw new Exception($"{genericPropertyMetadata.GetType().Name} not supported.");
    }

    writer.WriteLine($"{indentation}    Description = \"{genericPropertyMetadata.Description}\",");
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


PropertyMetadata[] ParseClass(string collectionFilename)
{
    List<PropertyMetadata> propertyMetadatas = new List<PropertyMetadata>();

    string[] text = File.ReadAllLines(collectionFilename);
    ModeEnum mode = ModeEnum.None;
    List<string> descriptionList = new List<string>();
    string? category = null;
    string? title = null;
    foreach (string line in text)
    {
        string trimmedLine = line.Trim();
        if (trimmedLine.Contains(@"<EntityTitle>"))
        {
            mode = ModeEnum.None;
            //entityTitle = trimmedLine.Replace("<EntityTitle", "").Replace("</EntityTitle", "");
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
            if (className != Path.GetFileNameWithoutExtension(collectionFilename))
            {
                throw new Exception();
            }
            continue; // Skip the rest of the processing.
        }

        // Is this a property.
        if (tokens.Length > 1 && tokens[0] == "public")
        {
            // Yes.  Check if there is a default value specified.
            string? defaultValue = null;
            int tokenIndex = Array.IndexOf(tokens, "=");
            if (tokenIndex >= 0)
            {
                // Extract the default value and remove the semi-colon.
                defaultValue = String.Join(" ", tokens.Skip(tokenIndex + 1).Take(tokens.Length - tokenIndex)).Replace(";", "");

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
                    string message = $"The {name} property in the {collectionFilename} file has a tuple data type of {dataType} that does not have a trailing end parenthesis ).";
                    Console.WriteLine(message);
                    throw new Exception(message);
                }

                // Remove the parenthesis.
                dataType = dataType.Substring(1, dataType.Length - 2);
                string[] dataTypeTokens = dataType.Split(",");
                List<PropertyMetadata> tupleProperties = new List<PropertyMetadata>();
                foreach (string dataTypeToken in dataTypeTokens)
                {
                    (string tupleDataType, bool tupleIsNullable, bool tupleIsArray) = ParseDataType(dataTypeToken);
                    switch (fullDataType)
                    {
                        case "char":
                            propertyMetadatas.Add(new CharacterPropertyMetadata()
                            {
                                CategoryTitle = category,
                                Description = description,
                                IsNullable = tupleIsNullable,
                                PropertyName = name,
                                Title = title,
                                // DefaultValue = defaultValue == "null" ? null : defaultValue
                            });
                            break;
                        case "bool":
                            propertyMetadatas.Add(new BooleanPropertyMetadata()
                            {
                                CategoryTitle = category,
                                Description = description,
                                IsNullable = tupleIsNullable,
                                PropertyName = name,
                                Title = title,
                                DefaultValue = defaultValue == "null" ? null : Boolean.Parse(defaultValue)
                            });
                            break;
                        case "int":
                            propertyMetadatas.Add(new IntegerPropertyMetadata()
                            {
                                CategoryTitle = category,
                                Description = description,
                                IsNullable = tupleIsNullable,
                                PropertyName = name,
                                Title = title,
                                // DefaultValue = defaultValue == "null" ? null : Int32.Parse(defaultValue)
                            });
                            break;
                        case "ColorEnum":
                            propertyMetadatas.Add(new ColorEnumPropertyMetadata()
                            {
                                CategoryTitle = category,
                                Description = description,
                                IsNullable = tupleIsNullable,
                                PropertyName = name,
                                Title = title,
                                // DefaultValue = defaultValue == "null" ? null : Int32.Parse(defaultValue)
                            });
                            break;
                        case "string":
                            if (tupleIsArray)
                            {
                                propertyMetadatas.Add(new StringArrayPropertyMetadata()
                                {
                                    CategoryTitle = category,
                                    Description = description,
                                    IsNullable = tupleIsNullable,
                                    PropertyName = name,
                                    Title = title,
                                    //   DefaultValue = defaultValue == "null" ? null : defaultValue
                                });
                            }
                            else
                            {
                                propertyMetadatas.Add(new StringPropertyMetadata()
                                {
                                    CategoryTitle = category,
                                    Description = description,
                                    IsNullable = tupleIsNullable,
                                    PropertyName = name,
                                    Title = title,
                                    DefaultValue = defaultValue == "null" ? null : defaultValue
                                });
                            }
                            break;
                    }
                }
            }
            else
            {
                switch (dataType)
                {
                    case "char":
                        propertyMetadatas.Add(new CharacterPropertyMetadata()
                        {
                            CategoryTitle = category,
                            Description = description,
                            IsNullable = isNullable,
                            PropertyName = name,
                            Title = title,
                            // DefaultValue = defaultValue == "null" ? null : defaultValue
                        });
                        break;
                    case "bool":
                        propertyMetadatas.Add(new BooleanPropertyMetadata()
                        {
                            CategoryTitle = category,
                            Description = description,
                            IsNullable = isNullable,
                            PropertyName = name,
                            Title = title,
                            DefaultValue = defaultValue == null ? null : Boolean.Parse(defaultValue)
                        });
                        break;
                    case "int":
                        propertyMetadatas.Add(new IntegerPropertyMetadata()
                        {
                            CategoryTitle = category,
                            Description = description,
                            IsNullable = isNullable,
                            PropertyName = name,
                            Title = title,
                            // DefaultValue = defaultValue == "null" ? null : Int32.Parse(defaultValue)
                        });
                        break;
                    case "ColorEnum":
                        propertyMetadatas.Add(new ColorEnumPropertyMetadata()
                        {
                            CategoryTitle = category,
                            Description = description,
                            IsNullable = isNullable,
                            PropertyName = name,
                            Title = title,
                            // DefaultValue = defaultValue == "null" ? null : Int32.Parse(defaultValue)
                        });
                        break;
                    case "string":
                        if (isArray)
                        {
                            propertyMetadatas.Add(new StringArrayPropertyMetadata()
                            {
                                CategoryTitle = category,
                                Description = description,
                                IsNullable = isNullable,
                                PropertyName = name,
                                Title = title,
                                //   DefaultValue = defaultValue == "null" ? null : defaultValue
                            });
                        }
                        else
                        {
                            propertyMetadatas.Add(new StringPropertyMetadata()
                            {
                                CategoryTitle = category,
                                Description = description,
                                IsNullable = isNullable,
                                PropertyName = name,
                                Title = title,
                                DefaultValue = defaultValue == "null" ? null : defaultValue
                            });
                        }
                        break;
                    default:
                        if (!dataType.EndsWith("GameConfiguration"))
                        {
                            string message = $"The {name} property in the {collectionFilename} file has a data type of {dataType} that is not supported.";
                            Console.WriteLine(message);
                            throw new Exception(message);
                        }
                        string entityTitle = dataType.Substring(0, dataType.Length - 17);
                        PropertyMetadata[] collectionPropertyMetadatas = ParseClass(Path.Combine(Path.GetDirectoryName(collectionFilename), $"{dataType}.cs"));
                        propertyMetadatas.Add(new CollectionPropertyMetadata()
                        {
                            CategoryTitle = category,
                            Description = description,
                            IsNullable = isNullable,
                            PropertyName = name,
                            Title = title,
                            EntityTitle = entityTitle,
                            PropertyMetadatas = collectionPropertyMetadatas,
                        });
                        break;
                }
            }

            descriptionList.Clear();
            title = null;
            category = null;
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
