using System.Diagnostics;
using System.Reflection;

[assembly: CLSCompliant(true)]
namespace MyAttribute.DefClass
{
    /// <summary>
    /// 检测定制特性
    /// </summary>
    [Serializable]
    [DefaultMember("Main1")]
    [DebuggerDisplay("", Name = "name", Target = typeof(DetectionAttribute))]
    public sealed class DetectionAttribute
    {
        public DetectionAttribute()
        {

        }

        [Conditional("Debug")]
        [Conditional("Release")]
        public void DoSomething()
        {

        }

        [CLSCompliant(true)]
        [STAThread]
        public static void Main()
        {

        }

        private static void ShowAttributes(MemberInfo attributeTarget)
        {

        }
    }
}