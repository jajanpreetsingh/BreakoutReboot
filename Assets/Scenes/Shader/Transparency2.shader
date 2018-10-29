// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/Transparency2"
{
	SubShader
	{
		Tags{ "Queue" = "Transparent" }
		// draw after all opaque geometry has been drawn

		Pass
		{
			Cull Off	// draw front and back faces
			ZWrite Off // don't write to depth buffer 
					   // in order not to occlude other objects
			
			//Blend SrcAlpha One // for additive blending
			//Blend Zero OneMinusSrcAlpha // for multiplicative blending
			Blend One OneMinusSrcAlpha // for another amazing effect
			//Blend off

			CGPROGRAM

			#pragma vertex vert 
			#pragma fragment frag

			struct v2f
			{
				float4 vertex : POSITION;
				fixed4 color : COLOR;
			};

			v2f vert(v2f input)
			{
				v2f output;
				output.vertex = UnityObjectToClipPos(input.vertex);
				output.color = input.vertex + float4(0.5, 0.5, 0.5, 0.0);

				return output;
			}

			fixed4 frag(v2f input) : COLOR
			{
				input.color.a = 0.2;
				return input.color;
			}

			ENDCG
		}

		//Pass
		//{
		//	Cull Off	// draw front and back faces
		//	ZWrite Off // don't write to depth buffer 
		//			   // in order not to occlude other objects

		//	Blend SrcAlpha One // for additive blending
		//	//Blend Zero OneMinusSrcAlpha // for multiplicative blending

		//	CGPROGRAM

		//	#pragma vertex vert 
		//	#pragma fragment frag

		//	struct v2f
		//	{
		//		float4 vertex : POSITION;
		//		fixed4 color : COLOR;
		//	};

		//	v2f vert(v2f input)
		//	{
		//		v2f output;
		//		output.vertex = mul(UNITY_MATRIX_MVP, input.vertex);
		//		output.color = input.color;

		//		return output;
		//	}

		//	fixed4 frag(v2f input) : COLOR
		//	{
		//		return input.color;
		//	}

		//	ENDCG
		//}
	}
}
