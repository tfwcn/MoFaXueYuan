Shader "MyShader/MaskShader2" {
	Properties {
		_MainTex ("Base (RGB) Trans (A)", 2D) = "white" {}
		_MaskTex ("Mask (A)", 2D) = "white" {}
		_Progress ("Progress", Range(0,1)) = 0
		_Color ("Color", Color) = (1,1,1,1)
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
		half4 _Color;

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
			//亮度
			half Y = 0.299*c.r + 0.587*c.g + 0.114*c.b;
			Y=(Y<=0.1?1:Y);
			half4 newC=_Color*(1-Y*Y)+c*Y*Y;
			o.Albedo = newC.rgb;
			c.a=tex2D(_MaskTex, IN.uv_MaskTex).a < _Progress||_Progress==1 ? 0 : c.a;
			o.Alpha = c.a;
		}
		ENDCG
	} 
	FallBack "Diffuse"
}
