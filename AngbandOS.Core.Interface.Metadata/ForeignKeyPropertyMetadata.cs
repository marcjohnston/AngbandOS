﻿namespace AngbandOS.Core.Interface;

public class ForeignKeyPropertyMetadata : PropertyMetadata
{
    public ForeignKeyPropertyMetadata(string propertyName) : base("foreign-key", propertyName) { }
    public new string? ForeignCollectionName
    {
        get => base.ForeignCollectionName;
        set => base.ForeignCollectionName = value;
    }
}