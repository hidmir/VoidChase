using System.Collections.Generic;
using UnityEngine;

//TOOD: Move to better namespace
namespace VoidChase.Utilities
{
    public class ObjectsProvider<TProvider, TObjectData, TKey, TObjectReference> : SingletonMonoBehaviour<TProvider> 
        where TProvider: ObjectsProvider<TProvider, TObjectData, TKey, TObjectReference>
        where TObjectData : ObjectData<TKey, TObjectReference>
        where TObjectReference : class
    {
        [field: Header(InspectorNames.SETTINGS_NAME)]
        [field: SerializeField]
        private List<TObjectData> ObjectDataCollection { get; set; }

        private Dictionary<TKey, TObjectReference> ObjectsMap { get; set; } = new ();

        private const string KEY_NOT_FOUND_MESSAGE = "Cannot find key with name {0}.";

        public bool TryGetObject (TKey objectKey, out TObjectReference objectReference)
        {
            objectReference = null;

            if (!ObjectsMap.TryGetValue(objectKey, out objectReference))
            {
                Debug.LogError(string.Format(KEY_NOT_FOUND_MESSAGE, objectKey));
            }

            return objectReference != null;
        }

        public IEnumerable<TObjectReference> GetAllObjects ()
        {
            foreach (TObjectData objectData in ObjectDataCollection)
            {
                yield return objectData.ObjectReference;
            }
        }

        protected override void Initialize ()
        {
            base.Initialize();
            ConvertObjectDataToDictionary();
        }

        private void ConvertObjectDataToDictionary ()
        {
            foreach (TObjectData objectData in ObjectDataCollection)
            {
                ObjectsMap.Add(objectData.Key, objectData.ObjectReference);
            }
        }
    }
}
