using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class hw1 : MonoBehaviour
{
    public InputField IFieldInt;
    public InputField IFieldfloat;
    public InputField IFieldChar;
    public Toggle ToggleBool;

    public Text TextInt;
    public Text TextFloat;
    public Text TextChar;
    public Text TextBool;

    public Text TextString;
    public Text TextSaveStatus;
    
    [SerializeField] private int _veriableA = 3;
    [SerializeField] private float _veriableB = 5.5f;
    [SerializeField] private char _veriableC = 'f';
    [SerializeField] private bool _isVeriableD = false;
    private string _listOriginVeriables="";
    private string _listTransformVeriables="";
    private string _listAllVeriables="";



    [ContextMenu("Concat")]
    public void Concat()
    {
        _listOriginVeriables=($"{_veriableA} {_veriableB} {_veriableC} {_isVeriableD}");
        Debug.Log($"Исходные переменные: {_listOriginVeriables}");
        //Transformation();
        _listAllVeriables = _listOriginVeriables + " | " + _listTransformVeriables;
        Debug.Log($"Список всех переменных: { _listAllVeriables}");
        TextString.text = _listAllVeriables;
    }

    [ContextMenu("Transformation")]
    public void Transformation()
    {
        _veriableA = int.Parse(IFieldInt.text);

        if (!float.TryParse(IFieldfloat.text, out _veriableB))
        {
            Debug.LogError("Неверно введено значение Float");
        }
        _veriableC = Convert.ToChar(IFieldChar.text);
        _isVeriableD = ToggleBool.isOn;
        
        byte varTransformA1 = (byte)_veriableA;
        int varTransformB1 = (int)_veriableB;
        int varTransformC1 = _veriableC;        
        int varTransformD = Convert.ToInt32(_isVeriableD);

        TextInt.text = varTransformA1.ToString();
        TextFloat.text = varTransformB1.ToString();
        TextChar.text = varTransformC1.ToString();
        TextBool.text = varTransformD.ToString();

        _listTransformVeriables = ($"{varTransformA1} {varTransformB1} {varTransformC1} {varTransformD}");
       // Debug.Log($"Преобразованные переменные: {_listTransformVeriables}");
    }

    [ContextMenu("SaveToFile")]
    public void SaveToFile()
    {
        string path = @"unityHW3.txt";
        FileInfo fileVariables = new FileInfo(path);
        
        if (fileVariables.Exists)
        {
            fileVariables.Delete();
        }

        using (FileStream fileStream = fileVariables.Create())
        {
            byte[] varsOrigin = System.Text.Encoding.Default.GetBytes($"Исходные переменные: {_listOriginVeriables} ");
            fileStream.Write(varsOrigin,0,varsOrigin.Length);
            byte[] varsTransform = System.Text.Encoding.Default.GetBytes($" Преобразованные переменные: {_listTransformVeriables} ");
            fileStream.Write(varsTransform, 0, varsTransform.Length);
            byte[] varsAll = System.Text.Encoding.Default.GetBytes($" Список всех переменных: { _listAllVeriables} ");
            fileStream.Write(varsAll, 0, varsAll.Length);
            TextSaveStatus.text = $" {path} Файл успешно записан!";
        }        
    }

    public void OnGoToHW2()
    {
        SceneManager.LoadScene(1);
    }
}
