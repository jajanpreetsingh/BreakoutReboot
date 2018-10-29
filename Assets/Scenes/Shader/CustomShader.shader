// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

Shader "Custom/CustomShader"
{
	SubShader
	{
		Pass
		{
			CGPROGRAM

			#pragma vertex vert 
			#pragma fragment frag

			struct vertexInput
			{
				float4 vertex : POSITION;
				float4 tangent : TANGENT;
				float3 normal : NORMAL;
				float4 texcoord : TEXCOORD0;
				fixed4 color : COLOR;

				fixed4 objToworlPos : TEXCOORD1;
			};

			vertexInput vert(vertexInput input)
			{

				vertexInput output; // we don't need to type 'struct' here

				output.vertex = UnityObjectToClipPos(input.vertex); //using just vertexPos gives flat square
				output.color = input.vertex + float4(0.5, 0.5, 0.5, 0.0);
				output.normal = input.normal;
				output.tangent = input.tangent;

				output.objToworlPos = mul(unity_ObjectToWorld, input.vertex);
				// Here the vertex shader writes output data
				// to the output structure. We add 0.5 to the 
				// x, y, and z coordinates, because the 
				// coordinates of the cube are between -0.5 and
				// 0.5 but we need them between 0.0 and 1.0. 

				return output;
			}

			float4 frag(vertexInput input) : COLOR // fragment shader
			{
				float dist = distance(input.objToworlPos,float4(0.0, 0.0, 0.0, 1.0));
				// computes the distance between the fragment position 
				// and the origin (the 4th coordinate should always be 
				// 1 for points).

				//return float4(0.7, 0.9, 0.3, 1.0)/dist;

				//return float4((input.normal + float3(1.0, 1.0, 1.0)) / 2.0, 1.0);

				return input.color;
			}

			ENDCG // here ends the part in Cg 
		}
	}
}