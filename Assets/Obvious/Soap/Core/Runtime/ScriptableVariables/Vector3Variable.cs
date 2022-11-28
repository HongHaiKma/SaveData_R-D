using UnityEngine;
using UnityEngine.Events;

namespace Obvious.Soap
{
    [CreateAssetMenu(fileName = "scriptable_variable_vector3.asset", menuName = "Soap/ScriptableVariables/vector3")]
    public class Vector3Variable : ScriptableVariable<Vector3>
    {
        public override void Save()
        {
            PlayerPrefs.SetFloat(this.Guid + "_x", Value.x);
            PlayerPrefs.SetFloat(this.Guid + "_y", Value.y);
            PlayerPrefs.SetFloat(this.Guid + "_z", Value.z);
            base.Save();
        }

        public override void Load()
        {
            var x = PlayerPrefs.GetFloat(this.Guid + "_x", _initialValue.x);
            var y = PlayerPrefs.GetFloat(this.Guid + "_y", _initialValue.y);
            var z = PlayerPrefs.GetFloat(this.Guid + "_z", _initialValue.z);
            Value = new Vector3(x,y,z);
            base.Load();
        }
    }
}