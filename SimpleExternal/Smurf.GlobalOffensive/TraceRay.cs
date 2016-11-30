﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Smurf.GlobalOffensive
{
    class TraceRay
    {
        //http://www.unknowncheats.me/forum/counterstrike-global-offensive/136361-external-ray-tracing-ray-aabb.html
        Vector3 _origin;
        Vector3 _direction;

        Vector3 _directionInverse;
        public void Ray(Vector3 _origin, Vector3 _direction)
        {
            this._origin = _origin;
            this._direction = _direction;

            _directionInverse.X = 1f / this._direction.X;
            _directionInverse.Y = 1f / this._direction.Y;
            _directionInverse.Z = 1f / this._direction.Z;
        }

        public TraceRay(Vector3 _origin, Vector3 _direction)
        {
            this._origin = _origin;
            this._direction = _direction;
            _directionInverse = new Vector3(1f / this._direction.X, 1f / this._direction.Y, 1f / this._direction.Z);
        }

        public static Vector3 AngleToDirection(Vector3 angle)
        {
            angle.X = (float) (angle.X * 3.14159265 / 180);
            angle.Y = (float) (angle.Y * 3.14159265 / 180);

            float sinYaw = (float)Math.Sin(angle.Y);
            float cosYaw = (float)Math.Cos(angle.Y);

            float sinPitch = (float)Math.Sin(angle.X);
            float cosPitch = (float)Math.Cos(angle.X);

            Vector3 direction = angle;
            direction.X = cosPitch * cosYaw;
            direction.Y = cosPitch * sinYaw;
            direction.Z = -sinPitch;

            return direction;
        }

        public bool Trace(Vector3 leftbottom, Vector3 righttop, ref float distance)
        {

            if ((_direction.X == 0f & (_origin.X < Math.Min(leftbottom.X, righttop.X) | _origin.X > Math.Max(leftbottom.X, righttop.X))))
                return false;

            if ((_direction.Y == 0f & (_origin.Y < Math.Min(leftbottom.Y, righttop.Y) | _origin.Y > Math.Max(leftbottom.Y, righttop.Y))))
                return false;

            //if (direction.Z == 0f & (origin.Z < Math.Min(leftbottom.Z, righttop.Z | origin.Z > Math.Max(leftbottom.Z, righttop.Z))))
            //    return false;

            if (_direction.Z == 0f & (_origin.Z < Math.Min(leftbottom.Z, righttop.Z) | _origin.Z > Math.Max(leftbottom.Z, righttop.Z)))
                return false;

            float t1 = (leftbottom.X - _origin.X) * _directionInverse.X;
            float t2 = (righttop.X - _origin.X) * _directionInverse.X;
            float t3 = (leftbottom.Y - _origin.Y) * _directionInverse.Y;
            float t4 = (righttop.Y - _origin.Y) * _directionInverse.Y;
            float t5 = (leftbottom.Z - _origin.Z) * _directionInverse.Z;
            float t6 = (righttop.Z - _origin.Z) * _directionInverse.Z;

            float tmin = Math.Max(Math.Max(Math.Min(t1, t2), Math.Min(t3, t4)), Math.Min(t5, t6));
            float tmax = Math.Min(Math.Min(Math.Max(t1, t2), Math.Max(t3, t4)), Math.Max(t5, t6));

            if (tmax < 0)
            {
                distance = tmax;
                return false;
            }

            if (tmin > tmax)
            {
                distance = tmax;
                return false;
            }

            distance = tmin;
            return true;
        }
    }
}
