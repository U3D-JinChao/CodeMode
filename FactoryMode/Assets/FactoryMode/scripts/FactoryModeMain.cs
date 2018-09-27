using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryModeMain : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        //MainStart();
        MainStart_New();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void MainStart()
    {
        Factory_old factory1 = new Factory_old(E_FactoryType.type1);
        Factory_old factory2 = new Factory_old(E_FactoryType.type2); 
        Factory_old factory3 = new Factory_old(E_FactoryType.type3);
        factory1.PrintFactoryType();
        factory2.PrintFactoryType();
        factory3.PrintFactoryType();
    }

    void MainStart_New()
    {
        List<Type> list = new List<Type>();
        Type f1 = new Type1();
        Type f2 = new Type2();
        Type f3 = new Type3();
        list.Add(f1);
        list.Add(f2);
        list.Add(f3);

        foreach (IPrint item in list)
        {
            item.PrintFactoryType();
        }
    }
}


#region old
public enum E_FactoryType
{
    type1,
    type2,
    type3
}
public class Factory_old
{
    private string name;
    public Factory_old(E_FactoryType type)
    {
        name = type.ToString();
        Debug.Log("start_old : " + name);
    }

    public void PrintFactoryType()
    {
        Debug.Log("end_old : " + name);
    }
}
#endregion

#region new

public interface IPrint
{
    void PrintFactoryType();
}

public abstract class Type : IPrint
{
    public abstract void PrintFactoryType();
}

public class Type1 : Type
{
    public Type1()
    {
        Debug.Log("start_new : Type1");
    }
    public override void PrintFactoryType()
    {
        Debug.Log("end_new : Type1");
    }
}
public class Type2 : Type
{
    public Type2()
    {
        Debug.Log("start_new : Type2");
    }
    public override void PrintFactoryType()
    {
        Debug.Log("end_new : Type2");
    }
}
public class Type3 : Type
{
    public Type3()
    {
        Debug.Log("start_new : Type3");
    }
    public override void PrintFactoryType()
    {
        Debug.Log("end_new : Type3");
    }
}

public class Factory_new
{
    Type mType;
    public Factory_new(Type type)
    {
        mType = type;
    }
}


#endregion

