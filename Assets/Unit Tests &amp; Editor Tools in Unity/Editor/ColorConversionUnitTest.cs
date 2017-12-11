using UnityEngine;
using UnityEditor;
using NUnit.Framework;

[TestFixture]
public class ColorConversionUnitTest
{
    public Color[] rgbs = new Color[]
    {
        new Color(0.0f, 0.0f, 0.0f),		// Black
	    new Color(0.5f, 0.5f, 0.5f),		// Gray
	    new Color(1.0f, 1.0f, 1.0f),		// White
	    new Color(1.0f, 0.0f, 0.0f),		// Red
	    new Color(1.0f, 1.0f, 0.0f),		// Yellow
	    new Color(0.0f, 1.0f, 0.0f),		// Green
	    new Color(0.0f, 1.0f, 1.0f),		// Cyan
	    new Color(0.0f, 0.0f, 1.0f),		// Blue
	    new Color(1.0f, 0.0f, 1.0f)			// Magenta
    };

    public float[][] hsvs = new float[][]
    {
        new float[] { 0.0f, 0.0f, 0.0f },	// Black
	    new float[] { 0.0f, 0.0f, 0.5f },	// Gray
	    new float[] { 0.0f, 0.0f, 1.0f },	// White
	    new float[] { 0.0f, 1.0f, 1.0f },	// Red
	    new float[] { 60.0f, 1.0f, 1.0f },	// Yellow
	    new float[] { 120.0f, 1.0f, 1.0f },	// Green
	    new float[] { 180.0f, 1.0f, 1.0f },	// Cyan
	    new float[] { 240.0f, 1.0f, 1.0f },	// Blue
	    new float[] { 300.0f, 1.0f, 1.0f }  // Magenta
    };

    [Test]
    public void RGBtoHSV()
    {
        for (int i = 0; i < rgbs.Length; i++)
        {
            float h;
            float s;
            float v;

            ColorConversion.RGBtoHSV(rgbs[i], out h, out s, out v);

            Assert.AreEqual(hsvs[i][0], h);
            Assert.AreEqual(hsvs[i][1], s);
            Assert.AreEqual(hsvs[i][2], v);
        }
    }

    [Test]
    public void HSVtoRGB()
    {
        for (int i = 0; i < rgbs.Length; i++)
        {
            Color rgb = ColorConversion.HSVtoRGB(hsvs[i][0], hsvs[i][1], hsvs[i][2]);

            Assert.AreEqual(rgb.r, rgbs[i].r);
            Assert.AreEqual(rgb.g, rgbs[i].g);
            Assert.AreEqual(rgb.b, rgbs[i].b);
        }
    }
}

