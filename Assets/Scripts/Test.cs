using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    void Start()
    {
        TestStruct a = new TestStruct(1, 2);
        TestStruct b = new TestStruct(3, 4);
        b.a = 666;
        Debug.Log(b.ToString());
        Debug.Log(a.ToString());
    }
}


struct TestStruct
{
    public int a;
    public int b;

    public TestStruct(int a, int b)
    {
        this.a = a;
        this.b = b;
    }

    public override string ToString()
    {
        return $"a: {a}, b: {b}";
    }
}