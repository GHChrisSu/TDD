using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ColorPickerWindow : EditorWindow {
    private Color color_;
    private float separation_;

    [MenuItem("Window/ColorPicker")]
    public static void Init()
    {
        ColorPickerWindow window = (ColorPickerWindow)EditorWindow.GetWindow(typeof(ColorPickerWindow));
        window.Show();

    }

    public void OnGUI()
    {
        color_ = EditorGUILayout.ColorField("Base color", color_);
        separation_ = EditorGUILayout.FloatField("Separation", separation_);

        float h;
        float s;
        float v;
        ColorConversion.RGBtoHSV(color_, out h, out s, out v);

        EditorGUILayout.Space();

        EditorGUILayout.LabelField("Analogous Colors");
        EditorGUILayout.ColorField(ColorConversion.HSVtoRGB(h + 2.0f * separation_, s, v));
        EditorGUILayout.ColorField(ColorConversion.HSVtoRGB(h + 1.0f * separation_, s, v));
        EditorGUILayout.ColorField(ColorConversion.HSVtoRGB(h - 1.0f * separation_, s, v));
        EditorGUILayout.ColorField(ColorConversion.HSVtoRGB(h - 2.0f * separation_, s, v));

        EditorGUILayout.Space();

        EditorGUILayout.LabelField("Monochromatic Colors");
        EditorGUILayout.ColorField(ColorConversion.HSVtoRGB(h, s, v * 0.75f));
        EditorGUILayout.ColorField(ColorConversion.HSVtoRGB(h, s, v * 0.5f));
        EditorGUILayout.ColorField(ColorConversion.HSVtoRGB(h, s, v * 0.25f));

        EditorGUILayout.Space();

        EditorGUILayout.LabelField("Triad");
        EditorGUILayout.ColorField(ColorConversion.HSVtoRGB(h + 120.0f, s, v));
        EditorGUILayout.ColorField(ColorConversion.HSVtoRGB(h - 120.0f, s, v));

        EditorGUILayout.Space();

        EditorGUILayout.LabelField("Complimentary");
        EditorGUILayout.ColorField(ColorConversion.HSVtoRGB(h + 180.0f, s, v));



    }
}
