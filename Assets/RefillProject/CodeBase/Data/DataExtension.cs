using UnityEngine;

namespace Assets.RefillProject.CodeBase.Data
{
    public static class DataExtension
    {
        public static Vector3Data AsVectorData(this Vector3 vector) => 
            new Vector3Data(vector.x, vector.y, vector.z);

        public static Vector3 AsUnityVector(this Vector3Data vector) =>
            new Vector3(vector.X,vector.Y,vector.Z);

        public static T ToDeserialize<T>(this string json) =>
            JsonUtility.FromJson<T>(json);

        public static string ToJson(this object obj) => 
            JsonUtility.ToJson(obj);

        public static Vector3 AddY(this Vector3 vector, float y)
        {
            y = 15;

            vector.y += y;
            return vector;
        }

        public static float SqrMagnitudeTo(this Vector3 from, Vector3 to) =>
            Vector3.SqrMagnitude(to - from);
    }
}
