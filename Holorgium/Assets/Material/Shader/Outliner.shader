Shader "Custom/Outliner" {

Properties {
_edge("Edge Amount",Range(0,10)) = 0
_edge2("Edge Amount",Float) = 0
_Color ("outlineColor", Color) = (1,1,0,1)
_ColorSup ("ChangeColor", Color) = (1,1,0,1)
}

 SubShader {

	  Pass {

	  		cull Back
            CGPROGRAM
            

            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"
            #include "UnityLightingCommon.cginc"

            struct ludoAppData {

                float4 vertex : POSITION;
                float4 normal : NORMAL;

            };

            struct V2f {

                fixed4 diff : COLOR;
                float4 myVertex : SV_POSITION;
            };
            
           
           V2f vert ( ludoAppData data ){
                V2f myv2f;
                myv2f.myVertex = UnityObjectToClipPos( data.vertex );

                half3 worldNormal = UnityObjectToWorldNormal (data.normal);
                half nl = max(0,dot(worldNormal,_WorldSpaceLightPos0.xyz));
                myv2f.diff = nl * _LightColor0;
                return  myv2f;
           }

          
            fixed4 _ColorSup;

            fixed4 frag(V2f i) : COLOR {

                fixed4 col = i.diff*_ColorSup;

                return col;
            }

            ENDCG
        }

      

       Pass {

            Cull Front
             ZTest on
            // pour annuler le zBuffer 

            CGPROGRAM         

            #pragma vertex vert
            #pragma fragment frag           

            #include "UnityCG.cginc"

             float _edge;
             float _edge2;
            fixed4 _Color;

           v2f_img vert(appdata_base v){
               v2f_img o;
               o.pos = UnityObjectToClipPos(v.vertex + v.normal * _edge +_edge2);
                              
               return o;
           }

            fixed4 frag(v2f_img i) : COLOR {

            return _Color;
            }

            ENDCG

        }

     

    } 


}
