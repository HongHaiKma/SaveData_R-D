using UnityEngine;

namespace Obvious.Soap
{
    [CreateAssetMenu(fileName = "scriptable_variable_color.asset", menuName = "Soap/ScriptableVariables/color")]
    public class ColorVariable : ScriptableVariable<Color>
    {
        public override void Save()
        {
            PlayerPrefs.SetFloat(this.Guid + "_r", Value.r);
            PlayerPrefs.SetFloat(this.Guid + "_g", Value.g);
            PlayerPrefs.SetFloat(this.Guid + "_b", Value.b);
            PlayerPrefs.SetFloat(this.Guid + "_a", Value.a);
            base.Save();
        }

        public override void Load()
        {
            var r = PlayerPrefs.GetFloat(this.Guid + "_r", _initialValue.r);
            var g = PlayerPrefs.GetFloat(this.Guid + "_g", _initialValue.g);
            var b = PlayerPrefs.GetFloat(this.Guid + "_b", _initialValue.b);
            var a = PlayerPrefs.GetFloat(this.Guid + "_a", _initialValue.a);
            Value = new Color(r, g, b, a);
            base.Load();
        }

        public void SetRandom()
        {
            var beautifulColor = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
            Value = beautifulColor;
        }
    }
}