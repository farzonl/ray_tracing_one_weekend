using raytracing.DataStructures;

namespace raytracing_test;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }
    [Test]
    public void TestVectorValues()
    {
        Vec3<float> a = new Vec3<float>(1,2,3);
        Assert.That(a.x, Is.EqualTo(a.r));
        Assert.That(a.y, Is.EqualTo(a.g));
        Assert.That(a.z, Is.EqualTo(a.b));
         Assert.That(a.x, Is.EqualTo(a[0]));
        Assert.That(a.y, Is.EqualTo(a[1]));
        Assert.That(a.z, Is.EqualTo(a[2]));
        Assert.That(a.x, Is.EqualTo(1));
        Assert.That(a.y, Is.EqualTo(2));
        Assert.That(a.z, Is.EqualTo(3));

    }

    [Test]
    public void TestVectorSet()
    {
        Vec3<float> a = new Vec3<float>(0, 0, 0);
        a.x = 1;
        a.y = 2;
        a.z = 3;
        Assert.That(a.x, Is.EqualTo(1));
        Assert.That(a.y, Is.EqualTo(2));
        Assert.That(a.z, Is.EqualTo(3));
        a[0] = 2;
        a[1] = 3;
        a[2] = 1;
        Assert.That(a.x, Is.EqualTo(2));
        Assert.That(a.y, Is.EqualTo(3));
        Assert.That(a.z, Is.EqualTo(1));

        a.r = 1;
        a.g = 2;
        a.b = 3;
        Assert.That(a.x, Is.EqualTo(1));
        Assert.That(a.y, Is.EqualTo(2));
        Assert.That(a.z, Is.EqualTo(3));

    }

    [Test]
    public void TestVectorAdd()
    {
        Vec3<float> a = new Vec3<float>(1,1,1);
        Vec3<float> b = new Vec3<float>(1,1,1);
        Vec3<float> c = a + b;
        Assert.That(c.x, Is.EqualTo(2));
        Assert.That(c.y, Is.EqualTo(2));
        Assert.That(c.z, Is.EqualTo(2));
    }

    [Test]
    public void TestBoundsCheckForVector()
    {
        Vec3<float> a = new Vec3<float>(1, 1, 1);
        // get using a delegate
        Assert.Throws<ArgumentOutOfRangeException>(() => { var b = a[-1]; });
        Assert.Throws<ArgumentOutOfRangeException>(() => { var b = a[3]; });

        // set using a delegate
        Assert.Throws<ArgumentOutOfRangeException>(() => { a[-1] = 1.0f; });
        Assert.Throws<ArgumentOutOfRangeException>(() => { a[3] = 1.0f; });
    }

        [Test]
    public void TestVectorAddEqual()
    {
        Vec3<float> a = new Vec3<float>(1,1,1);
        a += a;
        Assert.That(a.x, Is.EqualTo(2));
        Assert.That(a.y, Is.EqualTo(2));
        Assert.That(a.z, Is.EqualTo(2));
    }

    [Test]
    public void TestVectorSubtract()
    {
        Vec3<float> a = new Vec3<float>(1,1,1);
        Vec3<float> b = new Vec3<float>(1,1,1);
        Vec3<float> c = a - b;
        Assert.That(c.x, Is.EqualTo(0));
        Assert.That(c.y, Is.EqualTo(0));
        Assert.That(c.z, Is.EqualTo(0));
    }
    [Test]
    public void TestVectorSubtractEqual()
    {
        Vec3<float> a = new Vec3<float>(1,1,1);
        a -= a;
        Assert.That(a.x, Is.EqualTo(0));
        Assert.That(a.y, Is.EqualTo(0));
        Assert.That(a.z, Is.EqualTo(0));
    }

    [Test]
    public void TestVectorNegation()
    {
        Vec3<float> a = new Vec3<float>(1,1,1);
        Vec3<float> b = -a;
        Assert.That(b.x, Is.EqualTo(-1));
        Assert.That(b.y, Is.EqualTo(-1));
        Assert.That(b.z, Is.EqualTo(-1));
    }

    [Test]
    public void TestVectorMultiplication()
    {
        Vec3<float> a = new Vec3<float>(1,2,1);
        Vec3<float> b = new Vec3<float>(2,1,3);
        Vec3<float> c = a * b;
        Assert.That(c.x, Is.EqualTo(2));
        Assert.That(c.y, Is.EqualTo(2));
        Assert.That(c.z, Is.EqualTo(3));
    }
    [Test]
    public void TestVectorMultiplyEqual()
    {
        Vec3<float> a = new Vec3<float>(1,2,1);
        Vec3<float> b = new Vec3<float>(2,1,3);
        a *=  b;
        Assert.That(a.x, Is.EqualTo(2));
        Assert.That(a.y, Is.EqualTo(2));
        Assert.That(a.z, Is.EqualTo(3));
    }

     public void TestVectorMultiplyLiteral()
    {
        Vec3<float> a = new Vec3<float>(1,2,1);
        Vec3<float> c = a * 2;
        Assert.That(c.x, Is.EqualTo(2));
        Assert.That(c.y, Is.EqualTo(4));
        Assert.That(c.z, Is.EqualTo(6));
    }

    [Test]
    public void TestVectorMultiplyLiteralEqual()
    {
        Vec3<float> a = new Vec3<float>(1,2,1);
        a *=  2;
        Assert.That(a.x, Is.EqualTo(2));
        Assert.That(a.y, Is.EqualTo(4));
        Assert.That(a.z, Is.EqualTo(2));
    }

    [Test]
    public void TestVectorDivide()
    {
        Vec3<float> a = new Vec3<float>(6,4,2);
        Vec3<float> b = new Vec3<float>(2,2,2);
        Vec3<float> c = a / b;
        Assert.That(c.x, Is.EqualTo(3));
        Assert.That(c.y, Is.EqualTo(2));
        Assert.That(c.z, Is.EqualTo(1));
        Vec3<float> d = new Vec3<float>(9,8,6);
        Vec3<float> e = new Vec3<float>(3,4,3);
        Vec3<float> f = d / e;
        Assert.That(f.x, Is.EqualTo(3));
        Assert.That(f.y, Is.EqualTo(2));
        Assert.That(f.z, Is.EqualTo(2));
    }

    [Test]
    public void TestVectorDivideEqual()
    {
        Vec3<float> a = new Vec3<float>(6,4,2);
        Vec3<float> b = new Vec3<float>(2,2,2);
        a /=  b;
        Assert.That(a.x, Is.EqualTo(3));
        Assert.That(a.y, Is.EqualTo(2));
        Assert.That(a.z, Is.EqualTo(1));
    }

    [Test]
    public void TestVectorDivideLiteral()
    {
        Vec3<float> a = new Vec3<float>(6,4,2);
        Vec3<float> c = a / 2;
        Assert.That(c.x, Is.EqualTo(3));
        Assert.That(c.y, Is.EqualTo(2));
        Assert.That(c.z, Is.EqualTo(1));
    }

    [Test]
    public void TestVectorDivideByLiteralEqual()
    {
        Vec3<float> a = new Vec3<float>(6,4,2);
        a /=  2;
        Assert.That(a.x, Is.EqualTo(3));
        Assert.That(a.y, Is.EqualTo(2));
        Assert.That(a.z, Is.EqualTo(1));
    }
}