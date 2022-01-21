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
    [SerializeField] private bool _isIntArray = true;
    [SerializeField] private int[] _intArray;
    [SerializeField] private float[] _floatArray;

    private void Update()
    {
        if (ToggleArray.isOn)
        {
            TextIntVar.enabled = true;
            IFieldIntVar.enabled = true;
            TextFloatVar.enabled = false;
            IFieldFloatVar.enabled = false;
            _intArray = new int[Convert.ToInt32(IFieldValueArray.text)];
            _intArray[0] = _startVeriableInt;
            SimpleGenerateArray(_intArray);


        }
        else
        {
            TextIntVar.enabled = false;
            IFieldIntVar.enabled = false;
            TextFloatVar.enabled = true;
            IFieldFloatVar.enabled = true;
            _floatArray = new float[Convert.ToInt32(IFieldValueArray.text)];
            _floatArray[0] = _startVeriableFloat;
            SimpleGenerateArray(_floatArray);
        }             

    }

    #region[ Попробовал сделать метод через дженерики , не хватило опыта]
    //public void GenerateArray<T>(T[] array)
    //{

    //    for (int i = 1; i < array.Length; i++)
    //    {
    //        array[i]=(T)Math.Pow(array[i - 1],array[i - 1]);
    //    }
    //}

    #endregion


    #region [1-2 пункты дз]
    public void SimpleGenerateArray(int[] array)
    {

        for (int i = 1; i < array.Length; i++)
        {
            array[i] = (int)Math.Pow(array[i-1], array[i-1]);
        }
        ShowArray(array);
    }

    public void SimpleGenerateArray(float[] array)
    {

        for (int i = 1; i < array.Length; i++)
        {
            array[i] = (int)Math.Pow(array[i - 1], array[i - 1]);
        }
        ShowArray(array);
    }
    #endregion

    #region [4-й пункт дз]
    public void GenerateArrayInStartVar(int[] array, int startVar)
    {
        array[0]= startVar;
        for (int i = 1; i < array.Length; i++)
        {
            array[i] = (int)Math.Pow(array[i - 1], array[i - 1]);
        }
        ShowArray(array);
    }

    public void GenerateArrayInStartVar(float[] array, float startVar)
    {
        array[0] = startVar;
        for (int i = 1; i < array.Length; i++)
        {
            array[i] = (int)Math.Pow(array[i - 1], array[i - 1]);
        }
        ShowArray(array);
    }
    #endregion

    #region [5-й пункт дз]
    public void GenerateArrayInRefStartVar(int[] array,ref  int _startVeriableInt)
    {
        array[0] = _startVeriableInt;
        for (int i = 1; i < array.Length; i++)
        {
            array[i] = (int)Math.Pow(array[i - 1], array[i - 1]);
        }
        ShowArray(array);
    }

    public void GenerateArrayInRefStartVar(float[] array, ref float _startVeriableFloat)
    {
        array[0] = _startVeriableFloat;
        for (int i = 1; i < array.Length; i++)
        {
            array[i] = (int)Math.Pow(array[i - 1], array[i - 1]);
        }
        ShowArray(array);
    }
    #endregion

    #region [6-й пункт дз]
    public void GenerateArrayOutStartVar(int[] array , out int _startVeriableInt )
    {
        _startVeriableInt= array[0];
        for (int i = 1; i < array.Length; i++)
        {
            array[i] = (int)Math.Pow(array[i - 1], array[i - 1]);
        }
        ShowArray(array);
    }

    public void GenerateArrayOutRefStartVar(float[] array, out float _startVeriableFloat)
    {
        _startVeriableFloat = array[0];
        for (int i = 1; i < array.Length; i++)
        {
            array[i] = (int)Math.Pow(array[i - 1], array[i - 1]);
        }
        ShowArray(array);
    }
    #endregion

    public void ShowArray(int[] array)
    {
        string viewArray = "";
        foreach (var item in array)
        {
            viewArray = viewArray + " "+ item;
        }
        TextViewArray.text = viewArray;
    }

    public void ShowArray(float[] array)
    {
        string viewArray = "";
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
