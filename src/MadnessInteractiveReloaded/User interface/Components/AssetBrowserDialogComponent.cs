﻿using System;
using Walgelijk;
using Walgelijk.AssetManager;

namespace MIR; //🎅

public class AssetBrowserDialogComponent : Component
{
    public readonly Action<GlobalAssetId> SetAsset;
    public readonly Func<AssetMetadata, bool> FilterFunction;
    public GlobalAssetId Asset;
    public AssetBrowserControl AssetBrowserControl;

    public AssetBrowserDialogComponent(Action<GlobalAssetId> setAsset, Func<AssetMetadata, bool> filterFunction, GlobalAssetId asset)
    {
        SetAsset = setAsset;
        FilterFunction = filterFunction;
        Asset = asset;

        AssetBrowserControl = new();

        if (Assets.TryGetPackage(Asset.External, out var p))
            if (p.HasAsset(Asset.Internal))
            {
                AssetBrowserControl.External = p.Metadata.Name;
                var v = p.GetAssetPath(asset.Internal);
                var i = v.LastIndexOf('/');
                if (i != -1)
                    AssetBrowserControl.Path = v[..i];
            }
    }
}
