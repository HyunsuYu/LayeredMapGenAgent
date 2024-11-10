using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LayeredMapGenAgent.Internal.Data
{
    public struct Vector2Int
    {
        public int x { get; set; }
        public int y { get; set; }


        public Vector2Int()
        {
            x = 0;
            y = 0;
        }
        public Vector2Int(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public static Vector2Int zero
        {
            get
            {
                return new Vector2Int(0, 0);
            }
        }
        public static Vector2Int one
        {
            get
            {
                return new Vector2Int(1, 1);
            }
        }

        public static bool operator ==(Vector2Int a, Vector2Int b)
        {
            return a.x == b.x && a.y == b.y;
        }
        public static bool operator !=(Vector2Int a, Vector2Int b)
        {
            return a.x != b.x || a.y != b.y;
        }
    }
    public struct Vector3Int
    {
        public int x { get; set; }
        public int y { get; set; }
        public int z { get; set; }


        public Vector3Int()
        {
            x = 0;
            y = 0;
            z = 0;
        }
        public Vector3Int(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public static float Distance(in Vector3Int pos_0, in Vector3Int pos_1)
        {
            return Vector3.Distance(new Vector3()
            {
                x = pos_0.x,
                y = pos_0.y,
                z = pos_0.z
            },
            new Vector3()
            {
                x = pos_1.x,
                y = pos_1.y,
                z = pos_1.z
            });
        }

        public static bool operator ==(Vector3Int a, Vector3Int b)
        {
            return a.x == b.x && a.y == b.y && a.z == b.z;
        }
        public static bool operator !=(Vector3Int a, Vector3Int b)
        {
            return a.x != b.x || a.y != b.y || a.z != b.z;
        }
    }

    public struct Vector2
    {
        public float x, y;
    }
    public struct Vector3
    {
        public float x, y, z;


        public float magnitude
        {
            get
            {
                return MathF.Sqrt(MathF.Pow(x, 2.0f) +
                                  MathF.Pow(y, 2.0f) +
                                  MathF.Pow(z, 2.0f));
            }
        }

        public static float Distance(in Vector3 pos_0, in Vector3 pos_1)
        {
            return MathF.Sqrt(MathF.Pow(pos_1.x - pos_0.x, 2.0f) +
                              MathF.Pow(pos_1.y - pos_0.y, 2.0f) +
                              MathF.Pow(pos_1.z - pos_0.z, 2.0f));
        }
    }
    public struct Vector4
    {
        public float x, y, z, w;


        public Vector4()
        {
            x = 0.0f;
            y = 0.0f;
            z = 0.0f;
            w = 0.0f;
        }
        public Vector4(float x, float y, float z, float w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }

        public static bool operator ==(Vector4 a, Vector4 b)
        {
            return a.x == b.x && a.y == b.y && a.z == b.z && a.w == b.w;
        }
        public static bool operator !=(Vector4 a, Vector4 b)
        {
            return a.x != b.x || a.y != b.y || a.z != b.z || a.w != b.w;
        }
    }
}