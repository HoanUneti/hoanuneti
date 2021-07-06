using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonText : MonoBehaviour
{
    public Text Textfield;
    public static double a = 0, b = 0, c = 0, result = 0;
    public static int i = 0;
    public static string get_operator = "";
    public static bool operation_pressed = false;

    // Hàm cho phím C và khi ấn C sẽ reset số lần bấm dấu =
    public void Clear()
    {
        Textfield.text = "0";
        a = 0;
        b = 0;
        i = 0;
    }
    // Hàm set text cho Textfield (truyền vào text của button khi click)
    public void SetText(string text)
    {

        if (Textfield.text == "0" || (operation_pressed)) // check nếu Textfield = 0 hoac đã bấm phép tính thì Set text mới cho Textfield (mục đích để lưu giá trị cho biến a và b)  
        {
            Textfield.text = ""; // Kết hợp bên dưới để clear Textfield vì unity không hỗ trợ hàm Clear()
            operation_pressed = false; // => có thể nối chuỗi khi click các button khác nhau
            Textfield.text += text;

        }
        else
        {
            Textfield.text += text;
        }
        i = 0;

    }
    public void SetDotText(string text)
    {

        if (double.Parse(Textfield.text) == int.Parse(Textfield.text)) // check để ấn được duy nhất 1 lần dấu chấm .
        {
            Textfield.text += text;

        }
        operation_pressed = false;
        i = 0;
    }
    public void Operator_click(string text)
    {
        a = double.Parse(Textfield.text);
        get_operator = text;
        operation_pressed = true; // đưa về hàm Clear() Textfield.
        i = 0;

    }

    public void Result()
    {
        Debug.Log(i);
        if (i == 0) //Nếu bấm dấu = 1 lần thì tính toán bình thường. Bấm 2 lần trở lên thì phép tính bằng kết quả lần trước tính với số b
        {
            b = double.Parse(Textfield.text);
            switch (get_operator)
            {
                case "+":
                    result = a + b;
                    Textfield.text = result.ToString();
                    i++;
                    break;
                case "-":
                    result = a - b;
                    Textfield.text = result.ToString();
                    i++;
                    break;
                case "*":
                    result = a * b;
                    Textfield.text = result.ToString();
                    i++;
                    break;
                case "/":
                    result = a / b;
                    Textfield.text = result.ToString();
                    i++;
                    break;
                default:
                    break;
            }
            operation_pressed = true;
            a = result;
        }
        else
        {
            switch (get_operator)
            {
                case "+":
                    result = a + b;
                    Textfield.text = result.ToString();
                    i++;
                    break;
                case "-":
                    result = a - b;
                    Textfield.text = result.ToString();
                    i++;
                    break;
                case "*":
                    result = a * b;
                    Textfield.text = result.ToString();
                    i++;
                    break;
                case "/":
                    result = a / b;
                    Textfield.text = result.ToString();
                    i++;
                    break;
                default:
                    break;
            }
            operation_pressed = true;
            a = result;
        }

        //Debug.Log("a: " + a);
        //Debug.Log("b: " + b);
        //Debug.Log(get_operator);
    }
    // Start is called before the first frame update
    void Start()
    {
        Textfield.text = "0";
    }

    // Update is called once per frame
    void Update()
    {

    }
}
