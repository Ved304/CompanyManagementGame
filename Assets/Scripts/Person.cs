using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person
{
    string[] _names = { "Adam", "John", "Robert", "James", "Thomas", "David", "Simon", "Jack", "Peter", "Andrew", "Walter", "Michael", "Henry", "Albert", "Anne", "Jane", "Alice", "Clarice", "Sofia", "Emma", "Lucy", "Elizabeth", "Zoe", "Sarah", "Chloe", "Helena", "Jessica", "Margaret" };
    string[] _surnames = { "Doe", "Smith", "Jones", "Babbage", "Moore", "White", "Brown", "Anderson", "McDonald", "Mitchel", "Graham", "Wilson", "Harris", "Powell", "Williams", "Hall", "Fuller", "Clark", "Wright", "House", "Burton", "Murphy", "Taylor", "Evans", "Appleby", "Fairfax", "Fox", "Ellison", "Garret", "Kettle", "Linfield", "Young", "Osborne", "Oxenham", "Perkins", "Piper", "Parker", "Tibbett", "Troutman", "Wadlow", "Wallace", "Voyle", "Vickers", "Upton", "Thorne", "Maxwell", "McTavish", "Miller", "Mosley", "Wild", "Wilcox", "Waters", "Armstrong", "Allbrook", "Albinson", "Baker", "Coldwell", "Carpenter", "Cook", "Jenkins", "Lake" };

    private string _fullName;
    private int _salary, _skill;

    public Person()
    {
        _fullName = _names[Random.Range(0, _names.Length)] + " " + _surnames[Random.Range(0, _surnames.Length)];
        _skill = Random.Range(1, 6);
        _salary = (_skill + 1) * 1000;
    }

    public string Name
    { 
        get { return _fullName; }
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
