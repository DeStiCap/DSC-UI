using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DSC.UI
{
    public static class UIUtility
    {
        /// <summary>
        /// Get angle for draw vertice in UI.
        /// </summary>
        /// <param name="vStart"></param>
        /// <param name="vEnd"></param>
        /// <returns></returns>
        public static float GetAngle(Vector2 vStart, Vector2 vEnd)
        {
            //panel resolution go there in place of 9 and 16
            return (float)(Mathf.Atan2(9f * (vEnd.y - vStart.y), 16f * (vEnd.x - vStart.x)) * (180 / Mathf.PI));
        }

        public static void DrawVerticesForPoint(Vector2 point, Vector2 point2, float thickness
            , float angle, Color color, VertexHelper vh)
        {
            UIVertex vertex = UIVertex.simpleVert;
            vertex.color = color;

            vertex.position = Quaternion.Euler(0, 0, angle) * new Vector3(-thickness / 2, 0);
            vertex.position += new Vector3(point.x, point.y);
            vh.AddVert(vertex);

            vertex.position = Quaternion.Euler(0, 0, angle) * new Vector3(thickness / 2, 0);
            vertex.position += new Vector3(point.x, point.y);
            vh.AddVert(vertex);

            vertex.position = Quaternion.Euler(0, 0, angle) * new Vector3(-thickness / 2, 0);
            vertex.position += new Vector3(point2.x, point2.y);
            vh.AddVert(vertex);

            vertex.position = Quaternion.Euler(0, 0, angle) * new Vector3(thickness / 2, 0);
            vertex.position += new Vector3(point2.x, point2.y);
            vh.AddVert(vertex);
        }

        public static void DrawLine(List<Vector2> lstPoint, float thickness, Color color
            , VertexHelper vh)
        {
            vh.Clear();


            if (lstPoint == null || lstPoint.Count < 2) 
                return;


            float angle = 0;
            for (int i = 0; i < lstPoint.Count - 1; i++)
            {

                Vector2 point = lstPoint[i];
                Vector2 point2 = lstPoint[i + 1];

                if (i < lstPoint.Count - 1)
                {
                    angle = UIUtility.GetAngle(lstPoint[i], lstPoint[i + 1]) + 90f;
                }

                UIUtility.DrawVerticesForPoint(point, point2, thickness, angle, color, vh);
            }

            for (int i = 0; i < lstPoint.Count - 1; i++)
            {
                int index = i * 4;
                vh.AddTriangle(index + 0, index + 1, index + 2);
                vh.AddTriangle(index + 1, index + 2, index + 3);
            }
        }
    }
}
