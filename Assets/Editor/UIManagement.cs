using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using TMPro;

public class UIManagement : EditorWindow {

    string pn = "";
    Color32 col1,col2;
    [MenuItem("HC-TCG/UIManagement")]
    private static void ShowWindow() {
        var window = GetWindow<UIManagement>();
        window.titleContent = new GUIContent("UIManagement");
        window.Show();
    }

    private void OnGUI() {
        GUILayout.Label("Button Settings", EditorStyles.boldLabel);
        if(GUILayout.Button("Set Properties",GUILayout.Width(100))){
            SetButtonProperties();
        }

        GUILayout.Label("Find Objects By Parent", EditorStyles.boldLabel);
        pn = EditorGUILayout.TextField("Parent Name", pn,GUILayout.Width(400));
        if(GUILayout.Button("Find",GUILayout.Width(100))){

            GameObject[] allObjects = Selection.gameObjects;
            Object[] selectedObjects = new GameObject[0];

            Selection.objects = null;
            foreach (GameObject childTransform in allObjects) {
                if (childTransform.transform.parent.name == pn) {
                    ArrayUtility.Add(ref selectedObjects, childTransform.gameObject);
                }
            }
            Selection.objects = selectedObjects;
        }

        GUILayout.Label("SetColors", EditorStyles.boldLabel);
        col1 = EditorGUILayout.ColorField(col1,GUILayout.Width(150));
        if(GUILayout.Button("Set",GUILayout.Width(100))){

            GameObject selected = Selection.activeGameObject;
            selected.GetComponent<Image>().color = col1;

            Transform t = selected.transform.GetChild(1);
            for (int i = 0; i < t.childCount; i++)
            {
                Transform t2 = t.GetChild(i);
                for (int j = 0; j < t2.childCount; j++)
                {
                    t2.GetChild(j).GetComponent<Image>().color = col1;
                    t2.GetChild(j).GetChild(0).GetComponent<Image>().color = col1;
                }
            }
        }
    }

    private void SetButtonProperties()
    {
        try
        {
            foreach(GameObject g in Selection.gameObjects){
                TextMeshProUGUI shadow = g.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
                TextMeshProUGUI txt = g.transform.GetChild(2).GetComponent<TextMeshProUGUI>();

                Undo.RecordObject(shadow, "Change Text");
                shadow.text = g.name;
                Undo.RecordObject(txt, "Change Text");
                txt.text = g.name;
            }
        }
        catch (System.Exception)
        {
            
            Debug.Log("Selected Object Is Not  A Button");
        }
        
    }
}
