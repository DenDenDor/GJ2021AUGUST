using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Programm : MonoBehaviour
{

    [SerializeField] private int _number;
    private string _name;

    public string Name { get => _name; set => _name = value; }
    
    private void Start() {
        Debug.Log($"{Name} :SSfsd");
        int i = Print();
        int x = Number(_number);
        Func<int, int> func = MyNumber;
        int _x = Add(_number, func);
        Debug.Log(_x);

    }
    private int Add(int y, Func<int, int> reff)
    {
        int result= 0;
        if (1 < y)
        {
            result = reff(y);
        }
        return result;
    }
    private int MyNumber(int value)
    {
        int result = 0;
        if(!(value == 0 || value == 1))
        {
          for (int i = 0; i < value ;i++)
        {
            result = i - 1 + i - 2;
        }
        }
        return result;
    }
    private int Number(int value)
    {
        if (value == 0 || value == 1)
        {
          return value;
        }
        else
        {
          return  Number(value - 1) + Number(value - 2);
        }

    }
  
    public int Print()
    {
        //return 3;
        Apple _apple1 = new Apple(10);
        Apple _apple2 = new Apple(32);
        var sum = _apple1 + _apple2;
        Debug.Log(_apple1 == _apple2);
        Debug.Log(_apple1 >= _apple2);
        return 3;
    }
    public Programm(string name)
    {
        
        Name = name;
    }
}
public  abstract class Product
{
  private int _money;

    public int Money { get => _money; set => _money = value; }
    public Product(int price)
    {
        Money = price;
    }
}

public class Apple : Product
{
    public Apple(int price) : base(price)
    {
    }

    public override bool Equals(object obj)
    {
        return obj is Apple apple &&
               Money == apple.Money;
    }

    public override int GetHashCode()
    {
        return -123698105 + Money.GetHashCode();
    }

    public static Apple operator + (Apple apple1, Apple apple2)
    {
        Apple apple =new  Apple(apple1.Money + apple2.Money);
        return apple;
    }
    public static bool operator == (Apple apple1, Apple apple2)
    {
        
        return apple1.Money == apple2.Money;
    }
    public static bool operator != (Apple apple1, Apple apple2)
    {
        return apple1.Money == apple2.Money;
    }
     public static bool operator <= (Apple apple1, Apple apple2)
    {
        
        return apple1.Money <= apple2.Money;
    }
    public static bool operator >= (Apple apple1, Apple apple2)
    {
        return apple1.Money <= apple2.Money;
    }
    public static bool operator < (Apple apple1, Apple apple2)
    {
        
        return apple1.Money < apple2.Money;
    }
    public static bool operator >(Apple apple1, Apple apple2)
    {
        return apple1.Money < apple2.Money;
    }
}

