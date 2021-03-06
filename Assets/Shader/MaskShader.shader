﻿Shader "MyShader/MaskShader" {
	Properties {
		_MainTex ("Base (RGB) Trans (A)", 2D) = "white" {}
		_MaskTex ("Mask (A)", 2D) = "white" {}
		_Progress ("Progress", Range(0,1)) = 0
	}
	SubShader {
		//Lighting Off
		//ZWrite Off 
		//Cull back 
		//Fog { Mode Off } 
		Tags {"RenderType"="Transparent" "IgnoreProjector"="True" "ForceNoShadowCasting"="True" "Queue"="Transparent"} 
		//Tags { "Queue"="Transparent" }
		Blend SrcAlpha OneMinusSrcAlpha
		LOD 200
		
		CGPROGRAM
		#pragma surface surf CustomDiffuse

		sampler2D _MainTex;
		sampler2D _MaskTex;
		float _Progress;

		struct Input {
			float2 uv_MainTex;
			float2 uv_MaskTex;
		};
		
		inline float4 LightingCustomDiffuse (SurfaceOutput s, fixed3 lightDir, fixed atten) {  
		    //float difLight = max(0, dot (s.Normal, lightDir));
		    float4 col;
		    //col.rgb = s.Albedo * _LightColor0.rgb * (difLight * atten * 2);
		    col.rgb = s.Albedo;
		    col.a = s.Alpha;
		    return col;
		}

		void surf (Input IN, inout SurfaceOutput o) {
			half4 c = tex2D(_MainTex, IN.uv_MainTex);
			o.Albedo = c.rgb;
			c.a=tex2D(_MaskTex, IN.uv_MaskTex).a < _Progress||_Progress==1 ? 0 : c.a;
			o.Alpha = c.a;
		}
		ENDCG
	} 
	FallBack "Diffuse"
}
