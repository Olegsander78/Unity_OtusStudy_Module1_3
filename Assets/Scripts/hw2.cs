using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public struct Data
{
    public bool isIntArray;
    public int startVarInt;
    public float startVarFloat;
}

public class hw2 : MonoBehaviour
{
    public Toggle ToggleArray;
    public InputField IFieldIntVar;
    public InputField IFieldFloatVar;
    public InputField IFieldValueArray;
    public Text TextViewArray;
    public Text TextIntVar;
    public Text TextFloatVar;

    [SerializeField] private int _startVariableInt = 1;
    [SerializeField] private float _startVariableFloat = 1f;
    [SerializeField] private int _arrayLenght;
    //[SerializeField] private bool _isIntArray = true;
    [SerializeField] private int[] _intArray;
    [SerializeField] private float[] _floatArray;


    private void Update()
    {
        SwitchInputTypeArray();
    }

    public void GetVariablesFromIField()
    {
        _arrayLenght = int.Parse(IFieldValueArray.text);
        if (!int.TryParse(IFieldIntVar.text, out _startVariableInt))
        {
            Debug.LogWarning("Invalid Int, try to enter both veriables!");
        }        
        if (!float.TryParse(IFieldFloatVar.text, out _startVariableFloat))
        {
            Debug.LogWarning("Invalid Float, try to enter both veriables!");
        }
    }

    #region [1-2 пункты дз]    
    public void SimpleGenerateArray()
    {
        if (ToggleArray.isOn)
        {
            GetVariablesFromIField();
            _intArray = new int[_arrayLenght];
            _intArray[0] = _startVariableInt;

            for (int i = 1; i < _intArray.Length; i++)
            {  
                try
                {
                    long powVar = (long)Mathf.Pow(_intArray[i - 1], 2);
                    if (powVar <= int.MaxValue && powVar >= int.MinValue)
                    {
                        _intArray[i] = (int)powVar;
                    }
                    else
                    {
                        throw new OverflowException();
                    }
                }
                catch (OverflowException)
                {
                    Debug.Log("Overflow Integer exception was caught!");
                    _intArray[i] = 0;
                    break;
                }
            }
            ShowArray("Array task1", _intArray);
        }
        else
        {
            GetVariablesFromIField();
            _floatArray = new float[_arrayLenght];
            _floatArray[0] = _startVariableFloat;

            for (int i = 1; i < _floatArray.Length; i++)
            {
                try
                {
                    double powVar = (double)Mathf.Pow(_floatArray[i - 1], 2);
                    if (powVar <= float.MaxValue && powVar >= float.MinValue)
                    {
                        _floatArray[i] = (float)powVar;
                    }
                    else
                    {
                        throw new OverflowException();
                    }
                }
                catch (OverflowException)
                {
                    Debug.Log("Overflow Float exception was caught!");
                    break;
                }
            }
            ShowArrayFloat("Array task1", _floatArray);
        }
    }

    #endregion

    #region [4-й пункт дз]

    public void GenArrayInputStartVar()
    {
        if (ToggleArray.isOn)
        {
            GenerateArrayInputStartVar(_startVariableInt);
        }
        else
        {
            GenerateArrayInputStartVar(_startVariableFloat);
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
        GetVariablesFromIField();
        if (ToggleArray.isOn)
        {
            GenerateArrayInputRefStartVar(ref _startVariableInt);
        }
        else
        {
            GenerateArrayInputRefStartVar(ref _startVariableFloat);
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
        GetVariablesFromIField();
        if (ToggleArray.isOn)
        {
            GenerateArrayOutputStartVar(out _startVariableInt);
        }
        else
        {
            GenerateArrayOutputStartVar(out _startVariableFloat);
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
        _startVeriableInt = _intArray[1];

        ShowArray($"Output array[1]: {_startVeriableInt} Array task4 ",_intArray);        
    }

    public void GenerateArrayOutputStartVar(out float _startVeriableFloat)
    {
        
        _floatArray = new float[_arrayLenght];
        _floatArray[0] = float.Parse(IFieldFloatVar.text);

        for (int i = 1; i < _floatArray.Length; i++)
        {
            _floatArray[i] = (float)Mathf.Pow(_floatArray[i - 1], 2);
        }
        _startVeriableFloat = _floatArray[1];
        ShowArrayFloat($"Output array[1]: {_startVeriableFloat} Array task4 ", _floatArray);
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

    [ContextMenu("SaveData")]
    public void SaveData()
    {        
        DirectoryInfo dir = new DirectoryInfo(@"./UpdateData");
        if (!dir.Exists)
        {
            dir.Create();
        }
        Debug.Log(dir);

        FileInfo saveFile = new FileInfo(@"./UpdateData/Save.dat");        
        using (FileStream saveFileStream = saveFile.Open(FileMode.OpenOrCreate,
            FileAccess.ReadWrite, FileShare.None))
            {

        }
    }

    [ContextMenu("LoadData")]
    public void LoadData()
    {
        //DirectoryInfo dir = new DirectoryInfo("./UpdateData");
        //if (!dir.Exists)
        //{
        //    Debug.Log("Folder not found!");
        //}        
    }

    public void OnGoToHW1()
    {
        SceneManager.LoadScene(0);
    }
}
