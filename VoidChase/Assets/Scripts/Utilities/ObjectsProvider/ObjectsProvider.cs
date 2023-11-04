using System.Collections.Generic;
using UnityEngine;

//TOOD: Move to better namespace
namespace VoidChase.Utilities
{
    public class ObjectsProvider<TProvider, TObjectData, TObjectReference> : SingletonMonoBehaviour<TProvider> 
        where TProvider: ObjectsProvider<TProvider, TObjectData, TObjectReference>
        where TObjectData : ObjectData<TObjectReference>
        where TObjectReference : class
    {
        [field: Header(InspectorNames.SETTINGS_NAME)]
        [field: SerializeField]
        private List<TObjectData> ObjectDataCollection { get; set; }

        private Dictionary<string, TObjectReference> ObjectsMap { get; set; } = new ();

        private const string OBJECT_NOT_FOUND_MESSAGE = "Cannot find object with name {0}.";

        public bool TryGetObject (string objectName, out TObjectReference objectReference)
        {
            objectReference = null;

            if (!ObjectsMap.TryGetValue(objectName, out objectReference))
            {
                Debug.LogError(string.Format(OBJECT_NOT_FOUND_MESSAGE, objectName));
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
                ObjectsMap.Add(objectData.Name, objectData.ObjectReference);
            }
        }
    }
}
