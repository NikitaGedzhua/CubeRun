using UnityEngine;

namespace Gedjua.Runner.Utils
{
    public  class RandomNameGenerator
    {
        private NamesList _namesList;

        private NamesList CurrentNamesList
        {
            get {
                if (_namesList != null) return _namesList;
                var textAsset = Resources.Load("Texts/NamesList") as TextAsset;
                if (textAsset != null)
                    _namesList = JsonUtility.FromJson<NamesList>(textAsset.text);
                return _namesList;
            }
        }

        public string GetRandomName()
        {
            return CurrentNamesList.names[Random.Range(0, CurrentNamesList.names.Count)];
        }
    }
}
