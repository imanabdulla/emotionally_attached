using UnityEditor;
using UnityEngine;
public class PlayerPrefs : MonoBehaviour
{
    // Add a menu item named "Do Something" to MyMenu in the menu bar.
    [MenuItem("PlayerPrefs/ClearAll")]
    static void ClearAll()
    {
        UnityEngine.PlayerPrefs.DeleteAll();
    }
}

