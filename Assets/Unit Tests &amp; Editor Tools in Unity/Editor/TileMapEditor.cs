using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(TileMap))]
public class TileMapEditor : Editor {
    private TileMap tileMap_;
    private GameObject currentTile_;

    public void OnEnable()
    {
        tileMap_ = (TileMap)target;
        if (!tileMap_.Initialized)
        {
            tileMap_.Initialize();
        }
        currentTile_ = null;
    }

    public override void OnInspectorGUI()
    {
        currentTile_ = (GameObject)EditorGUILayout.ObjectField("Current tile", currentTile_, typeof(GameObject));
    }

    public void OnSceneGUI()
    {
        Event e = Event.current;
        int controlID = GUIUtility.GetControlID(FocusType.Passive);
        bool clicked = false;
        switch (e.type)
        {
            case EventType.Layout:
                HandleUtility.AddDefaultControl(controlID);
                break;
            case EventType.MouseDown:
                if (e.button == 0) clicked = true;
                break;
            default:
                break;
        }

        Vector3 worldPoint = Camera.current.ScreenToWorldPoint(new Vector3(e.mousePosition.x, -e.mousePosition.y + Camera.current.pixelHeight));
        Vector2 normalPoint = tileMap_.transform.worldToLocalMatrix.MultiplyPoint(worldPoint);
        int x = Mathf.FloorToInt(normalPoint.x);
        int y = Mathf.FloorToInt(normalPoint.y);

        Handles.DrawLine(new Vector3(x, y), new Vector3(x + 1, y));
        Handles.DrawLine(new Vector3(x + 1, y), new Vector3(x + 1, y + 1));
        Handles.DrawLine(new Vector3(x + 1, y + 1), new Vector3(x, y + 1));
        Handles.DrawLine(new Vector3(x, y + 1), new Vector3(x, y));

        SceneView.RepaintAll();

        if (clicked)
        {
            tileMap_.PlaceTile(x, y, currentTile_);
        }
    }
}
