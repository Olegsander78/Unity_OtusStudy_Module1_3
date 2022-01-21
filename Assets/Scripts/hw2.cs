using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class hw2 : MonoBehaviour
{
    public Toggle ToggleArray;
    public InputField IFieldIntVar;
    public InputField IFieldFloatVar;
    public InputField IFieldValueArray;
    public Text TextViewArray;
    public Text TextIntVar;
    public Text TextFloatVar;

    [SerializeField] private int _startVeriableInt = 1;
    [SerializeField] private float _startVeriableFloat = 1f;
    [SerializeField] private int _arrayLenght;
    [SerializeField] private bool _isIntArray = true;
    [SerializeField] private int[] _intArray;
    [SerializeField] private float[] _floatArray;


    private void Update()
    {
        SwitchInputTypeArray();
    }

    public void GetVariablesFromIField()
    {
        _arrayLenght = int.Parse(IFieldValueArray.text);
        if (!int.TryParse(IFieldIntVar.text, out _startVeriableInt))
        {
            Debug.LogWarning("Invalid Int, try to enter both veriables!");
        }        
        if (!float.TryParse(IFieldFloatVar.text, out _startVeriableFloat))
        {
            Debug.LogWarning("Invalid Float, try to enter both veriables!");
        }
        //_startVeriableInt = int.Parse(IFieldIntVar.text);
        //_startVeriableFloat = float.Parse(IFieldFloatVar.text);
    }

    #region [1-2 пункты дз]    
    public void SimpleGenerateArray()
    {
        _isIntArray = ToggleArray.isOn;

        if (_isIntArray)
        {            
            GetVariablesFromIField();
            _intArray = new int[_arrayLenght];
            _intArray[0] = _startVeriableInt;

            for (int i = 1; i < _intArray.Length; i++)
            {
                _intArray[i] = (int)Mathf.Pow((int)_intArray[i - 1], 2);
            }
            ShowArray("Array task1",_intArray);
        }
        else if (!_isIntArray)
        {            
            GetVariablesFromIField();
            _floatArray = new float[_arrayLenght];
            _floatArray[0] = _startVeriableFloat;

            for (int i = 1; i < _floatArray.Length; i++)
            {
                _floatArray[i] = (float)Mathf.Pow(_floatArray[i - 1], 2);
            }
            ShowArrayFloat("Array task1",_floatArray);
        }
    }

    #endregion

    #region [4-й пункт дз]

    public void GenArrayInputStartVar()
    {
        _isIntArray = ToggleArray.isOn;
        if (_isIntArray)
        {
            GenerateArrayInputStartVar(_startVeriableInt);
        }
        else
        {
            GenerateArrayInputStartVar(_startVeriableFloat);
        }
    }
    public void GenerateArrayInputStartVar(int startVar)
    {
        GetVariablesFromIField();
        _intArray = new int[_arrayLenght];
        _intArray[0] = startVar;

        for (int i = 1; i < _intArray.Length; i++)
        {
            _intArray[i] = (int)Mathf.Pow((int)_intArray[i - 1], 2);
        }
        ShowArray("Array task2",_intArray);
    }

    public void GenerateArrayInputStartVar(float startVar)
    {
        GetVariablesFromIField();
        _floatArray = new float[_arrayLenght];
        _floatArray[0] = startVar;

        for (int i = 1; i < _floatArray.Length; i++)
        {
            _floatArray[i] = (float)Mathf.Pow(_floatArray[i - 1], 2);
        }
        ShowArrayFloat("Array task2",_floatArray);
    }
    #endregion

    #region [5-й пункт дз]

    public void GenArrayInputRefStartVar()
    {
        _isIntArray = ToggleArray.isOn;
        GetVariablesFromIField();
        if (_isIntArray)
        {
            GenerateArrayInputRefStartVar(ref _startVeriableInt);
        }
        else
        {
            GenerateArrayInputRefStartVar(ref _startVeriableFloat);
        }
    }
    public void GenerateArrayInputRefStartVar(ref  int _startVeriableInt)
    {        
        _intArray = new int[_arrayLenght];
        _intArray[0] = _startVeriableInt;

        for (int i = 1; i < _intArray.Length; i++)
        {
            _intArray[i] = (int)Mathf.Pow((int)_intArray[i - 1], 2);
        }
        ShowArray("Array task3", _intArray);
    }

    public void GenerateArrayInputRefStartVar(ref float _startVeriableFloat)
    {
        _floatArray = new float[_arrayLenght];
        _floatArray[0] = _startVeriableFloat;

        for (int i = 1; i < _floatArray.Length; i++)
        {
            _floatArray[i] = (float)Mathf.Pow(_floatArray[i - 1], 2);
        }
        ShowArrayFloat("Array task3",_floatArray);
    }
    #endregion

    #region [6-й пункт дз]

    public void GenArrayOutputStartVar()
    {
        _isIntArray = ToggleArray.isOn;
        GetVariablesFromIField();
        if (_isIntArray)
        {
            GenerateArrayOutputStartVar(out _startVeriableInt);
        }
        else
        {
            GenerateArrayOutputStartVar(out _startVeriableFloat);
        }
    }
    public void GenerateArrayOutputStartVar(out int _startVeriableInt)
    {
        _intArray = new int[_arrayLenght];
        _intArray[0] = int.Parse(IFieldIntVar.text); 

        for (int i = 1; i < _intArray.Length; i++)
        {
            _intArray[i] = (int)Mathf.Pow((int)_intArray[i - 1], 2);
        }
        _startVeriableInt = _intArray[0];

        ShowArray($"Output: {_startVeriableInt} Array task4 ",_intArray);        
    }

    public void GenerateArrayOutputStartVar(out float _startVeriableFloat)
    {
        
        _floatArray = new float[_arrayLenght];
        _floatArray[0] = float.Parse(IFieldFloatVar.text);

        for (int i = 1; i < _floatArray.Length; i++)
        {
            _floatArray[i] = (float)Mathf.Pow(_floatArray[i - 1], 2);
        }
        _startVeriableFloat = _floatArray[0];
        ShowArrayFloat($"Output: {_startVeriableFloat} Array task4 ", _floatArray);
    }
    #endregion

   
    public void SwitchInputTypeArray()
    {
        if (ToggleArray.isOn)
        {
            IFieldIntVar.gameObject.SetActive(true);
            TextIntVar.gameObject.SetActive(true);
            IFieldFloatVar.gameObject.SetActive(false);
            TextFloatVar.gameObject.SetActive(false);
        }
        else
        {
            IFieldIntVar.gameObject.SetActive(false);
            TextIntVar.gameObject.SetActive(false);
            IFieldFloatVar.gameObject.SetActive(true);
            TextFloatVar.gameObject.SetActive(true);
        }
    }

    public void ShowArray(string numberTask, int[] array)
    {
        TextViewArray.text = "";
        string viewArray = numberTask + ":";
        foreach (var item in array)
        {
            viewArray = viewArray + " "+ item;
        }
        TextViewArray.text = viewArray;
    }

    public void ShowArrayFloat(string numberTask, float[] array)
    {
        TextViewArray.text = "";
        string viewArray = numberTask+":";
        foreach (var item in array)
        {
            viewArray = viewArray + " " + item;
        }
        TextViewArray.text = viewArray;
    }
    public void OnGoToHW1()
    {
        SceneManager.LoadScene(0);
    }
}
