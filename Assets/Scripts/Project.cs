using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Project
{
    private string _alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

    private string _projectName;
    private float _duration;
    private int _reward, _penalty, _difficulty, _deadline;
    private bool _isTaken;

    public Project()
    {
        _isTaken = false;
        _difficulty = Random.Range(1, 6);
        _duration = Random.Range(1, 10) * 100f;
        _deadline = (int)(_duration / GameManager.DAY) + GameObject.Find("GameManager").GetComponent<GameManager>().CurrentDay;
        _reward = _difficulty * 1000 + (int)_duration * 10;
        _penalty = _reward / 2;
        _projectName = "Project " + _alphabet[Random.Range(0, _alphabet.Length)] + Random.Range(1, 130).ToString();
    }

    public string Name
    {
        get { return _projectName; }
        private set { }
    }

    public float Duration
    {
        get { return _duration; }
        private set { }
    }

    public int Reward
    {
        get { return _reward; }
        private set { }
    }

    public int Penalty
    {
        get { return _penalty; }
        private set { }
    }

    public int Difficulty
    {
        get { return _difficulty; }
        private set { }
    }

    public int Deadline
    {
        get { return _deadline; }
        private set { }
    }

    public bool IsTaken
    {
        get { return _isTaken; }
        private set { }
    }

    private void Update()
    {
        if (_isTaken == true)
        {
            _duration -= Time.deltaTime;
        }
    }
}
