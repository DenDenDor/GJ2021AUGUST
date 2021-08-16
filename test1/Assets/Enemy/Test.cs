using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Test : MonoBehaviour
{
    public delegate void MyDelegate();
    private delegate int ValueDeelegate(int i);
    public event MyDelegate Event;
    public Action _actiob;
    private void Start() {
        #region delegate
        MyDelegate _mydegate = Method1;
        MyDelegate _mydelegate2 = new MyDelegate(Method3);
        MyDelegate _mydelegate3 = _mydegate + _mydelegate2;
        ValueDeelegate valueDeelegate = new ValueDeelegate(Method22);
        valueDeelegate += Method22;
        Action<int> _action = Add;//Action = delegate void Action(int _something
        Predicate<int> _isCool = delegate (int x) { return x > 0; }; // Predicate = delegate bool Predicate(int value)
        if (_isCool(1))
        {
            
        }
        Func<int, int> func = Method22; // Func = delegate int Func(string x)
        if(func != null) //== func?.Inovke();
         func(7);
         #endregion
    
    Person person = new Person{Name = "Vasia"};
    person.GoToSleep += Person_GoToSleep;
    person.DoWork+= Person_DoWork;
    person.TakeTime(DateTime.Parse("14.08.2021 13:42:10"));
    person.TakeTime(DateTime.Parse("14.08.2021 23:42:10"));
    }
    private static void Person_GoToSleep()
    {
        Debug.Log("Man goes to sleep");
    }
    private static void Person_DoWork(object sender, EventArgs e)
    {
        if(sender is Person) // sender == Person
        {
        Debug.Log($"{((Person)sender).Name} works");
        }
    }
    public void Add(int x1)
{

}
    private void Method1()
    {

    }
    private void Method3()
    {
        
    }
    private static bool Method2(int i)
    {
        Debug.Log("s");
        return Method2(1);
    }
      private int Method22(int i)
    {
        Debug.Log("cool");
        return Method22(1);
    }
}
public class Person
{
    public event Action GoToSleep;
    public event EventHandler DoWork;
    public string Name {get; set;}

    public void TakeTime(DateTime now)
    {
        if (now.Hour <= 8)
        {
            GoToSleep?.Invoke();
        }
        else
        {
            DoWork?.Invoke(this,null );
        }
    }
}
