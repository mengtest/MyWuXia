// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 4.0.30319.1
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------
using System;
using UnityEngine;
using System.Reflection;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using UnityEngine.UI;

namespace Game
{
	public class Statics
	{
        
        /// <summary>
        /// 当前设备分辨率
        /// </summary>
        public static Vector2 Resolution = Vector2.zero;


		static Dictionary<string, Sprite> iconSpritesMapping;
		static Dictionary<string, Sprite> halfBodySpriteMapping;
        /// <summary>
        /// 静态逻辑初始化
        /// </summary>
        public static void Init() {
//            int height = 640;
//            int width = (int)((float)Screen.width / (float)Screen.height * height);
//            Resolution = new Vector2(width, height);
//            Screen.SetResolution((int)Resolution.x, (int)Resolution.y, true);
			iconSpritesMapping = new Dictionary<string, Sprite>();
			halfBodySpriteMapping = new Dictionary<string, Sprite>();
            //初始化消息机制
			NotifyBase.Init();
			//初始化本地数据库
			DbManager.Instance.CreateAllDbs(); 
        }
		/// <summary>
		/// Gets the angle.
		/// </summary>
		/// <returns>The angle.</returns>
		/// <param name="x1">The first x value.</param>
		/// <param name="y1">The first y value.</param>
		/// <param name="x2">The second x value.</param>
		/// <param name="y2">The second y value.</param>
		public static float GetAngle(float x1, float y1, float x2, float y2) {
			float angle = Mathf.Atan2(x2 - x1, y2 - y1) / Mathf.PI * 180;
			return angle >= 0 ? angle : angle + 360;
		}
		/// <summary>
		/// Gets the radian.
		/// </summary>
		/// <returns>The radian.</returns>
		/// <param name="angle">Angle.</param>
		public static float GetRadian(float angle) {
			return Mathf.PI / 180 * angle;
		}
		/// <summary>
		/// Gets the line aim by points.
		/// </summary>
		/// <returns>The line aim by points.</returns>
		/// <param name="x1">The first x value.</param>
		/// <param name="y1">The first y value.</param>
		/// <param name="x2">The second x value.</param>
		/// <param name="y2">The second y value.</param>
		/// <param name="lineHeight">Line height.</param>
		public static Vector2 GetLineAimByPoints(float x1, float y1, float x2, float y2, float lineHeight) {
			return GetLineAimByAngle(GetAngle(x1, y1, x2, y2), lineHeight);
		}
		/// <summary>
		/// Gets the line aim by angle.
		/// </summary>
		/// <returns>The line aim by angle.</returns>
		/// <param name="angle">Angle.</param>
		/// <param name="lineHeight">Line height.</param>
		public static Vector2 GetLineAimByAngle(float angle, float lineHeight) {
			return GetLineAimByRadian(GetRadian(angle), lineHeight);
		}
		/// <summary>
		/// Gets the line aim by radian.
		/// </summary>
		/// <returns>The line aim by radian.</returns>
		/// <param name="radian">Radian.</param>
		/// <param name="lineHeight">Line height.</param>
		public static Vector2 GetLineAimByRadian(float radian, float lineHeight) {
			return new Vector2(lineHeight * Mathf.Sin(radian), lineHeight * Mathf.Cos(radian));
		}

		/// <summary>
		/// Gets the circle point.
		/// </summary>
		/// <returns>The circle point.</returns>
		/// <param name="p">P.</param>
		/// <param name="r">The red component.</param>
		/// <param name="angle">Angle.</param>
		public static Vector2 GetCirclePoint(Vector2 p, float r, float angle) {
			return new Vector2(p.x + r * Mathf.Cos(angle * Mathf.PI / 180), p.y + r * Mathf.Sin(angle * Mathf.PI / 180));
		}

		/// <summary>
		/// 静态方法反射
		/// </summary>
		/// <param name="className"></param>
		/// <param name="methodName"></param>
		/// <param name="param"></param>
		public static bool CallStaticMethod(string className, string methodName, object[] param = null) {
			Type t = Type.GetType(className);
			if (t == null) {
				return false;
			}
			MethodInfo method = t.GetMethod(methodName);
			if (method != null) { 
				method.Invoke(null, param);
				return true;
			}
			return false;
		}
		
		/// <summary>
		/// 公共方法反射
		/// </summary>
		/// <param name="thisObj"></param>
		/// <param name="methodName"></param>
		/// <param name="param"></param>
		public static void CallPublicMethod(object thisObj, string methodName, object[] param) {
			Type t = thisObj.GetType();
			if (t == null) {
				return;
			}
			MethodInfo method = t.GetMethod(methodName);
			if (method != null) {
				method.Invoke(thisObj, param);
			}
		}

		/// <summary>
		/// 返回Resource路径下某个预设的克隆
		/// </summary>
		/// <param name="path">Resource路径</param>
		/// <returns>GameObject对象</returns>
		public static GameObject GetPrefabClone(string path) {
			return MonoBehaviour.Instantiate(Statics.GetPrefab(path)) as GameObject;
		}

		/// <summary>
		/// Gets the prefab clone.
		/// </summary>
		/// <returns>The prefab clone.</returns>
		/// <param name="clone">Clone.</param>
		public static GameObject GetPrefabClone(UnityEngine.Object clone) {
			return MonoBehaviour.Instantiate(clone) as GameObject;
		}

		/// <summary>
		/// Gets the prefab.
		/// </summary>
		/// <returns>The prefab.</returns>
		/// <param name="path">Path.</param>
		public static UnityEngine.Object GetPrefab(string path) {
			return Resources.Load(path, typeof(GameObject));
		}

		/// <summary>
		/// Gets the distance points.
		/// </summary>
		/// <returns>The distance points.</returns>
		/// <param name="from">From.</param>
		/// <param name="to">To.</param>
		/// <param name="distance">Distance.</param>
		public static List<Vector3> GetDistancePoints(Vector3 from, Vector3 to, float distance) {
			List<Vector3> points = new List<Vector3>();
			float num = Mathf.Ceil((Vector3.Distance(from, to) / distance) + 0.5f);
			float indexNum = 0;
			Vector3 cut = new Vector3((to.x - from.x) / num, from.y, (to.z - from.z) / num);
			while(indexNum++ < num - 1) {
				points.Add(new Vector3(from.x + cut.x * indexNum, cut.y, from.z + cut.z * indexNum));
			}
			points.Add(to);
			return points;
		}

		/// <summary>
		/// Determines if is pointer over U.
		/// </summary>
		/// <returns><c>true</c> if is pointer over U; otherwise, <c>false</c>.</returns>
		public static bool IsPointerOverUI() {
			return IPointerOverUI.Instance.IsPointerOverUIObject();
		}

		static float triangleArea(float v0x,float v0y,float v1x,float v1y,float v2x,float v2y) {
			return Mathf.Abs((v0x * v1y + v1x * v2y + v2x * v0y
			                  - v1x * v0y - v2x * v1y - v0x * v2y) / 2f);
		}
		/// <summary>
		/// Ises the IN triangle.
		/// </summary>
		/// <returns><c>true</c>, if IN triangle was ised, <c>false</c> otherwise.</returns>
		/// <param name="point">Point.</param>
		/// <param name="v0">V0.</param>
		/// <param name="v1">V1.</param>
		/// <param name="v2">V2.</param>
		public static bool IsInTriangle(Vector3 point,Vector3 v0,Vector3 v1,Vector3 v2) {
			float x = point.x;
			float y = point.z;
			
			float v0x = v0.x;
			float v0y = v0.z;
			
			float v1x = v1.x;
			float v1y = v1.z;
			
			float v2x = v2.x;
			float v2y = v2.z;
			
			float t = triangleArea(v0x,v0y,v1x,v1y,v2x,v2y);
			float a = triangleArea(v0x,v0y,v1x,v1y,x,y) + triangleArea(v0x,v0y,x,y,v2x,v2y) + triangleArea(x,y,v1x,v1y,v2x,v2y);
			
			if (Mathf.Abs(t - a) <= 0.01f) {
				return true;
			}
			else {
				return false;
			}
		}

		/// <summary>
		/// 多边形碰撞检测
		/// </summary>
		/// <returns><c>true</c>, if SA was polygoned, <c>false</c> otherwise.</returns>
		/// <param name="poly1">Poly1.</param>
		/// <param name="poly2">Poly2.</param>
		public static bool PolygonSAT(List<Vector3> poly1, List<Vector3> poly2) {
			bool allOutside;
			int alen = poly1.Count;
			int blen = poly2.Count;
			Vector3 pp = poly1[alen - 1];
			Vector3 qp;
			Vector3 vp;
			float nx;
			float nz;
			float ndotp;
			float det;
			for (int i = 0; i < alen; i++) {
				qp = poly1[i];
				//求法向量
				nx = qp.z - pp.z;
				nz = pp.x - qp.x;
				ndotp = nx * pp.x + nz * pp.z;
				allOutside = true;
				for (int j = 0; j < blen; j++) {
					vp = poly2[j];
					//判断一条边在共同面上的投影是否叠加来确定是否有一根线能切开两个多边形
					// det = N dot (V - P) = N dot V - N dot P
					det = nx * 	vp.x + nz * vp.z - ndotp;
					if (det < 0) { //叠加,不能切开
						allOutside = false;
						break;
					}
				}
				//如果有一个边和另一个多边形能够被一条直线切开的话就能判断两个都变形没有产生碰撞
				if (allOutside) {
					return false;
				}
				pp = qp; //继续检测下一个点
			}
			return true;
		}

		/// <summary>
		/// 获取Icon图标的Sprite对象
		/// </summary>
		/// <returns>The icon sprite.</returns>
		/// <param name="iconId">Icon identifier.</param>
		public static Sprite GetIconSprite(string iconId) {
			if (!iconSpritesMapping.ContainsKey(iconId)) {
				string iconSrc = JsonManager.GetInstance().GetMapping<JObject>("Icons", iconId)["Src"].ToString();
				iconSpritesMapping.Add(iconId, Resources.Load<GameObject>(iconSrc).GetComponent<Image>().sprite);
			}
			return iconSpritesMapping[iconId];
		}

		/// <summary>
		/// 获取半身像的Sprite对象
		/// </summary>
		/// <returns>The half body sprite.</returns>
		/// <param name="halfBodyId">Half body identifier.</param>
		public static Sprite GetHalfBodySprite(string halfBodyId) {
			if (!halfBodySpriteMapping.ContainsKey(halfBodyId)) {
				string src = JsonManager.GetInstance().GetMapping<JObject>("HalfBodys", halfBodyId)["Src"].ToString();
				halfBodySpriteMapping.Add(halfBodyId, Resources.Load<GameObject>(src).GetComponent<Image>().sprite);
			}
			return halfBodySpriteMapping[halfBodyId];
		}

		/// <summary>
		/// 2D矩形碰撞检测
		/// </summary>
		/// <returns><c>true</c>, if d was collision2ed, <c>false</c> otherwise.</returns>
		/// <param name="x1">The first x value.</param>
		/// <param name="y1">The first y value.</param>
		/// <param name="w1">W1.</param>
		/// <param name="h1">H1.</param>
		/// <param name="x2">The second x value.</param>
		/// <param name="y2">The second y value.</param>
		/// <param name="w2">W2.</param>
		/// <param name="h2">H2.</param>
		public static bool Collision2D (float x1, float y1, float w1, float h1, float x2, float y2, float w2, float h2) {
			//_that.canvas.fillStyle('#FF0000').fillRect(x1, y1, w1, h1).fillStyle('#0000FF').fillRect(x2, y2, w2, h2);
			if(Mathf.Abs((x1 + (w1 * 0.5f)) - (x2 + (w2 * 0.5f))) < ((w1 + w2) * 0.5f) && Mathf.Abs((y1 + (h1 * 0.5f)) - (y2 + (h2 * 0.5f))) < ((h1 + h2) * 0.5f)) {
				return true;
			}
			return false;
		}
	}
}

