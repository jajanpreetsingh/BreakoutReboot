using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class PostEffect : MonoBehaviour
{
    public Material PostEffectMaterial;

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, PostEffectMaterial);
    }
}

#region shader

/*
	Properties
	{

	}

	SubShader // can have multiple subshader blocks one after another
	{
		Tags
		{
			"Queue" = "Transparent" // can have values like "Geometry" "Background" etc
			"RenderType" = "Transparent"
		}

		Blend SrcAlpha OneMinusSrcAlpha // if outside pass block, this will be executed for all passes

		Pass // can have multiple pass blocks one after another
		{
			CGPROGRAM

			#pragma exclude_renderers ps3 xbox360 flash
			#pragma fragmentation ARB_hint_precision_fastest

			#pragma surface	surf lambart vertex : vert // means my surface method is named as surf and with lambart lighting and vert as vertex method
			#pragma vertex vert // means my vertex method is named as vert
			#pragma fragment frag //means my fragmant method is named as frag

			#include "UnityCG.cginc"

			uniform fixed4 _Color;

			struct vertexInput 
			{
                float4 vertex : POSITION;
                float4 tangent : TANGENT;  
                float3 normal : NORMAL;
                float4 texcoord : TEXCOORD0;  
                float4 texcoord1 : TEXCOORD1; 
                float4 texcoord2 : TEXCOORD2;  
                float4 texcoord3 : TEXCOORD3; 
                fixed4 color : COLOR; 
			};

            struct vertexOutput 
            {
                float4 pos : SV_POSITION;
                float4 col : TEXCOORD0;
                //so on... whatever you need in fragment shader
            };
 
            vertexOutput vert(vertexInput input) 
            {
                vertexOutput output;
 
                output.pos =  mul(UNITY_MATRIX_MVP, input.vertex);
                output.col = input.texcoord; // set the output color

                // other possibilities to play with:

                // output.col = input.vertex;
                // output.col = input.tangent;
                // output.col = float4(input.normal, 1.0);
                // output.col = input.texcoord;
                // output.col = input.texcoord1;
                // output.col = input.texcoord2;
                // output.col = input.texcoord3;
                // output.col = input.color;

                return output;
            }

			ENDCG
		}
	}			

	Fallback "Diffuse"
	*/

#endregion
