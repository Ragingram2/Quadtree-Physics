using System;

public struct Vec2
{
    public float x;
    public float y;

    public Vec2(float pX = 0, float pY = 0)
    {
        x = pX;
        y = pY;
    }
    public Vec2 Add(Vec2 other)
    {
        x += other.x;
        y += other.y;
        return this;
    }
    public Vec2 Subtract(Vec2 other)
    {
        x -= other.x;
        y -= other.y;
        return this;
    }
    public Vec2 Scale(float scalar)
    {
        x *= scalar;
        y *= scalar;
        return this;
    }
    public Vec2 Negative()
    {
        this = new Vec2(-Math.Abs(x), -Math.Abs(y));
        return this;
    }
    public Vec2 NegativeX()
    {
        x = -Math.Abs(x);
        return this;
    }
    public Vec2 NegativeY()
    {
        y = -Math.Abs(y);
        return this;
    }
    public Vec2 Positive()
    {
        this = new Vec2(Math.Abs(x), Math.Abs(y));
        return this;
    }
    public Vec2 PositiveX()
    {
        x = Math.Abs(x);
        return this;
    }
    public Vec2 PositiveY()
    {
        y = Math.Abs(y);
        return this;
    }
    public float Length()
    {
        return (float)Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
    }
    public float Dot(Vec2 input)
    {
        return (input.x * x) + (input.y * y);
    }
    public Vec2 SetLength(float len)
    {
        Normalize();
        Scale(len);
        return this;

    }
    public Vec2 Normalize()
    {
        float oldLength = Length();
        if ((int)oldLength == 0) { return this; }
        x /= oldLength;
        y /= oldLength;
        return this;
    }
    public Vec2 Normal()
    {
        return new Vec2(-Normalized().y, Normalized().x);
    }
    public Vec2 Normalized()
    {
        return new Vec2(x, y).Normalize();
    }
    public Vec2 SetXY(float _x, float _y)
    {
        x = _x;
        y = _y;
        return this;
    }
    public Vec2 SetXY(Vec2 other)
    {
        x = other.x;
        y = other.y;
        return this;
    }
    public static Vec2 PointOfImpact(Vec2 oldPos, float t, Vec2 vel)
    {
        return oldPos + (t * vel);
    }
    public static float Deg2Rad(float degs)
    {
        return (float)(degs * (Math.PI / 180f));
    }
    public static float Rad2Deg(float rads)
    {
        return (float)(rads * (180 / Math.PI));
    }
    public static Vec2 GetUnitVectorDeg(float degs)
    {
        return new Vec2((float)Math.Cos(Deg2Rad(degs)), (float)Math.Sin(Deg2Rad(degs)));
    }
    public static Vec2 GetUnitVectorDegAroundPoint(float degs, Vec2 point)
    {
        return new Vec2((float)Math.Cos(Deg2Rad(degs)) + point.x, (float)Math.Sin(Deg2Rad(degs)) + point.y);
    }
    public static Vec2 GetUnitVectorRad(float rads)
    {
        rads *= (float)Math.PI;
        return new Vec2((float)Math.Cos(rads), (float)Math.Sin(rads));
    }
    public static Vec2 RandomUnitVector()
    {
        Random rnd = new Random();
        return GetUnitVectorDeg(rnd.Next(0, 360));
    }
    public Vec2 SetAngleDegrees(float degs)
    {
        float len = Length();
        this = GetUnitVectorDeg(degs);
        SetLength(len);
        //x = (float)(x * Mathf.Cos(degs) - y * Math.Sin(degs));
        //y = (float)(x * Mathf.Sin(degs) + y * Math.Cos(degs));
        return this;
    }
    public Vec2 SetAngleRadians(float rads)
    {
        float len = Length();
        this = GetUnitVectorRad(rads);
        SetLength(len);
        return this;

    }
    public float GetAngleRadians()
    {
        return (float)Math.Atan2(y, x);
    }
    public float GetAngleDegrees()
    {
        return Rad2Deg((float)Math.Atan2(y, x));
    }
    public Vec2 RotateDegrees(float degs)
    {
        return SetAngleDegrees(GetAngleDegrees() + degs);
    }
    public Vec2 RotateRadians(float rads)
    {
        return SetAngleRadians(GetAngleRadians() + rads);
    }
    public Vec2 RotateAroundDegrees(Vec2 rotPoint, float degs)
    {
        return RotateAroundRadians(rotPoint, Deg2Rad(degs));
    }
    public Vec2 RotateAroundRadians(Vec2 rotPoint, float rads)
    {
        Subtract(rotPoint);
        SetAngleRadians(rads);
        Add(rotPoint);
        return this;
    }
    public void Reflect(Vec2 pNormal, float pBounciness = 1)
    {
        this -= (1 + pBounciness) * (Dot(pNormal) * pNormal);
    }
    public void ReflectMomentum(Vec2 pNormal, Vec2 ColMVelocity, float pBounciness = 1)
    {
        this -= (1 + pBounciness) * ((this - ColMVelocity).Dot(pNormal) * pNormal);
    }
    public static Vec2 operator +(Vec2 left, Vec2 right)
    {
        return new Vec2(left.x + right.x, left.y + right.y);
    }
    public static Vec2 operator -(Vec2 left, Vec2 right)
    {
        return new Vec2(left.x - right.x, left.y - right.y);
    }
    public static Vec2 operator *(Vec2 left, float right)
    {
        return new Vec2(left.x * right, left.y * right);
    }
    public static Vec2 operator *(float left, Vec2 right)
    {
        return new Vec2(left * right.x, left * right.y);
    }
    public static Vec2 operator *(Vec2 left, Vec2 right)
    {
        return new Vec2(left.x * right.x, left.y * right.y);
    }
    public static Vec2 operator /(Vec2 left, Vec2 right)
    {
        return new Vec2(left.x / right.x, left.y / right.y);
    }
    public static Vec2 operator /(Vec2 left, float right)
    {
        return new Vec2(left.x / right, left.y / right);
    }
    public static bool operator !=(Vec2 left, Vec2 right)
    {
        return left.x != right.x || left.y != right.y;
    }
    public static bool operator ==(Vec2 left, Vec2 right)
    {
        return left.x == right.x && left.y == right.y;
    }


    public override string ToString()
    {
        return String.Format("({0},{1})", x, y);
    }
}

