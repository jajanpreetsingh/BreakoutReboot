// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/Transparency"
{
	SubShader
	{
		Pass
		{
			Cull Off // turn off triangle culling, alternatives are:
				 // Cull Back (or nothing): cull only back faces 
				 // Cull Front : cull only front faces
			
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

			struct vertexOutput
			{
				float4 pos : SV_POSITION;
				float4 posInObjectCoords : TEXCOORD0;
			};

			vertexOutput vert(vertexInput input)
			{
				vertexOutput output;

				output.pos = UnityObjectToClipPos(input.vertex);
				output.posInObjectCoords = input.vertex;

				return output;
			}

			float4 frag(vertexOutput input) : COLOR
			{
				//if (input.posInObjectCoords.y > 0.0)
				//{
					discard; // drop the fragment if y coordinate > 0
				//}
				return float4(0.0, 0.0, 0.0, 1.0); // green
			}

			ENDCG // here ends the part in Cg 
		}
	}
}