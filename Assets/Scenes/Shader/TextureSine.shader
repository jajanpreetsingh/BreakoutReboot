// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/Texture Sine"
{
	Properties
	{
		_Color("Color" , Color) = (1,1,1,1)
		_Texture("Main Texture", 2D) = "white"{}
	}

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
				float2 texcord : TEXCOORD0;
			};

			struct vertToFrag
			{
				float4 pos : SV_POSITION; // position symmentics for xbox and DX11
				float2 texcord : TEXCOORD0;
			};

			fixed4 _Color;
			sampler2D _Texture;

			vertToFrag  vert(vertexInput input)
			{
				vertToFrag output;

				output.pos = UnityObjectToClipPos(input.vertex);
				output.texcord = input.texcord;

				return output;
			}

			//fixed4 frag(vertToFrag input) : COLOR // this one returns a color val multipied by sin of time
			//{
			//	return mul(_Color,_SinTime.y);
			//}

			fixed4 frag(vertToFrag input) : COLOR // return texture color added to sin wave component
			{
				return tex2D(_Texture, input.texcord) + fixed4(_Color.r,_SinTime.y,_Color.b,1);
			}

			ENDCG
		}
	}
}