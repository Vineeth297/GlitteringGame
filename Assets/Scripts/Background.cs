using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
	[SerializeField] private float cleaningRadius = 0.05f;
	[SerializeField] [Range(0.1f,1)] private float hardness;
	[SerializeField] private float totalCleaned = 0f;

	[SerializeField] private float multiplier = 1;
	public float minClean;
	public MeshFilter meshSource;

	public bool toBlowTheRest;

	private Vector3[] _vertices;
	private Color[] _colors;
	private Mesh _mesh;

	// color.red => mud Texture
	// color.green => clean Texture
	private void Start()
	{
		_mesh = meshSource.mesh;
		_vertices = _mesh.vertices;
		_colors = new Color[_vertices.Length];

		for (var i = 0; i < _colors.Length; i++) _colors[i] = Color.red;
		
		UpdateMesh();
	}

	public void ApplyColorChanges(Vector3 position)
	{
		var cleanVertices = 0;
		
		for (var i = 0; i < _vertices.Length; i++)
		{
			var pos = meshSource.transform.TransformPoint(_vertices[i]);
			var distance = (pos - position).magnitude;
			if (distance < cleaningRadius)
			{
				var t = distance / (cleaningRadius * multiplier) ; 
				var invPos = Mathf.InverseLerp(1,0,_colors[i].r);

				_colors[i] = new Color(Mathf.Lerp(_colors[i].r, toBlowTheRest ? 1 : 0, _colors[i].r + t * hardness + invPos), 0, 0);
			}
			if (_colors[i].r < 0.1f) cleanVertices++;
		}
		totalCleaned = (float)cleanVertices / _vertices.Length;

		if (totalCleaned >= minClean)
		{
			AutoClear();
			totalCleaned = 0;
		}
		
		UpdateMesh();
	}

	private void UpdateMesh()
	{
		print( toBlowTheRest + " = isFullyErased");

		_mesh.colors = _colors;
	}

	private void AutoClear()
	{
		for (var i = 0; i < _vertices.Length; i++) _colors[i] = !toBlowTheRest 
			? Color.Lerp(_colors[i], Color.clear, 2)
			: Color.Lerp(Color.clear, _colors[i], 2);
		
		UpdateMesh();
		
		if (toBlowTheRest) return;
		toBlowTheRest = true;
	}
}
