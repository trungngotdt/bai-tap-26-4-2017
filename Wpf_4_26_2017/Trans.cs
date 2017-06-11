using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Wpf_4_26_2017
{
    class Trans
    {
        private string input;

        public string Input
        {
            get
            {
                return input;
            }

            set
            {
                input = value;
            }
        }

        public string Output
        {
            get
            {
                return output;
            }

            set
            {
                output = value;
            }
        }

        private string output;
        public Trans()
        {
            output = "";
            input = "";
        }
        public float _ket_qua(string input)
        {
            float _result = 0;
            Stack stack = new Stack();
            string[] _bag_for_input = input.Split(' ');
            foreach (var item in _bag_for_input)
            {
                if (item == " ")
                {

                }
                else if (Regex.IsMatch(item, "[0-9]"))
                {
                    stack.Push(item);
                }
                else if (item == "+" || item == "*" || item == "-" || item == "/")
                {
                    float _number2 = float.Parse(stack.Pop().ToString());
                    float _number1 = float.Parse(stack.Pop().ToString());
                    if (item == "+")
                    {
                        stack.Push(_number1 + _number2);
                    }
                    else if (item == "-")
                    {
                        stack.Push(_number1 - _number2);
                    }
                    else if (item == "*")
                    {
                        stack.Push(_number1 * _number2);
                    }
                    else if (item == "/")
                    {
                        stack.Push(_number1 / _number2);
                    }
                }
            }
            _result = float.Parse(stack.Peek().ToString());
            return _result;
        }
        public string _chuyen(string input)
        {

            string temp = "";
            string output = "";
            Stack stack = new Stack();
            string result = "";
            string[] bag_for_input = _dinh_dang(input).Split(' ');
            foreach (var item in bag_for_input)
            {
                if (String.IsNullOrWhiteSpace(item) || String.IsNullOrEmpty(item))
                {
                    continue;
                }
                else if (Regex.IsMatch(item, "[0-9]"))
                {
                    output = output + item + " ";
                }
                else if (item == "(")
                {
                    stack.Push("(");
                }
                else if (item == ")")
                {
                    while (stack.Peek().ToString() != "(")
                    {
                        output = output + stack.Pop().ToString() + " ";
                    }
                    if (stack.Peek().ToString() == "(")
                    {
                        stack.Pop();
                    }


                }
                else if (_kiem_tra(item) > 0)
                {
                    if ((!(Regex.IsMatch(temp, "[0-9]"))) && (temp == "("))
                    {
                        output = output + "0 ";
                    }
                    if ((stack.Count > 0) && (_kiem_tra(item) <= _kiem_tra(stack.Peek().ToString())) && (_kiem_tra(stack.Peek().ToString()) != -1) && (_kiem_tra(stack.Peek().ToString()) != 0))
                    {

                        output = output + stack.Pop().ToString() + " ";
                        stack.Push(item);
                    }
                    else
                    {
                        stack.Push(item);
                    }
                }
                temp = item;
            }
            while (stack.Count != 0)
            {
                output = output + stack.Pop().ToString() + " ";
            }
            temp = null;

            result = _ket_qua(output).ToString();
            string temp2 = null;
            return result;
        }
        /// <summary>
        /// thêm khoảng trắng vào giữa hai ký tự
        /// </summary>
        /// <param name="chuoi"></param>
        /// <returns></returns>
        string _dinh_dang(string chuoi)
        {
            chuoi = Regex.Replace(chuoi, @"\+|\-|\*|\/|\%|\^|\)|\(", delegate (Match m)
            {
                return " " + m.Value.ToString() + " ";
            }
            );
            return chuoi;
        }
        /// <summary>
        /// Trả về 1 khi là dấu cộng hay trừ
        /// Trả về 3 khi là dấu nhân hay chia
        /// Trả về -1 khi là dấu đóng hay mở ngoặc
        /// Trả về 0 các trường hợp còn lại
        /// </summary>
        /// <param name="chuoi"></param>
        /// <returns></returns>
        int _kiem_tra(string chuoi)
        {
            if (chuoi == "+" || chuoi == "-")
            {
                return 1;
            }
            else if (chuoi == "*" || chuoi == "/")
            {
                return 3;
            }
            else if (chuoi == ")" || chuoi == "(")
            {
                return -1;
            }
            return 0;

        }
    }
}
