using UnityEngine;

public static class ColorConversion
{
	public static void RGBtoHSV(Color color, out float h, out float s, out float v)
	{
		float cmax = Mathf.Max(color.r, color.g, color.b);
		float cmin = Mathf.Min(color.r, color.g, color.b);
		float delta = cmax - cmin;

		if (Mathf.Approximately(delta, 0.0f))
			h = 0.0f;
		else if (Mathf.Approximately(cmax, color.r))
			h = 60.0f * ((color.g - color.b) / delta);
		else if (Mathf.Approximately(cmax, color.g))
			h = 60.0f * ((color.b - color.r) / delta + 2.0f);
		else
			h = 60.0f * ((color.r - color.g) / delta + 4.0f);
        h = (h + 360) % 360.0f;

		if (Mathf.Approximately(cmax, 0.0f))
			s = 0.0f;
		else
			s = delta / cmax;

		v = cmax;
	}

	public static Color HSVtoRGB(float h, float s, float v)
	{
		// Wrap hue to 360 degrees
		h = ((h % 360.0f) + 360.0f) % 360.0f;

		float c = v * s;
		float x = c * (1.0f - Mathf.Abs((h / 60.0f) % 2.0f - 1.0f));
		float m = v - c;

		switch (Mathf.FloorToInt(h / 60.0f))
		{
			case 0:
				return new Color(c + m, x + m, m);
			case 1:
				return new Color(x + m, c + m, m);
			case 2:
				return new Color(m, c + m, x + m);
			case 3:
				return new Color(m, x + m, c + m);
			case 4:
				return new Color(x + m, m, c + m);
			default:
				return new Color(c + m, m, x + m);
		}
	}
}