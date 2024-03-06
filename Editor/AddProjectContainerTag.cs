using System.Linq;
using UnityEditor;
using UnityEditorInternal;

[InitializeOnLoad]
public class AddProjectContainerTag
{
    private const string Tag = "ProjectDiContainer";
    static AddProjectContainerTag()
    {
        if (!InternalEditorUtility.tags.Contains(Tag))
        {
            InternalEditorUtility.AddTag(Tag);
        }
    }
}