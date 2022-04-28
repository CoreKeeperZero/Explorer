using UnityEngine;

public class CustomScanner : MonoBehaviour
{
    GameObject go;
    ObjectInfo objectInfo;
    // Sprite sprite;
    Sprite[] sprites;
    string spritePath;
    //PrefabInfo prefabInfo;
    Il2CppSystem.Collections.Generic.List<CraftingObject> craftingObjects;

    void Start()
    {
        go = new GameObject("CustomScanner");

        objectInfo = new ObjectInfo();
        // CustomScanner would need to be added to ObjectID
        // so using BirdBossScanner as an example
        // dunno what happens if you use the same id actually
        objectInfo.objectID = ObjectID.BirdBossScanner;
        objectInfo.objectType = ObjectType.CastingItem;
        objectInfo.rarity = Rarity.Epic;
        // You could use a custom sprite but using BirdBossScanner
        // as example again
        // you could probably also load from a file or web
        // can also use spriteatlas when texture contains multiple sprites
        spritePath = "Assets/Texture2D/lootsprites.png";
        sprites = Resources.LoadAll<Sprite>(spritePath);
        objectInfo.icon = (Sprite) sprites[164]; // extra cast might not be needed
        objectInfo.smallIcon = (Sprite) sprites[165];
        objectInfo.isStackable = true;
        //prefabInfo.prefab = null;
        //prefabInfo.ecsPrefab = null; // need to reference ourself?
        //objectInfo.prefabInfos = null;
        // helper or extension methods for CraftingObjects would come in handy
        craftingObjects = new Il2CppSystem.Collections.Generic.List<CraftingObject>();
        CraftingObject craftingObject1 = new CraftingObject();
        CraftingObject craftingObject2 = new CraftingObject();
        CraftingObject craftingObject3 = new CraftingObject();
        craftingObject1.objectID = ObjectID.AncientGemstone;
        craftingObject1.amount = 5;
        craftingObject2.objectID = ObjectID.MechanicalPart;
        craftingObject2.amount = 5;
        craftingObject3.objectID = ObjectID.AncientFeather;
        craftingObject3.amount = 10;
        craftingObjects.Add(craftingObject1);
        craftingObjects.Add(craftingObject2);
        craftingObjects.Add(craftingObject3);
        objectInfo.requiredObjectsToCraft = craftingObjects;
        
        // don't think it is mandatory to set the following ones
        objectInfo.variation = 0;
        objectInfo.onlyExistsInSeason = Season.None;
        objectInfo.craftingTime = 0f;
        objectInfo.mapColor = Color.black;

        /*
        These are automatically set when creating a new ObjectInfo
        objectInfo.initialAmount = 1;
        objectInfo.sellValue = -1;
        objectInfo.buyValueMultiplier = 1.0f;
        objectInfo.prefabTileSize = Vector2Int.one;
        */

        EntityMonoBehaviourData entityMonoBehaviourData = go.AddComponent<EntityMonoBehaviourData>() as EntityMonoBehaviourData; // dunno if the as if needed but unity docs suggests
        entityMonoBehaviourData.objectInfo = objectInfo;

        CastItemCDAuthoring castItemCDAuthoring = go.AddComponent<CastItemCDAuthoring>() as CastItemCDAuthoring;
        castItemCDAuthoring.castTime = 2f;

        ScannerCDAuthoring scannerCDAuthoring = go.AddComponent<ScannerCDAuthoring>() as ScannerCDAuthoring;
        // or what ever you want to scan.
        scannerCDAuthoring.objectToScan = ObjectID.BirdBoss;

        // we could make this gameobject a prefab as well
    }
}