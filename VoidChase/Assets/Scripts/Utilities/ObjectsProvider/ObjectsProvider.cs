using System;
using System.Collections.Generic;
using UnityEngine;

//TOOD: Move to better namespace
namespace VoidChase.Utilities
{
    public class ObjectsProvider<TProvider, TObjectData, TType, TObjectReference> : SingletonMonoBehaviour<TProvider> 
        where TProvider: ObjectsProvider<TProvider, TObjectData, TType, TObjectReference>
        where TObjectData : ObjectData<TType, TObjectReference>
        where TType : Enum
        where TObjectReference : class
    {
        [field: Header(InspectorNames.SETTINGS_NAME)]
        [field: SerializeField]
        private List<TObjectData> ObjectDataCollection { get; set; }

        private Dictionary<TType, TObjectReference> ObjectsMap { get; set; } = new ();

        private const string OBJECT_NOT_FOUND_MESSAGE = "Cannot find object with name {0}.";

        public bool TryGetObject (TType objectType, out TObjectReference objectReference)
        {
            objectReference = null;

            if (!ObjectsMap.TryGetValue(objectType, out objectReference))
            {
                Debug.LogError(string.Format(OBJECT_NOT_FOUND_MESSAGE, objectType));
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
                ObjectsMap.Add(objectData.Type, objectData.ObjectReference);
            }
        }
    }
}
