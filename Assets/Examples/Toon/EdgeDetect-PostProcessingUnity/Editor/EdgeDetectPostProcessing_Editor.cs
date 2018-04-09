//--------------------------------------------------------------------------------------------------------------------------------
// Port of the Legacy Unity "Edge Detect" image effect to Post Processing Stack v2
// Jean Moreno, September 2017
// Legacy Image Effect: https://docs.unity3d.com/550/Documentation/Manual/script-EdgeDetectEffectNormals.html
// Post Processing Stack v2: https://github.com/Unity-Technologies/PostProcessing/tree/v2
//--------------------------------------------------------------------------------------------------------------------------------

using UnityEngine;
using UnityEditor;
using UnityEngine.Rendering.PostProcessing;
using UnityEditor.Rendering.PostProcessing;

[PostProcessEditor(typeof(EdgeDetectPostProcessing))]
public sealed class EdgeDetectPostProcessing_Editor : PostProcessEffectEditor<EdgeDetectPostProcessing>
{
	SerializedParameterOverride mode;
	SerializedParameterOverride sensitivityDepth;
	SerializedParameterOverride sensitivityNormals;
	SerializedParameterOverride lumThreshold;
	SerializedParameterOverride edgeExp;
	SerializedParameterOverride sampleDist;
	SerializedParameterOverride edgesOnly;
	SerializedParameterOverride edgesOnlyBgColor;

	GUIContent gc_mode = new GUIContent("Mode");
	GUIContent gc_sensitivityDepth = new GUIContent(" Depth Sensitivity");
	GUIContent gc_sensitivityNormals = new GUIContent(" Normals Sensitivity");
	GUIContent gc_lumThreshold = new GUIContent(" Luminance Threshold");
	GUIContent gc_edgeExp = new GUIContent(" Edge Exponent");
	GUIContent gc_sampleDist = new GUIContent(" Sample Distance");
	GUIContent gc_edgesOnly = new GUIContent(" Edges Only");
	GUIContent gc_edgesOnlyBgColor = new GUIContent(" Color");

	string gc_description = "Detects spatial differences and converts into black outlines\n\nLegacy image effect from previous Unity versions ported to Post Processing v2";
	GUIContent gc_background = new GUIContent("Background Options");

	public override void OnEnable()
	{
		mode = FindParameterOverride(x => x.mode);
		sensitivityDepth = FindParameterOverride(x => x.sensitivityDepth);
		sensitivityNormals = FindParameterOverride(x => x.sensitivityNormals);
		lumThreshold = FindParameterOverride(x => x.lumThreshold);
		edgeExp = FindParameterOverride(x => x.edgeExp);
		sampleDist = FindParameterOverride(x => x.sampleDist);
		edgesOnly = FindParameterOverride(x => x.edgesOnly);
		edgesOnlyBgColor = FindParameterOverride(x => x.edgesOnlyBgColor);
	}

	public override void OnInspectorGUI()
	{
		EditorGUILayout.HelpBox(gc_description, MessageType.None);

		PropertyField(mode, gc_mode);

		PropertyField(sampleDist, gc_sampleDist);

		if(mode.value.enumValueIndex < 2)
		{
			PropertyField(sensitivityDepth, gc_sensitivityDepth);
			PropertyField(sensitivityNormals, gc_sensitivityNormals);
		}
		else if(mode.value.enumValueIndex < 4)
		{
			PropertyField(edgeExp, gc_edgeExp);
		}
		else
		{
			// lum based mode
			PropertyField(lumThreshold, gc_lumThreshold);
		}

		EditorGUILayout.Space();

		GUILayout.Label(gc_background);
		PropertyField(edgesOnly, gc_edgesOnly);
		PropertyField(edgesOnlyBgColor, gc_edgesOnlyBgColor);
	}
}