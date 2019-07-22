﻿Shader "Unlit/Dissolve_X"
{
	Properties
	{
		_MainTex("Texture", 2D) = "white" {}
		_DissolveTexture("Dissolve Texture", 2D) = "white" {}
		_DissolveX("Current X of the dissolve effect", Float) = 0
		_DissolveSize("Size of the effect", Float) = 2
		_StartingX("Starting point of the effect", Float) = 0
	}
		SubShader
		{
			Tags { "RenderType" = "Opaque" }
			LOD 100

			Pass
			{
				CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag
				#include "UnityCG.cginc"

				struct appdata
				{
					float4 vertex : POSITION;
					float2 uv : TEXCOORD0;
				};

				struct v2f
				{
					float2 uv : TEXCOORD0;
					float4 vertex : SV_POSITION;
					float3 localPos : TEXCOORD1;
				};

				sampler2D _MainTex;
				float4 _MainTex_ST;
				sampler2D _DissolveTexture;
				float _DissolveX;
				float _DissolveSize;
				float _StartingX;

				v2f vert(appdata v)
				{
					v2f o;
					o.vertex = UnityObjectToClipPos(v.vertex);
					o.uv = TRANSFORM_TEX(v.uv, _MainTex);
					o.localPos = v.vertex.xyz;
					return o;
				}

				fixed4 frag(v2f i) : SV_Target
				{
					float transition = _DissolveX - i.localPos.x;
					clip(_StartingX + (transition + (tex2D(_DissolveTexture, i.uv)) * _DissolveSize));
					fixed4 col = tex2D(_MainTex, i.uv);

					return col;
				}
				ENDCG
			}
		}
}
