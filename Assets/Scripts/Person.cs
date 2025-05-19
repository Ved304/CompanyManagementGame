using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person
{
    string[] _names = { "Adam", "John", "Robert", "James", "Thomas", "David", "Simon", "Jack", "Peter", "Andrew", "Anne", "Jane", "Alice", "Clarice", "Sofia", "Emma", "Lucy", "Elizabeth", "Zoe", "Sarah" };
    string[] _surnames = { "Doe", "Smith", "Jones", "Babbage", "Moore", "White", "Brown", "Anderson", "McDonald", "Mitchel", "Graham", "Wilson", "Harris", "Powell", "Williams", "Hall", "Fuller", "Clark", "Wright", "House", "Burton", "Murphy" };

    private string _name;
    private int _salary, _skill;

    public Person()
    {
        _name = _names[Random.Range(0, _names.Length)] + _surnames[Random.Range(0, _names.Length)];
        _skill = Random.Range(1, 6);
        _salary = (_skill + 1) * 1000;
    }

    public string Name
    { 
        get { return _name; }
        private set { }
    }

    public int Salary
    {
        get { return _salary; }
        private set { }
    }

    public int Skill
    {
        get { return _skill; }
        private set { }
    }
}
