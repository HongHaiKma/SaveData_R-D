using UnityEngine;

namespace Obvious.Soap
{
    [CreateAssetMenu(fileName = "scriptable_variable_vector2.asset", menuName = "Soap/ScriptableVariables/vector2")]
    public class Vector2Variable : ScriptableVariable<Vector2>
    {
        public override void Save()
        {
            PlayerPrefs.SetFloat(this.Guid + "_x", Value.x);
            PlayerPrefs.SetFloat(this.Guid + "_y", Value.y);
            base.Save();
        }

        public override void Load()
        {
            var x = PlayerPrefs.GetFloat(this.Guid + "_x", _initialValue.x);
            var y = PlayerPrefs.GetFloat(this.Guid + "_y", _initialValue.y);
            Value = new Vector2(x,y);
            base.Load();
        }
    }
}