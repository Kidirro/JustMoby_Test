using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class IconDataHolder : ScriptableObject
{
    [SerializeField]
    private List<IconNameData> rawListData;

    private Dictionary<string, Sprite> _dictionaryData = new Dictionary<string, Sprite>();
    
    private void OnValidate()
    {
        if (rawListData.Count==0) return;
        
        _dictionaryData.Clear();
        for(int i = rawListData.Count-1; i>=0; i--)
        {
            if (_dictionaryData.ContainsKey(rawListData[i].Name))
            {
                continue;
            }

            _dictionaryData[rawListData[i].Name] = rawListData[i].Sprite;
        }
    }

    public Sprite GetSpriteByName(string spriteName)
    {
        if (spriteName == null) return null;
        return _dictionaryData.TryGetValue(spriteName, out var value) ? value : null;
    }

    [Serializable]
    private class IconNameData
    {
        public string Name;
        public Sprite Sprite;
    }
}
