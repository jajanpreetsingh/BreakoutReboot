// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

Shader "Custom/CustomSpecular" {
	Properties
	{
		_Color("Main Color" , Color) = (1,1,1,1)
		_Texture("Main Texture", 2D) = "white"{}
		_SpecColor("Specular Color" , Color) = (1,1,1,1)
		_ShineFac("Shine Factor",Range(0.0,100.0))=2.0
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
		float3 normal : NORMAL;

	};

	struct vertToFrag
	{
		float4 pos : SV_POSITION; // position symmentics for xbox and DX11
		float2 texcord : TEXCOORD0;
		float3 normal : NORMAL;

		float4 posworld : TEXCOORD1;
	};

	fixed4 _Color;
	sampler2D _Texture;
	float4 _LightColor0;

	vertToFrag  vert(vertexInput input)
	{
		vertToFrag output;

		output.pos = UnityObjectToClipPos(input.vertex);
		output.texcord = input.texcord;

		output.normal = mul(float4(input.normal, 0.0), unity_ObjectToWorld).xyz;

		//we get object to word space cordinates of normal (normal is coverted to float4 for a 4x4 matrix
		//than we append xyz to reconvert to float3 as we are intrested in only those 3 values

		output.posworld = mul(input.vertex, unity_ObjectToWorld);

		return output;
	}

	//fixed4 frag(vertToFrag input) : COLOR // this one returns a color val multipied by sin of time
	//{
	//	return mul(_Color,_SinTime.y);
	//}

	fixed4 frag(vertToFrag input) : COLOR // return texture color added to sin wave component
	{
		fixed4 col = tex2D(_Texture, input.texcord) + fixed4(_Color.r,_SinTime.y,_Color.b,1);

	float3 normaldirec = normalize(input.normal);
	float3 lightdirec = normalize(_WorldSpaceLightPos0);

	//now diffuse color is dot product of normal and incoming light hence
	float3 diffuse = _LightColor0.rgb * max(0.0, dot(normaldirec,lightdirec));
	// max of 0.0 means cross product can be -1 to +1 but color values are 0 to 1

	return col * float4(diffuse,1);
	}

		ENDCG
	}
	}
		FallBack "Diffuse"
}

