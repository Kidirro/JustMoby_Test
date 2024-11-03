using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class IconController
{
    private const string MAIN_HOLDER = "IconDataHolder";

    private static IconDataHolder _dataHolder = null; 
    
    private static bool LoadDataHolder()
    {
        if (_dataHolder != null) return true;

        _dataHolder = Resources.Load<IconDataHolder>(MAIN_HOLDER);

        return _dataHolder != null;
    }

    public static Sprite GetIcon(string spriteName)
    {
        return LoadDataHolder() == false ? null : _dataHolder.GetSpriteByName(spriteName);
    }
}
