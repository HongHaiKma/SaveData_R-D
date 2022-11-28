using UnityEngine;

namespace Obvious.Soap
{
    [CreateAssetMenu(fileName = "scriptable_variable_string.asset", menuName = "Soap/ScriptableVariables/string")]
    public class StringVariable : ScriptableVariable<string>
    {
        public override void Save()
        {
            PlayerPrefs.SetString(this.Guid, Value);
            base.Save();
        }

        public override void Load()
        {
            Value = PlayerPrefs.GetString(this.Guid, _initialValue);
            base.Load();
        }
    }
}